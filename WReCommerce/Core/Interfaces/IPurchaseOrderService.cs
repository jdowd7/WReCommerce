using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Interfaces
{
    public interface IPurchaseOrderService
    {
        PurchaseOrder GetPurchaseOrder(int purchaseOrderId);
        PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder);
        PurchaseOrder UpdatePurchaseOrder(int purchaseOrderId, PurchaseOrder purchaseOrder);
        bool DeletePurchaseOrder(int purchaseOrderId);
    }
}