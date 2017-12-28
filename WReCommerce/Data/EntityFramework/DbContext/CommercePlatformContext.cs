using System.Data.Entity;
using WReCommerce.Data.Models.Address;
using WReCommerce.Data.Models.Product;
using WReCommerce.Data.Models.ProductType;
using WReCommerce.Data.Models.PurchaseOrder;
using WReCommerce.Data.Models.Userprofile;

namespace WReCommerce.Data.EntityFramework.DbContext
{
    public class CommercePlatformContext : System.Data.Entity.DbContext
    {
        public virtual DbSet<AddressBilling> AddressBillings { get; set; }
        public virtual DbSet<AddressShipping> AddressShippings { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RefProductType> RefProductTypes { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual DbSet<PurchaseOrderShipment> PurchaseOrderShipments { get; set; }
        public virtual DbSet<UserMembership> UserMemberships { get; set; }
        public virtual DbSet<Userprofile> Userprofiles { get; set; }

        public CommercePlatformContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    }
}