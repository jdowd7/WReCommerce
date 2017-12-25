using System.Collections.Generic;

namespace WReCommerce.Data.Interfaces.Product
{
    public interface IProductRepository
    {
        Models.Product.Product Get(int productId);

        ICollection<Models.Product.Product> GetAllProducts();
        Models.Product.Product AddProduct(Models.Product.Product product);
        Models.Product.Product UpdateProduct(int productId, Models.Product.Product product);
        bool DeleteProduct(int productId);


    }
}