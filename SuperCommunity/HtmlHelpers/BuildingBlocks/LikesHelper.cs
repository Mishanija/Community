
using System.Web.Mvc;
using SuperCommunity.Models.Entities;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public static class LikesHelper
    {
        private const string ControllerName = "Vote";

        public static MvcHtmlString LikeDislike(this AjaxHelper helper, 
            int pictureId, string updateTargetId, 
            VotesModel votesModel)
        {
            var panel = new TagBuilder("div")
            {
                InnerHtml = votesModel.IsOwner
                ? BuildOwnerPanel(votesModel.Likes, votesModel.Dislikes)
                : BuildButtons(votesModel, pictureId)
            };

            panel.MergeAttribute("class", "likesPanel");

            return new MvcHtmlString(panel.ToString());
        }
        
        private static string BuildOwnerPanel(int likes, int dislikes)
        {
            var text = "Ваши оценки: +" + likes + " -" + dislikes;

            var div = new TagBuilder("div");
            div.MergeAttribute("class", "ownerPanel");
            div.MergeAttribute("title", text);

            return div.ToString();
        }

        private static string BuildButtons(VotesModel votesModel, int pictureId)
        {
            var likeButton = BuildButton("Like", votesModel.Likes, pictureId, "likes", "likeButton");

            var dislikeButton = BuildButton("Dislike", votesModel.Dislikes, pictureId, "dislikes", "dislikeButton");

            return likeButton + dislikeButton;
        }

        private static string BuildButton(string actionName, int votes, int pictureId, string voteName, string htmlClass)
        {
            var targetId = voteName + pictureId;

            var span = new TagBuilder("span") 
            {InnerHtml = votes + ""};
            span.MergeAttribute("id", targetId);
            span.MergeAttribute("class", "votesCount");

            var boxDiv = new TagBuilder("div") { InnerHtml = span + "" };
            boxDiv.MergeAttribute("class", actionName + "Box");

            var link = AjaxLinkBuilder.BuildAjaxLink(targetId);
            link.MergeAttribute("href", "/" + ControllerName + "/" + actionName + "?pictureId=" + pictureId);
            link.MergeAttribute("class", htmlClass);

            var div = new TagBuilder("div") { InnerHtml = link + "" + boxDiv };
            div.MergeAttribute("class", actionName + "Panel");


            return div + "";
        }

    }
}