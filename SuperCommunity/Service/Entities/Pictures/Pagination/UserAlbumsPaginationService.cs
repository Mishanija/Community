

using SuperCommunity.DAO.Pictures.Pagination;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Pagination;

namespace SuperCommunity.Service.Entities.Pictures.Pagination
{
    public class UserAlbumsPaginationService : PaginationService<Picture, UserAlbumsPaginationFinder>
    {
        public UserAlbumsPaginationService(int albumId, int paginationSize = 12)
            : base(new UserAlbumsPaginationFinder(albumId), paginationSize)
        {
        }
    }
}