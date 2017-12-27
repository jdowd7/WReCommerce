using System;
using System.Collections.Generic;
using WReCommerce.Common.DTO;
using WReCommerce.Common.Enums;
using WReCommerce.Common.Utility;
using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Interfaces.Userprofile.UserMembership;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Domain.Business.Models.PurchaseOrder;

namespace WReCommerce.Core.Services
{
    public class PurchaseOrderRequestService : IPurchaseOrderRequestService
    {

        private IPurchaseOrderRequestRepository _purchaseOrderRequestRepository { get; set; }
        private IProductService _productService { get; set; }
        private IUserMembershipRepository _userMembershipRepository { get; set; }
        public IPurchaseOrderShipmentRepository _purchaseOrderShipmentRepository { get; set; }

        public PurchaseOrderRequestService(
            IPurchaseOrderRequestRepository purchaseOrderRequestRepository, 
            IProductService productService, 
            IUserMembershipRepository userMembershipRepository,
            IPurchaseOrderShipmentRepository purchaseOrderShipmentRepository
            )
        {
            _purchaseOrderRequestRepository = purchaseOrderRequestRepository;
            _productService = productService;
            _userMembershipRepository = userMembershipRepository;
            _purchaseOrderShipmentRepository = purchaseOrderShipmentRepository;

        }

        public PurchaseOrderRequest AddPurchaseOrderRequest(OrderRequest orderRequest)
        {
            // set up the purchase order and poLines
            var purchaseOrder = ProcessPurchaseOrder(orderRequest, out var poResult);

            return purchaseOrder.ToPurchaseOrderRequest();
        }

        private PurchaseOrder ProcessPurchaseOrder(OrderRequest orderRequest, out PurchaseOrder poResult)
        {
            var purchaseOrder = new PurchaseOrder
            {
                UserProfileId = orderRequest.UserprofileId,
                RefPurchaseOrderStatus = RefPurchaseOrderStatus.Processing,
                PurchaseOrderLines = new List<PurchaseOrderLine>()
            };

            poResult = _purchaseOrderRequestRepository.AddPurchaseOrder(purchaseOrder);

            if (poResult == null) throw new ArgumentNullException(nameof(purchaseOrder));

            ProcessPurchaseOrderLines(orderRequest, poResult, purchaseOrder);

            return purchaseOrder;
        }

        private void ProcessPurchaseOrderLines(OrderRequest orderRequest, PurchaseOrder poResult, PurchaseOrder purchaseOrder)
        {
            foreach (var orderIdQuantPair in orderRequest.ProductIds)
            {
                var poLine = new PurchaseOrderLine
                {
                    ProductId = orderIdQuantPair.Key.Id,
                    Quantity = orderIdQuantPair.Value,
                    Subtotal = orderIdQuantPair.Key.UnitCost * orderIdQuantPair.Value,
                    PurchaseOrderId = poResult.Id
                };

                var poLineResult = _purchaseOrderRequestRepository.AddPurchaseOrderLine(poLine);

                if (poLineResult == null) throw new ArgumentNullException(nameof(poLineResult));
                purchaseOrder.PurchaseOrderLines.Add(poLineResult);

                // Wait for success, then check for product type and handle business rules as requirements directed
                ProductResolver(purchaseOrder, poLineResult);
            }
        }

        private void ProductResolver(PurchaseOrder purchaseOrder, PurchaseOrderLine poLineResult)
        {
            var productResult = _productService.GetProduct(poLineResult.ProductId);
            if (productResult == null) throw new ArgumentNullException(nameof(productResult));

            // BR1.If the purchase order contains a membership, it should be activated in the customer account immediately.
            if (productResult.ProductForm == RefProductForm.Membership)
            {
                // Activate the membership and assign membership value
                // Should check to see if there is already a membership available of the Membership category, if so update that
                _userMembershipRepository.AddUserMembership(
                    new UserMembership
                    {
                        ProductId = productResult.Id,
                        UserProfileId = purchaseOrder.UserProfileId,
                        MembershipInitial = productResult.ProductMembershipValue,
                        MembershipRemaining = productResult.ProductMembershipValue,
                        MembershipCategory = productResult.ProductCategory
                    });
            }
            else if (productResult.ProductForm == RefProductForm.Physical)
            {
                // BR2. If the purchase order contains a physical product, a shipping slip should be generated.
                // probably would make more sense to check for a userShipment and see whats its status is, if unshipped update.... but again brevity.
                _purchaseOrderShipmentRepository.AddPurchaseOrderShipment(
                    new PurchaseOrderShipment
                    {
                        PurchaseOrderId = purchaseOrder.Id,
                        ShipmentStatus = "Shipping Slip Created",
                        Weight = productResult.Weight,
                        TrackingNumber = ShippingLabelGenerator.GenerateShippingLabel(),
                        Items = 1
                    });
            }
        }
    }
}