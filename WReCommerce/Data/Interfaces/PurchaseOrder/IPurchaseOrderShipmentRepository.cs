using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.Interfaces.PurchaseOrder
{
    public interface IPurchaseOrderShipmentRepository
    {
        PurchaseOrderShipment Get(int purchaseOrderLineId);
        PurchaseOrderShipment AddPurchaseOrderShipment(PurchaseOrderShipment purchaseOrderLineShipment);
        PurchaseOrderShipment UpdatePurchaseOrderShipment(int purchaseOrderLineId, PurchaseOrderShipment purchaseOrderLineShipment);
        bool DeletePurchaseOrderShipment(int purchaseOrderLineShipmentId);
    }
}