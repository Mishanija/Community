

using System.Web.Mvc.Ajax;

namespace SuperCommunity.HtmlHelpers.DataObjects
{
    public class AjaxLinksDataObject
    {
        public int PageNumber;

        public int PagesCount;

        public AjaxOptions AjaxOptions;

        public string ActionName;

        public string ControllerName;

        public object HtmlAttrebutes;

        public AjaxPaginationLinkRouteValues RouteValues;

    }
}