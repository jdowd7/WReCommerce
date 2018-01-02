using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Interfaces
{
    public interface IPurchaseOrderLineService
    {
        PurchaseOrderLine GetPurchaseOrderLine(int purchaseOrderLineId);
        PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine);
        PurchaseOrderLine UpdatePurchaseOrderLine(int purchaseOrderLineId, PurchaseOrderLine purchaseOrderLine);
        bool DeletePurchaseOrderLine(int purchaseOrderLineId);
    }
}