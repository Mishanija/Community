
namespace SuperCommunity.HtmlHelpers.DataObjects
{
    public class GalleryRouteValues : AjaxPaginationLinkRouteValues
    {
        private readonly int _tagId;

        public GalleryRouteValues(int tagId)
        {
            _tagId = tagId;
        }

        public override object BuildRouteObject(int nextPageNumber)
        {
            if (_tagId == 0)
            {
                return new {pageNumber = nextPageNumber};
            }
            return new { pageNumber = nextPageNumber, tagId = _tagId };
        }
    }
}