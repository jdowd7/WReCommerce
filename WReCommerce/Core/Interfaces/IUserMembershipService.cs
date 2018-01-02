using WReCommerce.Data.Models.Userprofile;

namespace WReCommerce.Core.Interfaces
{
    public interface IUserMembershipService
    {
        UserMembership GetUserMembership(int userMembershipId);
        UserMembership AddUserMembership(UserMembership userMembership);
        UserMembership UpdateUserMembership(int userMembershipId, UserMembership userMembership);
        bool DeleteUserMembership(int userMembershipId);

    }
}