using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SuperCommunity.HtmlHelpers.BuildingBlocks;
using SuperCommunity.HtmlHelpers.DataObjects;
using SuperCommunity.Models;
using SuperCommunity.Models.Entities;

namespace SuperCommunity.HtmlHelpers.Solutions
{
    public static class GallerySlideshow
    {
        private const string ActionName = "Gallery";

        private const string ControllerName = "User";

        private static readonly ImageLinkBuilder LinksBuilderBuilder = new ImageLinkBuilder("magnifier");

        private static PaginationModel<ImageLikesModel> _model;

        private static int _tagId;

        private static string _targetId;

        public static MvcHtmlString BuildGallery(this AjaxHelper helper, 
            PaginationModel<ImageLikesModel> model, int tagId, string targetId)
        {
            Initialization(model, tagId, targetId);

            return new MvcHtmlString(BuildHtml(helper) + BuildScript(ActionName));
        }

        private static void Initialization(PaginationModel<ImageLikesModel> model, int tagId, string targetId)
        {
            _model = model;

            _tagId = tagId;

            _targetId = targetId;
        }

        private static string BuildScript(string wraperId)
        {
            return SlideShowScriptBuilder.BuildSlideShowScript(wraperId).ToString();
        }

        private static string BuildHtml(AjaxHelper helper)
        {
            var gallery =
                BuildAjaxLink(helper, _model.PageNumber, _model.PagesCount) + " " +
                BuildRowDiv(helper) + " " +
                BuildSlider(_model.ObjectsList.Count);

            return gallery;
        }

        private static string BuildAjaxLink(AjaxHelper helper, int pageNumber, int pagesCount)
        {
            var dataObject = new AjaxLinksDataObject
            {
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                ActionName = ActionName,
                ControllerName = ControllerName,
                AjaxOptions = new AjaxOptions { UpdateTargetId = _targetId, OnSuccess = "go" },
                HtmlAttrebutes = new { @class = "btn chooseButton" },
                RouteValues = new GalleryRouteValues(_tagId)
                
            };

            return AjaxNavigationLinks.BuildPaginationLinks(helper, dataObject).ToString();
        }

        private static string BuildRowDiv(AjaxHelper helper)
        {
            // shared
            var row = new TagBuilder("div");
            row.MergeAttribute("class", "row");
            row.MergeAttribute("style", "margin-top: 40px");
            // shared

            row.InnerHtml = BuildUl(helper);

            return row.ToString();
        }

        private static string BuildSlider(int size)
        {
            return GallerySlider.BuildSlider(size, _targetId).ToString();
        }

        private static string BuildUl(AjaxHelper helper)
        {
            // shared
            var listOfImages = new TagBuilder("ul");
            listOfImages.MergeAttribute("class", "portfolio clearfix");
            //shared

            listOfImages.InnerHtml = AddAllPictures(helper);

            return listOfImages.ToString();
        }

        private static string AddAllPictures(AjaxHelper helper)
        {
            var images = new StringBuilder();

            foreach (var picture in _model.ObjectsList)
            {
                images.Append(BuildLi(picture,  helper));
            }

            return images.ToString();
        }

        private static string BuildLi(ImageLikesModel pictureModel, AjaxHelper helper)
        {
            var imageSrc = "/Images/UserPhotos/" + pictureModel.ImageModel.PictureUrl;

            var liId = "picture" + pictureModel.ImageModel.PictureId;

            var liImage = new TagBuilder("li")
            {
                InnerHtml = 
                    LinksBuilderBuilder.SimpleImageLink(imageSrc, imageSrc).ToString() +
                    helper.LikeDislike(pictureModel.ImageModel.PictureId, liId, pictureModel.VotesModel)
            };

            liImage.MergeAttribute("id", liId);

            return liImage.ToString();
        }

        

    }
}