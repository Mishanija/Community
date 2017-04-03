using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.UserInfo.Crud
{
    public class CreateUserInfoDao : CreateDao<InfoUser>
    {
        public CreateUserInfoDao()
        {
            Table = Db.InfoUsers;
        }

    }
}