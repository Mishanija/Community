using SuperCommunity.DAO.Albums;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Request;

namespace SuperCommunity.Service.Entities.Pictures.Request
{
    public class PictureRequestService : RequestService<Picture>
    {
        /// <summary>
        /// Возвращает true, если запрос оказался неверным или у пользователя
        /// недостаточно прав выполнение действия
        /// </summary>
        public override bool IsBadRequest(Picture picture, string userName)
        {
            if (picture == null || !new Security().CheckUser(new FindUsersAlbumsDao().FindUserIdByAlbumId(picture.AlbumId), userName))
            {
                return true;
            }

            return false;
        }
    }
}