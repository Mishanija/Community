using System.Collections.Generic;
using System.Linq;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Pagination;

namespace SuperCommunity.DAO.Pictures.Pagination
{
    public class UserAlbumsPaginationFinder : PaginationFinder<Picture>
    {
        private readonly int _albumId;

        public UserAlbumsPaginationFinder(int albumId)
        {
            Table = Db.Pictures;
            _albumId = albumId;
        }

        public override List<Picture> GetPageList(int skip, int take)
        {
            var pictures = (from element in Table
                where element.AlbumId == _albumId
                orderby element.PictureId descending
                select element);

            ElementsLength = pictures.Count();

            return pictures.
                Skip(skip).
                Take(take).
                ToList();
        }
    }
}