using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Pagination;

namespace SuperCommunity.DAO.Pictures.Pagination
{
    public class GalleryPaginationFinder : PaginationFinder<Picture>
    {
        private readonly int _tagId;

        public GalleryPaginationFinder(int tagId)
        {
            Table = Db.Pictures;
            
            _tagId = tagId;
        }

        public override List<Picture> GetPageList(int skip, int take)
        {
            return _tagId == 0 ? WithoutTag(skip, take) : WithTag(skip, take);
        }

        private List<Picture> WithTag(int skip, int take)
        {
            var pictures = new PictureTagFindDao().GetPictureIdsByTagId(_tagId);

            ElementsLength = pictures.Count;

            if (pictures.Count == 0)
            {
                return new List<Picture>();
            }

            return
                (from element in Table
                    where pictures.Contains(element.PictureId)
                    orderby element.PictureId descending
                    select element).
                    Skip(skip).
                    Take(take).
                    ToList();
        }

        private List<Picture> WithoutTag(int skip, int take)
        {
            var result = (from element in Table orderby element.PictureId descending select element);

            ElementsLength = result.Count();

            return result.
                Skip(skip).
                Take(take).
                ToList();
        }
    }
}