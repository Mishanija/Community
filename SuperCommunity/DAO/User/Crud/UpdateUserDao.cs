using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.User.Crud
{
    public class UpdateUserDao : UpdateDao<webpages_Membership>
    {
        public UpdateUserDao()
        {
            Table = Db.webpages_Membership;
        }

        public webpages_Membership FindUserByConfirmationToken(string confirmationToken)
        {
            return (from user in Table where user.ConfirmationToken == confirmationToken select user).First();
        }
    }
}