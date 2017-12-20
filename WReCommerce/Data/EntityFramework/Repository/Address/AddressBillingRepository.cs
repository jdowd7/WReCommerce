using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Address;
using WReCommerce.Data.Models.Address;

namespace WReCommerce.Data.EntityFramework.Repository.Address
{
    public class AddressBillingRepository : IAddressBillingRepository
    {
        private CommercePlatformContext _context { get; set; }

        public AddressBillingRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public AddressBilling GetBillingAddress(int addressId)
        {
            throw new System.NotImplementedException();
        }

        public AddressBilling AddBillingAddress(AddressBilling addressBilling)
        {
            throw new System.NotImplementedException();
        }

        public AddressBilling UpdateBillingAddress(int addressId, AddressBilling addressBilling)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteBillingAddress(int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}