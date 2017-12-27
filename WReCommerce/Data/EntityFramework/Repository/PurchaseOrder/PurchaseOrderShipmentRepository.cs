using System.Linq;
using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderShipmentRepository : IPurchaseOrderShipmentRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderShipmentRepository(CommercePlatformContext context)
        {
            _context = context;
        }


        public PurchaseOrderShipment Get(int purchaseOrderLineId)
        {
            return _context.PurchaseOrderShipments.FirstOrDefault(pos => pos.Id == purchaseOrderLineId);
        }

        public PurchaseOrderShipment AddPurchaseOrderShipment(PurchaseOrderShipment purchaseOrderLineShipment)
        {
            var result = _context.PurchaseOrderShipments.Add(purchaseOrderLineShipment);
            _context.SaveChanges();
            return result;
        }

        public PurchaseOrderShipment UpdatePurchaseOrderShipment(int purchaseOrderLineId, PurchaseOrderShipment purchaseOrderLine)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePurchaseOrderShipment(int purchaseOrderLineId)
        {
            throw new System.NotImplementedException();
        }
    }
}