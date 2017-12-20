using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Userprofile.UserMembership;

namespace WReCommerce.Data.EntityFramework.Repository.Userprofile.UserMembership
{
    public class UserMembershipRepository : IUserMembershipRepository
    {
        private CommercePlatformContext _context { get; set; }

        public UserMembershipRepository(CommercePlatformContext context)
        {
            _context = context;
        }

        public Models.Userprofile.UserMembership Get(int userprofileId)
        {
            throw new System.NotImplementedException();
        }

        public Models.Userprofile.UserMembership AddUserMembership(Models.Userprofile.UserMembership userprofile)
        {
            throw new System.NotImplementedException();
        }

        public Models.Userprofile.UserMembership UpdateUserMembership(int userprofileId, Models.Userprofile.UserMembership userprofile)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUserMembership(int userprofileId)
        {
            throw new System.NotImplementedException();
        }
    }
}