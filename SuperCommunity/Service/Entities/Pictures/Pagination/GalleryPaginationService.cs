
using SuperCommunity.DAO.Pictures.Pagination;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Pagination;

namespace SuperCommunity.Service.Entities.Pictures.Pagination
{
    public class GalleryPaginationService 
        : PaginationService<Picture, GalleryPaginationFinder>
    {
        public GalleryPaginationService
            (int tagId, int paginationSize = 12)
            : base(new GalleryPaginationFinder(tagId), paginationSize)
        {
        }
    }
}