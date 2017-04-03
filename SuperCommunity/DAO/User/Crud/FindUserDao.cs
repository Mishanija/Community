using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.User.Crud
{
    public class FindUserDao : FindDao<webpages_Membership>
    {

        public FindUserDao()
        {
            Table = Db.webpages_Membership;
        }

        public override webpages_Membership GetObjectById(int id)
        {
            return (from member in Table where member.UserId == id select member).First();
        }

    }
}