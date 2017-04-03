

using SuperCommunity.DAO.UserProfiles.Crud;

namespace SuperCommunity.Service.Request
{
    public class Security : IService
    {
        public bool CheckUser(int userOwnerId, string currentUserName)
        {
            if (userOwnerId != new FindUserProfileDao().FindUserIdByUserName(currentUserName))
            {
                return false;
            }
            return true;
        }
    }
}