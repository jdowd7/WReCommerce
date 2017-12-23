using System.Data.Entity;
using System.Linq;
using FluentAssertions;
using Moq;
using WReCommerce.Common.Enums;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Models.ProductType;
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
            mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);

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

            //Act
            ProductService.AddProduct(product);


            //Assert
            //mockContext.Verify(mc => mc.Products.Contains(product));
            mockContext.Verify();
            var result = mockContext.Object.Products.Any();
            result.Should().BeTrue();
        }
    }
}