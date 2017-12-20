namespace WReCommerce.Data.Interfaces.Userprofile.UserMembership
{
    public interface IUserMembershipRepository
    {
        Models.Userprofile.UserMembership Get(int userprofileId);
        Models.Userprofile.UserMembership AddUserMembership(Models.Userprofile.UserMembership userprofile);
        Models.Userprofile.UserMembership UpdateUserMembership(int userprofileId, Models.Userprofile.UserMembership userprofile);
        bool DeleteUserMembership(int userprofileId);


    }
}