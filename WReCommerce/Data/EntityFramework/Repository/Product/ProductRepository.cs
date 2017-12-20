using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Product;

namespace WReCommerce.Data.EntityFramework.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private CommercePlatformContext _context { get; set; }

        public ProductRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public Models.Product.Product Get(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Models.Product.Product AddProduct(Models.Product.Product product)
        {
            throw new System.NotImplementedException();
        }

        public Models.Product.Product UpdateProduct(int productId, Models.Product.Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}