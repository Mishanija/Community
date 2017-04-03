

namespace SuperCommunity.Service.Entities.Pictures.IO
{
    public class PicturePathService : IService
    {
        public string CutUrl(string url)
        {
            string uri =
                        "http://" +
                        System.Web.HttpContext.Current.Request.Url.Host
                        + ":"
                        + System.Web.HttpContext.Current.Request.Url.Port;

            const string subPath = "/Images/UserPhotos/";

            return url.Replace(uri, "").Replace(subPath, "");
        }

        public string CheckAndCutUrl(string url)
        {
            url = CutUrl(url);
            if (url.Equals("/Images/NoPhoto.jpg"))
            {
                return "NoPhoto.jpg";
            }
            return url;
        }
    }
}