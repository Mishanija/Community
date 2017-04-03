using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Other
{
    public class UserPictureDao : QueryDao
    {
        public List<string> GetAllPicturesUrls(int userId)
        {
            var userAlbums = GetUserAlbumsIdByUserId(userId);

            var result = new List<string>(5);

            foreach (var userAlbum in userAlbums)
            {
                result.AddRange(GetPictureUrlsByAlbumId(userAlbum));
            }

            return result;
        }

        public List<Picture> GetAllUserPictures(int userId)
        {
            var userAlbums = GetUserAlbumsIdByUserId(userId);

            var result = new List<Picture>();

            foreach (var userAlbum in userAlbums)
            {
                result.AddRange((from picture in Db.Pictures where picture.AlbumId == userAlbum select picture).ToList());
            }

            return result;
        }

        private IEnumerable<int> GetUserAlbumsIdByUserId(int userId)
        {
            return (from album in Db.Albums where album.UserId == userId select album.AlbumId).ToList();
        }

        private IEnumerable<string> GetPictureUrlsByAlbumId(int albumId)
        {
            return (from picture in Db.Pictures
                    where picture.AlbumId == albumId
                    select picture.PictureUrl).ToList();
        }

    }
}