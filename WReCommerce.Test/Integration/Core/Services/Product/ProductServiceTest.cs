using System.Data.Entity;
using System.Linq;
using System.Transactions;
using FluentAssertions;
using Moq;
using WReCommerce.Common.Enums;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.EntityFramework.Repository.Product;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Models.Address;
using WReCommerce.Data.Models.ProductType;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Test.Infrastructure;
using Xunit;

namespace WReCommerce.Test.Integration.Core.Services.Product
{
    public class ProductServiceTest : TestContainer
    {
        public IProductService ProductService { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public Mock<CommercePlatformContext> mockContext { get; set; }

        public ProductServiceTest()
        {
            mockContext = new Mock<CommercePlatformContext>();

            var mockSetProducts = new Mock<DbSet<Data.Models.Product.Product>>();

            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.Provider).Returns(mockSetProducts.Provider);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);
            mockContext.SetupAllProperties();
            mockContext.Verify();

            ProductService = Container.GetInstance<ProductService>();
        }

        [Fact]
        public void ProductService_AddValidProduct_ShouldReturnAddedProduct()
        {
            
            var product = new Data.Models.Product.Product
            {
                Name = "TestVideo_1",
                ProductMembershipValue = 0,
                ProductCategory = RefProductCategory.Video,
                ProductForm = RefProductForm.Physical,
                UnitCost = 10.99M
            };


            using (TransactionScope transactionScope = new TransactionScope())
            {
                //Act
                ProductService.AddProduct(product);

                //Assert
                var result = ProductService.GetAllProducts();
                result.Should().NotBeNullOrEmpty();
                result.Should().Contain(product);
            }
        }

        [Fact]
        public void ProductService_DeleteValidProduct_ShouldReturnNoProducts()
        {

            var product = new Data.Models.Product.Product
            {
                Name = "TestVideo_1",
                ProductMembershipValue = 0,
                ProductCategory = RefProductCategory.Video,
                ProductForm = RefProductForm.Physical,
                UnitCost = 10.99M
            };

            using (TransactionScope transactionScope = new TransactionScope())
            {

                //Act
                ProductService.AddProduct(product);


                //Assert
                var result = ProductService.GetAllProducts();
                result.Should().BeNullOrEmpty();
                result.Should().NotContain(product);
            }
        }
    }
}