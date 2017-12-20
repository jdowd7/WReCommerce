using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Address;

namespace WReCommerce.Data.EntityFramework.Repository.Address
{
    public class AddressShippingRepository : IAddressShippingRepository
    {
        private CommercePlatformContext _context { get; set; }

        public AddressShippingRepository(CommercePlatformContext context)
        {
            _context = context;
        }
    }
}