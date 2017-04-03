
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SuperCommunity.HtmlHelpers.BuildingBlocks;
using SuperCommunity.HtmlHelpers.DataObjects;
using SuperCommunity.Models;
using SuperCommunity.Models.Entities;

namespace SuperCommunity.HtmlHelpers.Solutions
{
    public static class AlbumSlideShow
    {
        private const string ActionName = "AlbumPage";

        private const string ControllerName = "Album";

        private static readonly ImageLinkBuilder LinksBuilderBuilder = new ImageLinkBuilder("magnifier");

        private static int _albumId;

        public static MvcHtmlString BuildAlbumSlideShow(this AjaxHelper helper,
            PaginationModel<ImageReadModel> model,
            int albumId)
        {
            Initialization(albumId);

            return new MvcHtmlString(BuildHtml(model, helper) + BuildScript(_albumId + ""));
        }

        private static string BuildScript(string wraperId)
        {
            return SlideShowScriptBuilder.BuildSlideShowScript(wraperId).ToString();
        }

        private static void Initialization(int albumId)
        {
            _albumId = albumId;
        }

        private static string BuildHtml(PaginationModel<ImageReadModel> model, AjaxHelper helper)
        {
            var gallery = new TagBuilder("div");
            gallery.MergeAttribute("id", _albumId + "");

            gallery.InnerHtml =
                BuildAjaxLink(helper, model.PageNumber, model.PagesCount) + " " +
                BuildRowDiv(model.ObjectsList) + " " +
                BuildSlider(model.ObjectsList.Count);

            return gallery.ToString();
        }



        private static string BuildAjaxLink(AjaxHelper helper, int pageNumber, int pagesCount)
        {
            var dataObject = new AjaxLinksDataObject
            {
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                ActionName = ActionName,
                ControllerName = ControllerName,
                AjaxOptions = new AjaxOptions { UpdateTargetId = _albumId + "", OnSuccess = "go" },
                HtmlAttrebutes = new { @class = "btn chooseButton" },
                RouteValues = new AlbumRouteValues(_albumId)
            };

            return AjaxNavigationLinks.BuildPaginationLinks(helper, dataObject).ToString();
        }

        private static string BuildRowDiv(IEnumerable<ImageReadModel> pictures)
        {
            // shared
            var row = new TagBuilder("div");
            row.MergeAttribute("class", "row");
            row.MergeAttribute("style", "margin-top: 40px");
            // shared

            row.InnerHtml = BuildUl(pictures);

            return row.ToString();
        }

        private static string BuildSlider(int size)
        {
            return GallerySlider.BuildSlider(size, _albumId + "").ToString();
        }

        private static string BuildUl(IEnumerable<ImageReadModel> pictures)
        {
            // shared
            var listOfImages = new TagBuilder("ul");
            listOfImages.MergeAttribute("class", "portfolio clearfix");
            //shared

            listOfImages.InnerHtml = AddAllPictures(pictures);

            return listOfImages.ToString();
        }

        private static string AddAllPictures(IEnumerable<ImageReadModel> pictures)
        {
            var images = new StringBuilder();

            foreach (var picture in pictures)
            {
                images.Append(BuildLi(picture.PictureUrl));
            }

            return images.ToString();
        }

        private static string BuildLi(string imageUrl)
        {
            var imageSrc = "/Images/UserPhotos/" + imageUrl;

            var liImage = new TagBuilder("li")
            {
                InnerHtml = LinksBuilderBuilder.SimpleImageLink(imageSrc, imageSrc).ToString()
            };

            return liImage.ToString();
        }
    }
}