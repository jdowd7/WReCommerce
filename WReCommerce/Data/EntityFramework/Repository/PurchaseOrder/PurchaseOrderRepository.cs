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
            throw new System.NotImplementedException();
        }

        public Models.PurchaseOrder.PurchaseOrder AddPurchaseOrder(Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            throw new System.NotImplementedException();
        }

        public Models.PurchaseOrder.PurchaseOrder UpdatePurchaseOrder(int purchaseOrderId, Models.PurchaseOrder.PurchaseOrder purchaseOrder)
        {
            throw new System.NotImplementedException();
        }

        public Models.PurchaseOrder.PurchaseOrder DeletePurchaseOrder(int purchaseOrderId)
        {
            throw new System.NotImplementedException();
        }
    }
}