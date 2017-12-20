using WReCommerce.Data.EntityFramework.DbContext;

namespace WReCommerce.Data.EntityFramework.Repository.Userprofile.UserMembership
{
    public class UserMembershipRepository
    {
        private CommercePlatformContext _context { get; set; }

        public UserMembershipRepository(CommercePlatformContext context)
        {
            _context = context;
        }

    }
}