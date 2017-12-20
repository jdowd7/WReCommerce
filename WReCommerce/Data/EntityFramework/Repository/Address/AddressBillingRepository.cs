using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Address;

namespace WReCommerce.Data.EntityFramework.Repository.Address
{
    public class AddressBillingRepository : IAddressBillingRepository
    {
        private CommercePlatformContext _context { get; set; }

        public AddressBillingRepository(CommercePlatformContext context)
        {
            _context = context;
        }

    }
}