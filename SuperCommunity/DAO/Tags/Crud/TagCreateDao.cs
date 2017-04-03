using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Tags.Crud
{
    public class TagCreateDao : CreateDao<Tag>
    {
        public TagCreateDao()
        {
            Table = Db.Tags;
        }


    }
}