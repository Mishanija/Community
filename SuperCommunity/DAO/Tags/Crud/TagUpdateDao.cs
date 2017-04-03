using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Tags.Crud
{
    public class TagUpdateDao : UpdateDao<Tag>
    {
        public TagUpdateDao()
        {
            Table = Db.Tags;
        }
    }
}