using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.Userprofile;
using WReCommerce.Data.Models.Userprofile;

namespace WReCommerce.Core.Services
{
    public class UserprofileService : IUserprofileService
    {
        private IUserprofileRepository _UserprofileRepository { get; set; }

        public UserprofileService(IUserprofileRepository userprofileRepository)
        {
            this._UserprofileRepository = userprofileRepository;
        }

        public Userprofile GetUserprofile(int userprofileId)
        {
            return _UserprofileRepository.Get(userprofileId);
        }

        public Userprofile AddUserprofile(Userprofile userprofile)
        {
            return _UserprofileRepository.AddUserprofile(userprofile);
        }
    }
}