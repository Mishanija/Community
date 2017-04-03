using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.PictureTags.Crud
{
    public class PictureTagFindDao : FindDao<PictureTag>
    {
        public PictureTagFindDao()
        {
            Table = Db.PictureTags;
        }

        public int GetPicturesCount(int tagId)
        {
            return (from pictureTag in Table where pictureTag.TagId == tagId select pictureTag.TagId).Count();
        }

        public List<int> GetPictureIdsByTagId(int tagId)
        {
            return (from pictureTag in Table where pictureTag.TagId == tagId select pictureTag.PictureId).ToList();
        }

        public List<int> GetPictureTagIdsByTagId(int tagId)
        {
            return (from pictureTag in Table where pictureTag.TagId == tagId select pictureTag.PictureTagId).ToList();
        }

        public override PictureTag GetObjectById(int id)
        {
            return (from pictureTag in Table where pictureTag.PictureTagId == id select pictureTag).FirstOrDefault();
        }

        /// <summary>
        /// Все существующие id тэгов к картинке (PictureTag.pictureTagId) с указанным id  
        /// </summary>
        public List<PictureTag> GetPictureTagsForPicture(int pictureId)
        {
            return (from pictureTag in Table where pictureTag.PictureId == pictureId select pictureTag).ToList();
        }


    }
}