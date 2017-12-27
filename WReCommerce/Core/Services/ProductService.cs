using System.Collections.Generic;
using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Models.Product;

namespace WReCommerce.Core.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository { get; set; }

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.Get(productId);
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public ICollection<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }
    }
}