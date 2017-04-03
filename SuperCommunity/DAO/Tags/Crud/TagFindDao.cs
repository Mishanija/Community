using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Tags.Crud
{
    public class TagFindDao : FindDao<Tag>
    {
        public TagFindDao()
        {
            Table = Db.Tags;
        }

        public override Tag GetObjectById(int id)
        {
            return (from tag in Table where tag.TagId == id select tag).FirstOrDefault();
        }

        /// <summary>
        /// Дает список имен всех существующих в базе тэгов
        /// </summary>
        public List<Tag> GetAllTags()
        {
            return (from tag in Table select tag).ToList();
        }

        /// <summary>
        /// Дает id по имени тэга, если тэг с таким именем существует
        /// </summary>
        public int GetTagIdByTagName(string tagName)
        {
            return (from tag in Table where tag.TagName == tagName select tag.TagId).FirstOrDefault();
        }
    }
}