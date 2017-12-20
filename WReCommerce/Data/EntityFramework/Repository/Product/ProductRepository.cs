using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.Product
{
    public class ProductRepository
    {
        private CommercePlatformContext _context { get; set; }

        public ProductRepository(CommercePlatformContext context)
        {
            _context = context;
        }

    }
}