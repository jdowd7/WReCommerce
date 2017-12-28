using System.Linq;
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
            return _context.Userprofiles
                .Include("PurchaseOrders")
                //.Include("PurchaseOrderShipments")
                .Include("UserMemberships")
                .FirstOrDefault(x => x.Id == userprofileId);
        }

        public Models.Userprofile.Userprofile AddUserprofile(Models.Userprofile.Userprofile userprofile)
        {
            var result = _context.Userprofiles.Add(userprofile);
            _context.SaveChanges();
            return result;
        }

        public Models.Userprofile.Userprofile UpdateUserprofile(int userprofileId, Models.Userprofile.Userprofile userprofile)
        {
            var userprofileResult = Get(userprofileId);
            _context.Entry(userprofileResult).CurrentValues.SetValues(userprofile);
            _context.SaveChanges();
            return Get(userprofileId);

        }

        public bool DeleteUserprofile(int userprofileId)
        {
            throw new System.NotImplementedException();
        }
    }
}