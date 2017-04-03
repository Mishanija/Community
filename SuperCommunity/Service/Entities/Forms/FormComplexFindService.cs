

using SuperCommunity.DAO.Forms.Crud;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Service.Entities.Forms
{
    public class FormComplexFindService : IService
    {
        public Form GetFormByUserName(string userName)
        {
            return new FindFormDao().GetFormByUserId(
                new FindUserProfileDao().FindUserIdByUserName(userName));
        }
    }
}