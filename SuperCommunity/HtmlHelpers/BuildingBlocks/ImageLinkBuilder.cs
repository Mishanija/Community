

using System.Web.Mvc;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public class ImageLinkBuilder
    {
        private readonly string _htmlClass;

        public ImageLinkBuilder(string htmlClass = "")
        {
            _htmlClass = htmlClass;
        }

        public TagBuilder SimpleImageLink(string aHref, string imgSrc)
        {
            var link = BuildLink(aHref);

            link.InnerHtml = BuildImageTag(imgSrc).ToString();

            return link;
        }

        private TagBuilder BuildLink(string aHref)
        {
            var tag = new TagBuilder("a");

            tag.MergeAttribute("href", aHref);

            tag.MergeAttribute("class", _htmlClass);

            return tag;
        }

        private TagBuilder BuildImageTag(string imgSrc)
        {
            var tag = new TagBuilder("img");

            tag.MergeAttribute("src", imgSrc);

            tag.MergeAttribute("class", "mediumPicture");

            return tag;
        }
    }
}