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
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Data.Models.Userprofile;
using WReCommerce.Test.Infrastructure;
using Xunit;

namespace WReCommerce.Test.Integration.Core.Services.PurchaseOrder
{
    public class PurchaseOrderRequestServiceTest : TestContainer
    {
        public IPurchaseOrderRequestService PurchaseOrderRequestService { get; set; }

        public IProductService ProductService { get; set; }

        public IUserprofileService UserprofileService { get; set; }

        public IUserMembershipService UserMembershipService { get; set; }

        public IPurchaseOrderShipmentService PurchaseOrderShipmentService { get; set; }

        public IPurchaseOrderService PurchaseOrderService { get; set; }

        public IPurchaseOrderLineService PurchaseOrderLineService { get; set; }

        public Mock<CommercePlatformContext> mockContext { get; set; }

        public PurchaseOrderRequestServiceTest()
        {

            mockContext = new Mock<CommercePlatformContext>();

            //Database.SetInitializer<CommercePlatformContext>(null);
            mockContext.Object.Configuration.LazyLoadingEnabled = true;


            var mockSetProducts = new Mock<DbSet<Data.Models.Product.Product>>();
            var mockSetPurchaseOrders= new Mock<DbSet<Data.Models.PurchaseOrder.PurchaseOrder>>();
            var mockSetUserprofiles = new Mock<DbSet<Userprofile>>();
            var mockSetUsermembership = new Mock<DbSet<UserMembership>>();
            var mockSetPurchaseOrderShipment = new Mock<DbSet<PurchaseOrderShipment>>();

            mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);
            mockContext.Setup(m => m.PurchaseOrders).Returns(mockSetPurchaseOrders.Object);
            mockContext.Setup(m => m.Userprofiles).Returns(mockSetUserprofiles.Object);
            mockContext.Setup(m => m.PurchaseOrderShipments).Returns(mockSetPurchaseOrderShipment.Object);
            mockContext.Setup(m => m.UserMemberships).Returns(mockSetUsermembership.Object);

            mockContext.SetupAllProperties();
            mockContext.Verify();

            UserprofileService = Container.GetInstance<IUserprofileService>();
            PurchaseOrderRequestService = Container.GetInstance<IPurchaseOrderRequestService>();
            ProductService = Container.GetInstance<IProductService>();
            UserMembershipService = Container.GetInstance<IUserMembershipService>();
            PurchaseOrderShipmentService = Container.GetInstance<IPurchaseOrderShipmentService>();
            PurchaseOrderLineService = Container.GetInstance<IPurchaseOrderLineService>();
            PurchaseOrderService = Container.GetInstance<IPurchaseOrderService>();

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
                    Email = "testEmail1@gmail.com",
                    UserMemberships = new List<UserMembership>(),
                    PurchaseOrders = new List<Data.Models.PurchaseOrder.PurchaseOrder>()
                };

                var userprofileInput = UserprofileService.AddUserprofile(user);

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

                var testUser = UserprofileService.GetUserprofile(orderReq.UserprofileId);

                // check business reqs on shipment
                result.PurchaseOrder.PurchaseOrderShipments.Where(x => x.PurchaseOrderId == result.PurchaseOrder.Id).Should().NotBeEmpty();
                result.PurchaseOrder.PurchaseOrderShipments.FirstOrDefault(x => x.PurchaseOrderId == result.PurchaseOrder.Id)?.TrackingNumber.Should().HaveLength(32);
                
                // check business reqs on membership
                result.PurchaseOrder.Userprofile.UserMemberships.ToList().Should().NotBeEmpty();
                result.PurchaseOrder.Userprofile.UserMemberships.ToList().FirstOrDefault()?.MembershipRemaining.Should().Be(90);
            }

     
        }
    }
}