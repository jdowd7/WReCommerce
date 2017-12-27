using System.Collections.Generic;
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
using WReCommerce.Data.Interfaces.Userprofile;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Test.Infrastructure;
using Xunit;

namespace WReCommerce.Test.Integration.Core.Services.PurchaseOrder
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
            var mockSetPurchaseOrders= new Mock<DbSet<Data.Models.PurchaseOrder.PurchaseOrder>>();
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
        public void PurchaseOrderRequestService_AddValidProductUserRequest_ShouldReturnTrackingMembership()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                // Set up and add a book and membership
                var productBook = new Data.Models.Product.Product
                {
                    Name = "TestBook1",
                    ProductMembershipValue = 0,
                    ProductCategory = RefProductCategory.Book,
                    ProductForm = RefProductForm.Physical,
                    UnitCost = 10.99M,
                    Weight = 1.00M

                };

                var productInput1 = ProductService.AddProduct(productBook);

                var productMem = new Data.Models.Product.Product
                {
                    Name = "TestMembership3",
                    ProductMembershipValue = 90, // 90 days
                    ProductCategory = RefProductCategory.Video,
                    ProductForm = RefProductForm.Membership,
                    UnitCost = 30.00M
                };

                var productInput2 = ProductService.AddProduct(productMem);

                #region maybe use later
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

                #endregion

                // Set up and add a user 
                var user = new Userprofile
                {
                    FirstName = "testF",
                    LastName = "testL",
                    Email = "testEmail1@gmail.com"
                };

                var userprofileInput = UserprofileRepository.AddUserprofile(user);

                // Setup DTO orderRequest, 1 video membership and 2 books
                var orderReq = new OrderRequest
                {
                    UserprofileId = userprofileInput.Id,
                    ProductIds = new Dictionary<Data.Models.Product.Product, int>
                    {
                        { productInput1, 2 },
                        { productInput2, 1 }
                    }
                };

                //Act
                var result = PurchaseOrderRequestService.AddPurchaseOrderRequest(orderReq);

                //Assert
                result.Success.Should().BeTrue();

                // check business reqs on shipment
                result.PurchaseOrder.PurchaseOrderShipments.Should().NotBeEmpty();
                result.PurchaseOrder.PurchaseOrderShipments.FirstOrDefault()?.TrackingNumber.Should().HaveLength(32);
                
                // check business reqs on membership
                result.PurchaseOrder.Userprofile.UserMemberships.Should().NotBeEmpty();
                result.PurchaseOrder.Userprofile.UserMemberships.FirstOrDefault()?.MembershipRemaining.Should().Be(90);
            }

     
        }
    }
}