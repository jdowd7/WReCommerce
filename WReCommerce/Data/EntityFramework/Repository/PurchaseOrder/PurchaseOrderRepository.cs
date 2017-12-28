using System.Linq;
using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.PurchaseOrder;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public Models.PurchaseOrder.PurchaseOrder Get(int purchaseOrderId)
        {
            return _context.PurchaseOrders
                .Include("PurchaseOrderShipments")
                .FirstOrDefault(x => x.Id == purchaseOrderId);
        }

        public Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            var result = _context.PurchaseOrders.Add(purchaseOrder);
            _context.SaveChanges();
            return result;
        }

        public Models.PurchaseOrder.PurchaseOrder UpdatePurchaseOrder(int purchaseOrderId, Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            var purchaseOrderResult = Get(purchaseOrderId);
            _context.Entry(purchaseOrderResult).CurrentValues.SetValues(purchaseOrder);
            _context.SaveChanges();
            return Get(purchaseOrderId);
        }

        public Models.PurchaseOrder.PurchaseOrder DeletePurchaseOrder(int purchaseOrderId)
        {
            throw new System.NotImplementedException();
        }
    }
}