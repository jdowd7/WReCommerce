using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderLineRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderLineRepository(CommercePlatformContext context)
        {
            _context = context;
        }
    }
}