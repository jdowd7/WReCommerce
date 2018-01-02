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
        private IUserMembershipService _userMembershipService { get; set; }
        public IPurchaseOrderShipmentService _purchaseOrderShipmentService { get; set; }
        public IUserprofileService _userprofileService { get; set; }
        public IPurchaseOrderService _purchaseOrderService { get; set; }

        public PurchaseOrderRequestService(
            IPurchaseOrderRequestRepository purchaseOrderRequestRepository, 
            IProductService productService, 
            IUserMembershipService userMembershipService,
            IPurchaseOrderShipmentService purchaseOrderShipmentService,
            IUserprofileService userprofileService,
            IPurchaseOrderService purchaseOrderService
            )
        {
            _purchaseOrderRequestRepository = purchaseOrderRequestRepository;
            _productService = productService;
            _userMembershipService = userMembershipService;
            _purchaseOrderShipmentService = purchaseOrderShipmentService;
            _userprofileService = userprofileService;
            _purchaseOrderService = purchaseOrderService;

        }

        public PurchaseOrderRequest AddPurchaseOrderRequest(OrderRequest orderRequest)
        {
            // set up the purchase order and poLines
            var purchaseOrder = ProcessPurchaseOrder(orderRequest, out var poResult);

            var tryPoResult = poResult.ToPurchaseOrderRequest();
            return purchaseOrder.ToPurchaseOrderRequest();
        }

        private PurchaseOrder ProcessPurchaseOrder(OrderRequest orderRequest, out PurchaseOrder poResult)
        {
            var purchaseOrder = new PurchaseOrder
            {
                UserProfileId = orderRequest.UserprofileId,
                RefPurchaseOrderStatus = RefPurchaseOrderStatus.Processing,
                PurchaseOrderLines = new List<PurchaseOrderLine>(),
                PurchaseOrderShipments = new List<PurchaseOrderShipment>(),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };


            //poResult = _purchaseOrderRequestRepository.AddPurchaseOrder(purchaseOrder);
            poResult = _purchaseOrderService.AddPurchaseOrder(purchaseOrder);

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
                    PurchaseOrderId = poResult.Id,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now
                };

                var poLineResult = _purchaseOrderRequestRepository.AddPurchaseOrderLine(poLine);

                if (poLineResult == null) throw new ArgumentNullException(nameof(poLineResult));

                // Wait for success, then check for product type and handle business rules as requirements directed
                ProductResolver(purchaseOrder, poLineResult);
            }
        }

        private void ProductResolver(PurchaseOrder purchaseOrder, PurchaseOrderLine poLineResult)
        {
            var productResult = _productService.GetProduct(poLineResult.ProductId);
            if (productResult == null) throw new ArgumentNullException(nameof(productResult));

            var uprofile = _userprofileService.GetUserprofile(purchaseOrder.UserProfileId);
            uprofile.UserMemberships = new List<UserMembership>();

            // BR1.If the purchase order contains a membership, it should be activated in the customer account immediately.
            if (productResult.ProductForm == RefProductForm.Membership)
            {
                // Activate the membership and assign membership value
                // Should check to see if there is already a membership available of the Membership category, if so update that
                var userMembership = new UserMembership
                {
                    ProductId = productResult.Id,
                    UserProfileId = purchaseOrder.UserProfileId,
                    MembershipInitial = productResult.ProductMembershipValue,
                    MembershipRemaining = productResult.ProductMembershipValue,
                    MembershipCategory = productResult.ProductCategory,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now
                };
                _userMembershipService.AddUserMembership(userMembership);
                
                //uprofile.UserMemberships.Add(userMembership);

                //_userprofileService.UpdateUserprofile(uprofile.Id, uprofile);
            }
            else if (productResult.ProductForm == RefProductForm.Physical)
            {
                // BR2. If the purchase order contains a physical product, a shipping slip should be generated.
                // probably would make more sense to check for a userShipment and see whats its status is, if unshipped update.... but again brevity.
                var poShip = new PurchaseOrderShipment
                {
                    PurchaseOrderId = purchaseOrder.Id,
                    ShipmentStatus = "Shipping Slip Created",
                    Weight = productResult.Weight,
                    TrackingNumber = ShippingLabelGenerator.GenerateShippingLabel(),
                    Items = 1,
                    DateAdded = DateTime.Now,
                    DateModified = DateTime.Now
                };
                _purchaseOrderShipmentService.AddPurchaseOrderShipment(poShip);

                //purchaseOrder.PurchaseOrderShipments.Add(poShip);

                //_purchaseOrderService.UpdatePurchaseOrder(purchaseOrder.Id, purchaseOrder);
            }
        }
    }
}