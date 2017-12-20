using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderLineRepository
    {
        PurchaseOrderLine Get(int purchaseOrderLineId);
        PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        PurchaseOrderLine UpdatePurchaseOrderLine(int purchaseOrderLineId, PurchaseOrderLine purchaseOrderLine);
        bool DeletePurchaseOrderLine(int purchaseOrderLineId);

    }
}