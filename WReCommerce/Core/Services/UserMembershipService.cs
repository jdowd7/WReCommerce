using WReCommerce.Core.Interfaces;
using WReCommerce.Data.Interfaces.Userprofile.UserMembership;
using WReCommerce.Data.Models.Userprofile;

namespace WReCommerce.Core.Services
{
    public class UserMembershipService : IUserMembershipService
    {
        public IUserMembershipRepository UserMembershipRepository { get; set; }

        public UserMembershipService(IUserMembershipRepository userMembershipRepository)
        {
            UserMembershipRepository = userMembershipRepository;
        }

        public UserMembership GetUserMembership(int userMembershipId)
        {
            throw new System.NotImplementedException();
        }

        public UserMembership AddUserMembership(UserMembership userMembership)
        {
            return UserMembershipRepository.AddUserMembership(userMembership);
        }

        public UserMembership UpdateUserMembership(int userMembershipId, UserMembership userMembership)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUserMembership(int userMembershipId)
        {
            throw new System.NotImplementedException();
        }
    }
}