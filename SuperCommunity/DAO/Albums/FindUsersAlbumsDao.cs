using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Albums
{
    public class FindUsersAlbumsDao : DataEntitiesDao<Album>
    {
        public FindUsersAlbumsDao()
        {
            Table = Db.Albums;
        }

        /// <summary>
        /// Находит все альбомы-объекты пользователя с данным id
        /// </summary>
        public List<Album> GetAllAlbumsByUserId(int userId)
        {
            return (from album in Table where album.UserId == userId select album).ToList();
        }

        /// <summary>
        /// Находит id владельца альбома с аргументом pictureId
        /// </summary>
        public int FindUserIdByAlbumId(int albumId)
        {
            return (from album in Table where album.AlbumId == albumId select album.UserId).First();
        }
        
    }
}