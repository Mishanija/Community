using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Pictures.Crud
{
    public class PictureFindDao : FindDao<Picture>
    {
        public PictureFindDao()
        {
            Table = Db.Pictures;
        }

        public override Picture GetObjectById(int id)
        {
            return (from picture in Table where picture.PictureId == id select picture).FirstOrDefault();
        }
        
        /// <summary>
        /// Дает id картинки по его url (относительная ссылка на картинку)
        /// </summary>
        public int GetPictureIdByPictureUrl(string pictureUrl)
        {
            return
                (from picture in Table where picture.PictureUrl == pictureUrl select picture.PictureId).FirstOrDefault();
        }
    }
}