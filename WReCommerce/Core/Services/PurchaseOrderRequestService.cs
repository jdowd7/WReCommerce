using System;
using System.Collections.Generic;
using System.Threading;
using WReCommerce.Common.DTO;
using WReCommerce.Common.Enums;
using WReCommerce.Core.Interfaces;
using WReCommerce.Data.EntityFramework.Repository.PurchaseOrder;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Domain.Business.Models.PurchaseOrder;

namespace WReCommerce.Core.Services
{
    public class PurchaseOrderRequestService : IPurchaseOrderRequestService
    {

        private IPurchaseOrderRequestRepository _purchaseOrderRequestRepository { get; set; }

        public PurchaseOrderRequestService(IPurchaseOrderRequestRepository purchaseOrderRequestRepository)
        {
            _purchaseOrderRequestRepository = purchaseOrderRequestRepository;
        }

        public PurchaseOrderRequest AddPurchaseOrderRequest(OrderRequest orderRequest)
        {
            var purchaseOrder = new PurchaseOrder
            {
                UserProfileId = orderRequest.UserprofileId,
                RefPurchaseOrderStatus = RefPurchaseOrderStatus.Processing,
                PurchaseOrderLines = new List<PurchaseOrderLine>()
            };

            var poResult = _purchaseOrderRequestRepository.AddPurchaseOrder(purchaseOrder);

            if (poResult == null) throw new ArgumentNullException(nameof(purchaseOrder));

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
            }

            return purchaseOrder.ToPurchaseOrderRequest();
        }
    }
}