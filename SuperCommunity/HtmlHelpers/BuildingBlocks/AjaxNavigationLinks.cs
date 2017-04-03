using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SuperCommunity.HtmlHelpers.DataObjects;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public static class AjaxNavigationLinks
    {
        private static bool _hasMorePages;

        private static AjaxLinksDataObject _dataObject;

        public static MvcHtmlString BuildPaginationLinks(AjaxHelper helper, 
            AjaxLinksDataObject dataObject)
        {
            Initialization(dataObject);

            var links =
                BackAjaxLink(helper, dataObject.PageNumber) + " " +
                ForwardAjaxLink(helper, dataObject.PageNumber, dataObject.PagesCount);

            return new MvcHtmlString(!_hasMorePages ? "" : links);
        }

        private static void Initialization(AjaxLinksDataObject dataObject)
        {
            _hasMorePages = false;

            _dataObject = dataObject;
        }

        private static string EnabledButton(AjaxHelper helper,
            int nextPageNumber, string textButton)
        {
            _hasMorePages = true;

            var routeValues = _dataObject.RouteValues.BuildRouteObject(nextPageNumber);
            
            return helper.ActionLink(textButton, _dataObject.ActionName, _dataObject.ControllerName,
                routeValues,
                _dataObject.AjaxOptions,
                _dataObject.HtmlAttrebutes).ToString();
        }

        private static string DisabledButton(string textButton)
        {
            var disabledButton = new TagBuilder("a");
            disabledButton.MergeAttribute("class", "btn disabledButton");
            disabledButton.InnerHtml = textButton;

            return disabledButton.ToString();
        }

        private static string ForwardAjaxLink(AjaxHelper helper, int pageNumber, int pagesCount)
        {
            var nextPageNumber = pageNumber + 1;

            return nextPageNumber >= pagesCount ? 
                DisabledButton("Вперед") : 
                EnabledButton(helper, nextPageNumber, "Вперед");
        }

        private static string BackAjaxLink(AjaxHelper helper, int pageNumber)
        {
            var previousPageNumber = pageNumber - 1;

            return previousPageNumber < 0 ? 
                DisabledButton("Назад") : 
                EnabledButton(helper, previousPageNumber, "Назад");
        }


    }
}