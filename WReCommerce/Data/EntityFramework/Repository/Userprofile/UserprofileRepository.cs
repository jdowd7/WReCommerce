using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.Userprofile
{
    public class UserprofileRepository
    {
        private CommercePlatformContext _context { get; set; }

        public UserprofileRepository(CommercePlatformContext context)
        {
            _context = context;
        }


    }
}