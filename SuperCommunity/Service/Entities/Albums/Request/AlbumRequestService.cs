using SuperCommunity.DAO.Albums.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Request;

namespace SuperCommunity.Service.Entities.Albums.Request
{
    public class AlbumRequestService : RequestService<Album>
    {
        public override bool IsBadRequest(Album album, string userName)
        {
            return album == null || !new Security().CheckUser(album.UserId, userName);
        }

        public bool IsBadRequest(int albumId, string userName)
        {
            return IsBadRequest(new FindAlbumDao().GetObjectById(albumId), userName);
        }
    }
}