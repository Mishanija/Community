

using System;
using System.Text;
using System.Web.Mvc;
using SuperCommunity.Models.PageModels;

namespace SuperCommunity.HtmlHelpers.Solutions
{
    public static class AnimateContacts
    {
        private static int _zIndex;

        private static int _left;

        private static int _marginLeft;

        private static int _width; // BoxImage size

        private static int _height; // BoxImage size

        private static int _iconsRow;

        public static MvcHtmlString AnimateMyContacts(this HtmlHelper html, ContactModel model)
        {
            var tag = new TagBuilder("div");
            tag.MergeAttribute("class", "menuAnimate");
            tag.MergeAttribute("id", "animateContacts");

            Initialization(model);

            var boxBack = BoxImage(model.BoxBackImageUrl);

            var mainInnerHtml = "";

            foreach (var contact in model.Contacts)
            {
                var innerTag = new TagBuilder("div");

                var style = new StringBuilder();
                style.Append("left:" + _left + "px;");
                style.Append("bottom:" + _iconsRow + "px;");
                style.Append("z-index:" + _zIndex + ";");
                innerTag.MergeAttribute("style", style.ToString());

                NextStyle();
                innerTag.InnerHtml = ContactImageTag(contact.ImageUrl, model.IconsSize);
                innerTag.InnerHtml += SpanText(contact.ContactText);

                mainInnerHtml += innerTag.ToString();
            }

            var boxFront = BoxImage(model.BoxFrontImageUrl);

            tag.InnerHtml = boxBack + mainInnerHtml + boxFront;


            return new MvcHtmlString(tag.ToString());
        }

        private static void Initialization(ContactModel model)
        {
            InitSizes(model.IconsSize, model.Contacts.Count);
            InitStyle(model.IconsSize);
        }

        private static void InitSizes(int iconsSize, int count)
        {
            var size = (int)Math.Ceiling(iconsSize * count * 1.3);
            _height = size;
            _width = size;
            _iconsRow = (int)(size * 0.55);
        }

        private static void InitStyle(int iconsSize)
        {
            _zIndex = 1;
            _left = (int)(_width * 0.3);
            _marginLeft = (int)(iconsSize * 0.6);
        }

        private static string BoxImage(string imageUrl)
        {
            var box = new TagBuilder("img");

            box.MergeAttribute("src", imageUrl);

            var style = new StringBuilder();
            style.Append("height:" + _height + "px;");
            style.Append("width:" + _width + "px;");
            style.Append("position: absolute;");
            style.Append("bottom:" + 15 + "px;");
            style.Append("left:" + 15 + "px;");
            style.Append("z-index:" + _zIndex++ + ";");

            box.MergeAttribute("style", style.ToString());
            box.MergeAttribute("class", "box");

            return box.ToString();
        }

        private static string SpanText(string text)
        {
            var span = new TagBuilder("span");

            span.SetInnerText(text);

            return span.ToString();
        }

        private static string ContactImageTag(string imageUrl, int iconsSize)
        {
            var image = new TagBuilder("img");
            image.MergeAttribute("src", imageUrl);
            image.MergeAttribute("style", "height:" + iconsSize + "px; width:" + iconsSize + "px;");
            return image.ToString();
        }

        private static void NextStyle()
        {
            _zIndex++;
            _left += _marginLeft;
        }

    }
}