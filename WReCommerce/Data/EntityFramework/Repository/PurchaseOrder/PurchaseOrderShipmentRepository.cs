using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.PurchaseOrder
{
    public class PurchaseOrderShipmentRepository
    {
        private CommercePlatformContext _context { get; set; }

        public PurchaseOrderShipmentRepository(CommercePlatformContext context)
        {
            _context = context;
        }


    }
}