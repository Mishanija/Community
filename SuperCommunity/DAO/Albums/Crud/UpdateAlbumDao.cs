using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Albums.Crud
{
    public class UpdateAlbumDao : UpdateDao<Album>
    {
        public UpdateAlbumDao()
        {
            Table = Db.Albums;
        }
    }
}