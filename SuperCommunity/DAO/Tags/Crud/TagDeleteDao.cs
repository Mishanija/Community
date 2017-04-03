using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Tags.Crud
{
    public class TagDeleteDao : DeleteDao<Tag>
    {
        public TagDeleteDao()
        {
            Table = Db.Tags;
        }

        public void DeleteTag(int tagId)
        {
            var tag = Table.Single(t => t.TagId == tagId);

            if (tag != null)
            {
                DeleteObject(tag);
            }
        }
    }
}