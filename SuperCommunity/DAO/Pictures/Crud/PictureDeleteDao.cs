using System;
using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Pictures.Crud
{
    public class PictureDeleteDao : DeleteDao<Picture>
    {
        public PictureDeleteDao()
        {
            Table = Db.Pictures;
        }

        public List<int> GetPictureIdsInAlbum(int albumId)
        {
            return (from picture in Table where picture.AlbumId == albumId select picture.PictureId).ToList();
        }

        public void DeletePicture(int pictureId)
        {
            var picture = Table.Single(p => p.PictureId == pictureId);

            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Images/UserPhotos/" + picture.PictureUrl);

            DeleteObject(picture);
        }
    }
}