using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.UserProfiles.Crud
{
    public class FindUserProfileDao : FindDao<UserProfile>
    {
        public FindUserProfileDao()
        {
            Table = Db.UserProfiles;
        }

        public override UserProfile GetObjectById(int id)
        {
            return (from user in Table where user.UserId == id select user).First();
        }

        /// <summary>
        /// Находит id пользователя по его имени 
        /// (имя пользователя в системе уникальное)
        /// </summary>
        public int FindUserIdByUserName(string userName)
        {
            return (from user in Table where user.UserName == userName select user.UserId).FirstOrDefault();
        }
    }
}