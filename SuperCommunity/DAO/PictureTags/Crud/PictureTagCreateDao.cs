using System.Collections.Generic;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.PictureTags.Crud
{
    public class PictureTagCreateDao : CreateDao<PictureTag>
    {
        public PictureTagCreateDao()
        {
            Table = Db.PictureTags;
        }

        public void CreateTagsForPicture(int pictureId, List<int> tagsId)
        {
            foreach (var tagId in tagsId)
            {
                SaveObject(new PictureTag { PictureId = pictureId, TagId = tagId });
            }
        }

    }
}