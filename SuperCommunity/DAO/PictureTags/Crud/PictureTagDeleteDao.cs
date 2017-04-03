using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.PictureTags.Crud
{
    public class PictureTagDeleteDao : DeleteDao<PictureTag>
    {
        public PictureTagDeleteDao()
        {
            Table = Db.PictureTags;
        }



        /// <summary>
        /// Удаляет указанные pictureTag по их переданным
        /// id.  
        /// </summary>
        public void DeleteListOfPictureTags(List<int> pictureTagIds)
        {
            foreach (var pictureTagId in pictureTagIds)
            {
                DeleteObject(Table.Single(n => n.PictureTagId == pictureTagId));
            }
        }

        public List<PictureTag> GetPictureTagsByPictureId(int pictureId)
        {
            return (from pictureTag in Table where pictureTag.PictureId == pictureId select pictureTag).ToList();
        }

    }
}