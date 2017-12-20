namespace WReCommerce.Data.Interfaces.Userprofile
{
    public interface IUserprofileRepository
    {
        Models.Userprofile.Userprofile Get(int userprofileId);
        Models.Userprofile.Userprofile AddUserprofile(Models.Userprofile.Userprofile userprofile);
        Models.Userprofile.Userprofile UpdateUserprofile(int userprofileId, Models.Userprofile.Userprofile userprofile);
        bool DeleteUserprofile(int userprofileId);


    }
}