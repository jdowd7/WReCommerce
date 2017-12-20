using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Address;
using WReCommerce.Data.Models.Address;

namespace WReCommerce.Data.EntityFramework.Repository.Address
{
    public class AddressShippingRepository : IAddressShippingRepository
    {
        private CommercePlatformContext _context { get; set; }

        public AddressShippingRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public AddressShipping GetBillingAddress(int addressId)
        {
            throw new System.NotImplementedException();
        }

        public AddressShipping AddBillingAddress(AddressShipping addressShipping)
        {
            throw new System.NotImplementedException();
        }

        public AddressShipping UpdateBillingAddress(int addressId, AddressShipping addressShipping)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteBillingAddress(int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}