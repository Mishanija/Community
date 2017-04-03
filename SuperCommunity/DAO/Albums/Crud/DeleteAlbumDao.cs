using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Albums.Crud
{
    public class DeleteAlbumDao : DeleteDao<Album>
    {
        public DeleteAlbumDao()
        {
            Table = Db.Albums;
        }

        public void DeleteAlbum(int albumId)
        {
            DeleteObject(Table.Single(a => a.AlbumId == albumId));
        }
    }
}