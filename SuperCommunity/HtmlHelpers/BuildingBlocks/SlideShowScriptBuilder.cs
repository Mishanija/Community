using System.Web.Mvc;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public static class SlideShowScriptBuilder
    {
        public static TagBuilder BuildSlideShowScript(string wraperId)
        {
            return new TagBuilder("script")
            {
                InnerHtml =
                    "jQuery(window).load(go); function go() {jQuery('#"
                    + wraperId + " .magnifier').touchTouch('"
                    + wraperId + "');}"
            };
        }
    }
}