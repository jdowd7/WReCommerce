using System;

namespace WReCommerce.Domain.Business.Models.PurchaseOrder
{
    public class PurchaseOrderRequest
    {
        public PurchaseOrderRequest(Data.Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder == null) throw new ArgumentNullException(nameof(purchaseOrder));

            if (purchaseOrder.Id > 0)
            {
                this.Success = true;
                this.PurchaseOrder = purchaseOrder;
            }
            else
            {
                this.Success = false;
                this.PurchaseOrder = purchaseOrder;
            }
        }

        public bool Success { get; set; }
        
        public Data.Models.PurchaseOrder.PurchaseOrder PurchaseOrder { get; set; }

    }

    public static class PurchaseOrderRequestFactory
    {
        public static PurchaseOrderRequest ToPurchaseOrderRequest(this Data.Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            return purchaseOrder == null ? null : new PurchaseOrderRequest(purchaseOrder);
        }

    }
}