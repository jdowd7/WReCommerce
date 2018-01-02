using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Interfaces
{
    public interface IPurchaseOrderShipmentService
    {
        PurchaseOrderShipment GetPurchaseOrderShipment(int purchaseOrderShipmentId);
        PurchaseOrderShipment AddPurchaseOrderShipment(PurchaseOrderShipment purchaseOrderShipment);
        PurchaseOrderShipment UpdatePurchaseOrderShipment(int purchaseOrderShipmentId, PurchaseOrderShipment purchaseOrderShipment);
        bool DeletePurchaseOrderShipment(int purchaseOrderShipmentId);
    }
}