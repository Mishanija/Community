

namespace SuperCommunity.HtmlHelpers.DataObjects
{
    public class AlbumRouteValues : AjaxPaginationLinkRouteValues
    {
        private readonly int _albumId;

        public AlbumRouteValues(int albumId)
        {
            _albumId = albumId;
        }

        public override object BuildRouteObject(int nextPageNumber)
        {
            return new {pageNumber = nextPageNumber, albumId = _albumId};
        }
    }
}