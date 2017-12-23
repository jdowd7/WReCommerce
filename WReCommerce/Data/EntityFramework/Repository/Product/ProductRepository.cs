using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
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
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public Models.Product.Product AddProduct(Models.Product.Product product)
        {
            var pResult = _context.Products.Add(product);
            _context.SaveChanges();
            return pResult;
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