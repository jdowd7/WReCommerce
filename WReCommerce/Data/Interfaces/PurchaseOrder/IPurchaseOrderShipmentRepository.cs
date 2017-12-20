using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderShipmentRepository
    {
        PurchaseOrderShipment Get(int purchaseOrderLineId);
        PurchaseOrderShipment AddPurchaseOrderShipment(PurchaseOrderShipment purchaseOrderLine);
        PurchaseOrderShipment UpdatePurchaseOrderShipment(int purchaseOrderLineId, PurchaseOrderShipment purchaseOrderLine);
        bool DeletePurchaseOrderShipment(int purchaseOrderLineId);
    }
}