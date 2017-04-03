

using System.Web.Mvc;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public class AjaxLinkBuilder
    {
        public static TagBuilder BuildAjaxLink(string targetId)
        {
           var link = new TagBuilder("a");

            link.MergeAttribute("data-ajax", "true");
            link.MergeAttribute("data-ajax-mode", "replace");
            link.MergeAttribute("data-ajax-update", "#" + targetId);

            return link;
        } 
        
    }
}