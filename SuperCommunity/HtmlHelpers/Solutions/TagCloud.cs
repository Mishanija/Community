
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using SuperCommunity.HtmlHelpers.BuildingBlocks;
using SuperCommunity.Models;
using SuperCommunity.Service.Entities.Tags;

namespace SuperCommunity.HtmlHelpers.Solutions
{
    public static class TagCloud
    {
        private static string _targetId;

        private static string _url;

        private static int _factor = 5;

        private static void Initialization(string targetId, string url)
        {
            _targetId = targetId;

            _url = url;
        }

        public static MvcHtmlString BuildTagCloud(this HtmlHelper helper, TagCloudModel model, string targetId, string url)
        {
            Initialization(targetId, url);
            
            return new MvcHtmlString(BuildHtml(model));
        }

        private static string BuildHtml(TagCloudModel model)
        {
            var wraper = new TagBuilder("div") { InnerHtml = BuildAllPicturesTag() + BuildAllTags(model.TagsList) };

            wraper.MergeAttribute("id", "tagCloud");

            return wraper.ToString();
        }

        private static string BuildAllPicturesTag()
        {
            var tag = AjaxLinkBuilder.BuildAjaxLink(_targetId);

            tag.InnerHtml = "Все фотографии";

            tag.MergeAttribute("href", _url);

            tag.MergeAttribute("class", "tag s5");

            var div = new TagBuilder("div") {InnerHtml = tag.ToString()};

            return div.ToString();
        }

        private static string BuildAllTags(IEnumerable<TagModel> tagsList)
        {
            var result = new StringBuilder();

            foreach (var tagModel in tagsList)
            {
                result.Append(BuildTag(tagModel));
            }

            return result.ToString();
        }

        private static string BuildTag(TagModel model)
        {
            var tag = AjaxLinkBuilder.BuildAjaxLink(_targetId);

            tag.InnerHtml = GetTagInnerHtml(model.Tag.TagName, model.PicturesCount);

            tag.MergeAttribute("href", _url + "?tagId=" + model.Tag.TagId);

            tag.MergeAttribute("class", "tag s" + CalculateSize(model.PicturesCount));

            return tag.ToString();
        }

        private static int CalculateSize(int picturesCount)
        {
            var size = 0;

            while (true)
            {
                if (size*_factor >= picturesCount)
                {
                    if (size <= 10) return size + 1;
                    _factor++;
                    return 10;
                }
                size++;
            }
        }

        private static string GetTagInnerHtml(string tagName, int picturesCount)
        {
            var inner = tagName + "(" + picturesCount + ")";

            return inner;
        }
    }
}