using System.Text;
using System.Web.Mvc;

namespace SuperCommunity.HtmlHelpers.BuildingBlocks
{
    public static class GallerySlider
    {
        private static string _wraperId;

        public static MvcHtmlString BuildSlider(int gallerySize, string wraperId)
        {
            Initialization(wraperId);

            var overlay = new TagBuilder("div");
            overlay.MergeAttribute("id", "galleryOverlay_" + _wraperId);


            overlay.InnerHtml =
                BuildGallerySlider(gallerySize) + " " +
                BuildArrows();

            return new MvcHtmlString(overlay.ToString());
        }

        private static void Initialization(string wraperId)
        {
            _wraperId = wraperId;
        }

        private static string BuildGallerySlider(int size)
        {
            var slider = new TagBuilder("div");
            slider.MergeAttribute("id", "gallerySlider_" + _wraperId);

            slider.InnerHtml =
                BuildPlaceHolders(size);

            return slider.ToString();
        }

        private static string BuildPlaceHolders(int size)
        {
            var placeholders = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                var placeholder = new TagBuilder("div");
                placeholder.MergeAttribute("class", "placeholder");

                placeholders.Append(placeholder);
            }

            return placeholders.ToString();
        }

        private static string BuildArrows()
        {
            return BuildLeftArrow() + " " + BuildRightArrow();
        }

        private static string BuildLeftArrow()
        {
            var arrow = new TagBuilder("a");
            arrow.MergeAttribute("id", "prevArrow_" + _wraperId);
            return arrow.ToString();

        }

        private static string BuildRightArrow()
        {
            var arrow = new TagBuilder("a");
            arrow.MergeAttribute("id", "nextArrow_" + _wraperId);
            return arrow.ToString();
        }

    }
}