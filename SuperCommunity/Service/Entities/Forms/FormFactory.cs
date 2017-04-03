
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Service.Entities.Forms
{
    public class FormFactory : IService
    {
        public Form BuildNewForm(string userName)
        {
            return new Form { UserId = new FindUserProfileDao().FindUserIdByUserName(userName), 
                MyPhoto = "NoPhoto.jpg" };
        }
    }
}