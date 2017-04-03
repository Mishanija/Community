using SuperCommunity.DAO.UserInfo.Crud;
using SuperCommunity.Models;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Email;
using WebMatrix.WebData;

namespace SuperCommunity.Service.Entities.Account
{
    public class AccountRegistrationService
    {
        public void ToRegisterUser(RegisterModel model)
        {
            string confirmationToken = WebSecurity.CreateUserAndAccount(model.UserName, model.Password, null, true);

            new RegistrationEmail(model.Email, model.UserName, model.Password, confirmationToken);

            new CreateUserInfoDao().SaveObject(new InfoUser
            { UserId = WebSecurity.GetUserId(model.UserName), 
                    Email = model.Email }
                    );

        }
    }
}