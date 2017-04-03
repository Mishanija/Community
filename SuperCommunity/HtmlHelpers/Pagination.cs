using System.Web.Mvc;

namespace SuperCommunity.HtmlHelpers
{
    public static class Pagination
    {
        private static TagBuilder _forward;

        private static TagBuilder _back;

        public static MvcHtmlString Navigation(this HtmlHelper html, 
            int pageNumber, int pagesCount, string viewUrl, string getParamName)
        {
            InitElements(pageNumber, pagesCount, viewUrl, getParamName);

            return new MvcHtmlString("" + _back + _forward);
        }

        private static void InitElements(int pageNumber, int pagesCount, string viewUrl, string getParamName)
        {
            _forward = InitElement("Вперед");
            _back = InitElement("Назад");

            var url = viewUrl + "?" + getParamName + "=";

            if (pageNumber <= 0)
            {
                DisabledButton(_back);
            }
            else
            {
                EnabledButton(_back, pageNumber - 1, url);
            }

            if (pageNumber >= pagesCount - 1)
            {
                DisabledButton(_forward);
            }
            else
            {
                EnabledButton(_forward, pageNumber + 1, url);
            }
        }

        private static void EnabledButton(TagBuilder tag, int number, string url)
        {
            tag.MergeAttribute("class", "btn chooseButton");
            tag.MergeAttribute("href", url + number);
        }

        private static void DisabledButton(TagBuilder tag)
        {
            tag.MergeAttribute("class", "btn disabledButton");
            tag.MergeAttribute("href", "");
            tag.MergeAttribute("onclick", "return false");
        }

        private static TagBuilder InitElement(string innerText)
        {
            var tag = new TagBuilder("a");
            tag.SetInnerText(innerText);
            return tag;
        }



    }
}
