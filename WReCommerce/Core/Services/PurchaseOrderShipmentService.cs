using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Core.Services
{
    public class PurchaseOrderShipmentService : IPurchaseOrderShipmentService
    {
        public IPurchaseOrderShipmentRepository PurchaseOrderShipmentRepository { get; set; }

        public PurchaseOrderShipmentService(IPurchaseOrderShipmentRepository purchaseOrderShipmentRepository)
        {
            PurchaseOrderShipmentRepository = purchaseOrderShipmentRepository;
        }

        public PurchaseOrderShipment GetPurchaseOrderShipment(int purchaseOrderShipmentId)
        {
            throw new System.NotImplementedException();
        }

        public PurchaseOrderShipment AddPurchaseOrderShipment(PurchaseOrderShipment purchaseOrderShipment)
        {
            return PurchaseOrderShipmentRepository.AddPurchaseOrderShipment(purchaseOrderShipment);
        }


        public PurchaseOrderShipment UpdatePurchaseOrderShipment(int purchaseOrderShipmentId,
            PurchaseOrderShipment purchaseOrderShipment)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePurchaseOrderShipment(int purchaseOrderShipmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}