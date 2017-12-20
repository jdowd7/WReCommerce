namespace WReCommerce.Data.Interfaces.Product
{
    public interface IProductRepository
    {
        Models.Product.Product Get(int productId);
        Models.Product.Product AddProduct(Models.Product.Product product);
        Models.Product.Product UpdateProduct(int productId, Models.Product.Product product);
        bool DeleteProduct(int productId);


    }
}