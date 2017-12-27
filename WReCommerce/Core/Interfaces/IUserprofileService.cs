using WReCommerce.Data.Models.Userprofile;

namespace WReCommerce.Core.Interfaces
{
    public interface IUserprofileService
    {
        Userprofile GetUserprofile(int userprofileId);
        Userprofile AddUserprofile(Userprofile userprofile);
    }
}