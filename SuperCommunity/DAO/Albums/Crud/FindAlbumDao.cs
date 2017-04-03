using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Albums.Crud
{
    public class FindAlbumDao : FindDao<Album>
    {
        public FindAlbumDao()
        {
            Table = Db.Albums;
        }

        public override Album GetObjectById(int id)
        {
            return (from album in Table where album.AlbumId == id select album).FirstOrDefault();
        }


    }
}