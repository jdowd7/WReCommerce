using System;
using Moq;
using SimpleInjector;
using WReCommerce.Core.Interfaces;
using WReCommerce.Core.Services;
using WReCommerce.Data.EntityFramework.Repository.Product;
using WReCommerce.Data.EntityFramework.Repository.Userprofile;
using WReCommerce.Data.Interfaces.Product;
using WReCommerce.Data.Interfaces.Userprofile;

namespace WReCommerce.Test.Infrastructure
{
    
    public class TestContainer
    {
        public Container Container { get; set; }

        public TestContainer()
        {
            Container = new Container();
            var lifeStyle = Lifestyle.Scoped;

            Container.Register<IProductService, ProductService>(lifeStyle);
            Container.Register<IProductRepository, ProductRepository>(lifeStyle);
            Container.Register<IUserprofileRepository, UserprofileRepository>(lifeStyle);
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

