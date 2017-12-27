using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderRequestRepository
    {
        Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder);

        PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
    }
}