using System;
using Moq;
using SimpleInjector;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.EntityFramework.Repository.Product;
using WReCommerce.Data.EntityFramework.Repository.PurchaseOrder;
using WReCommerce.Data.EntityFramework.Repository.Userprofile;
using WReCommerce.Data.EntityFramework.Repository.Userprofile.UserMembership;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Interfaces.PurchaseOrder;
using WReCommerce.Data.Interfaces.Userprofile;
using WReCommerce.Data.Interfaces.Userprofile.UserMembership;

namespace WReCommerce.Test.Infrastructure
{
    
    public class TestContainer : IDisposable
    {
        public Container Container { get; set; }

        public TestContainer()
        {
            Container = new Container();
            var lifeStyle = Lifestyle.Singleton;

            // services
            Container.Register<IProductService, ProductService>();
            Container.Register<IPurchaseOrderRequestService, PurchaseOrderRequestService>();
            Container.Register<IUserprofileService, UserprofileService>();

            // repos
            Container.Register<IProductRepository, ProductRepository>();
            Container.Register<IUserprofileRepository, UserprofileRepository>();
            Container.Register<IUserMembershipRepository, UserMembershipRepository>();
            Container.Register<IPurchaseOrderShipmentRepository, PurchaseOrderShipmentRepository>();
            Container.Register<IPurchaseOrderRequestRepository, PurchaseOrderRequestRepository>();

        }

        private static Container GetAutoMockingContainer()
        {
            var container = new Container();

            container.ResolveUnregisteredType += (s, e) =>
            {
                if (typeof(Mock).IsAssignableFrom(e.UnregisteredServiceType))
                {
                    e.Register(Lifestyle.Singleton.CreateRegistration(
                        e.UnregisteredServiceType,
                        () => Activator.CreateInstance(e.UnregisteredServiceType), container));
                }
                else if (e.UnregisteredServiceType.IsInterface)
                {
                    var mockType = typeof(Mock<>).MakeGenericType(e.UnregisteredServiceType);
                    e.Register(() => ((Mock)container.GetInstance(mockType)).Object);
                }
            };
            return container;
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources used and optionally releases the managed resources as well.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Container.Dispose();
            }
        }
    }
}

