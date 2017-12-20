using WReCommerce.Data.EntityFramework.DbContext;
using WReCommerce.Data.Interfaces.Userprofile;

namespace WReCommerce.Data.EntityFramework.Repository.Userprofile
{
    public class UserprofileRepository : IUserprofileRepository
    {
        private CommercePlatformContext _context { get; set; }

        public UserprofileRepository(CommercePlatformContext context)
        {
            _context = context;
        }


        public Models.Userprofile.Userprofile Get(int userprofileId)
        {
            throw new System.NotImplementedException();
        }

        public Models.Userprofile.Userprofile AddUserprofile(Models.Userprofile.Userprofile userprofile)
        {
            throw new System.NotImplementedException();
        }

        public Models.Userprofile.Userprofile UpdateUserprofile(int userprofileId, Models.Userprofile.Userprofile userprofile)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUserprofile(int userprofileId)
        {
            throw new System.NotImplementedException();
        }
    }
}