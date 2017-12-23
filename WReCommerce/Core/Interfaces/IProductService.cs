using WReCommerce.Data.Models.Product;

namespace WReCommerce.Core.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        Product AddProduct(Product product);
    }
}