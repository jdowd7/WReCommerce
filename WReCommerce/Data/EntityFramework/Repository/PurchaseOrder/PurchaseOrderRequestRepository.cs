using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Models.PurchaseOrder;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderRequestRepository : IPurchaseOrderRequestRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderRequestRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            var poResult = _context.PurchaseOrders.Add(purchaseOrder);
            _context.SaveChanges();
            return poResult;
        }

        public PurchaseOrderLine AddPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine)
        {
            var polResult = _context.PurchaseOrderLines.Add(purchaseOrderLine);
            _context.SaveChanges();
            return polResult;
        }
    }
}