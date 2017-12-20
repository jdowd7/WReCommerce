namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderRepository
    {
        Models.PurchaseOrder.PurchaseOrder Get(int purchaseOrderId);
        Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder);
        Models.PurchaseOrder.PurchaseOrder UpdatePurchaseOrder(int purchaseOrderId, Models.PurchaseOrder.PurchaseOrder purchaseOrder);
        Models.PurchaseOrder.PurchaseOrder DeletePurchaseOrder(int purchaseOrderId);

    }
}