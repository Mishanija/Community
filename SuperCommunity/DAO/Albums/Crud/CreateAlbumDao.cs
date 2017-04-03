using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Albums.Crud
{
    public class CreateAlbumDao : CreateDao<Album>
    {
        public CreateAlbumDao()
        {
            Table = Db.Albums;
        }

    }
}