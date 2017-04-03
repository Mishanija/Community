

using SuperCommunity.DAO.Albums;
using SuperCommunity.DAO.Pictures.Crud;

namespace SuperCommunity.DAO.Votes
{
    public class VoteOwnerDao : IDao
    {
        public bool CheckOwner(int userId, int pictureId)
        {
            var picture = new PictureFindDao().GetObjectById(pictureId);

            if (picture == null) return false;

            var ownerId = new FindUsersAlbumsDao().FindUserIdByAlbumId(picture.AlbumId);

            return ownerId == userId;
        }
    }
}