using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderRepository(CommercePlatformContext context)
        {
            _context = context;
        }
    }
}