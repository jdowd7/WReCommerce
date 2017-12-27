using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using FluentAssertions;
using Moq;
using WReCommerce.Common.DTO;
using WReCommerce.Common.Enums;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.EntityFramework.Repository.Product;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Interfaces.Userprofile;
using WReCommerce.Data.Models.Address;
using WReCommerce.Data.Models.ProductType;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Domain.Business.Models.PurchaseOrder;
using WReCommerce.Test.Infrastructure;
using Xunit;

namespace WReCommerce.Test.Integration.Core.Services.Product
{
    public class PurchaseOrderRequestServiceTest : TestContainer
    {
        public IPurchaseOrderRequestService PurchaseOrderRequestService { get; set; }

        public IProductService ProductService { get; set; }

        // did this for brevity, you would use the service level
        public IUserprofileRepository UserprofileRepository { get; set; }

        public Mock<CommercePlatformContext> mockContext { get; set; }

        public PurchaseOrderRequestServiceTest()
        {
            mockContext = new Mock<CommercePlatformContext>();

            var mockSetProducts = new Mock<DbSet<Data.Models.Product.Product>>();
            var mockSetPurchaseOrders= new Mock<DbSet<PurchaseOrder>>();
            var mockSetUserprofiles = new Mock<DbSet<Userprofile>>();

            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.Provider).Returns(mockSetProducts.Provider);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            //mockSetProducts.As<IQueryable<Data.Models.Product.Product>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);
            mockContext.Setup(m => m.PurchaseOrders).Returns(mockSetPurchaseOrders.Object);
            mockContext.Setup(m => m.Userprofiles).Returns(mockSetUserprofiles.Object);
            mockContext.SetupAllProperties();
            mockContext.Verify();

            UserprofileRepository = Container.GetInstance<IUserprofileRepository>();
            PurchaseOrderRequestService = Container.GetInstance<PurchaseOrderRequestService>();
            ProductService = Container.GetInstance<ProductService>();
        }

        [Fact]
        public void ProductService_AddValidProduct_ShouldReturnAddedProduct()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                var product = new Data.Models.Product.Product
                {
                    Name = "TestVideo_1",
                    ProductMembershipValue = 0,
                    ProductCategory = RefProductCategory.Video,
                    ProductForm = RefProductForm.Membership,
                    UnitCost = 10.99M
                };

                ProductService.AddProduct(product);

                //var addBill = new AddressBilling
                //{
                //    Street1 = "1000 Test Dr.",
                //    Street2 = "",
                //    City = "Test1City",
                //    State = RefState.AL,
                //    Zip = 01234
                //};

                //var addShip = new AddressShipping
                //{
                //    Street1 = "1000 Test Dr.",
                //    Street2 = "",
                //    City = "Test1City",
                //    State = RefState.AL,
                //    Zip = 01234
                //};

                var user = new Userprofile
                {
                    FirstName = "testF",
                    LastName = "testL",
                    Email = "testEmail1@gmail.com"
                };

                var 



            var orderReq = new OrderRequest
            {

                
            };


                //Act


                //Assert
                var result = ProductService.GetAllProducts();
                result.Should().NotBeNullOrEmpty();
            }

     
        }
    }
}