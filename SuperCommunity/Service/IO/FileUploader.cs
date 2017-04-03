

using System;
using System.IO;
using System.Web;

namespace SuperCommunity.Service.IO
{
    public class FileUploader : IService
    {
        private readonly string _directory;

        public FileUploader(string directory)
        {
            _directory = AppDomain.CurrentDomain.BaseDirectory + directory;

            if (!Directory.Exists(_directory)) Directory.CreateDirectory(_directory);
        }

        public void UploadFile(HttpPostedFileBase file, string privateName)
        {
            if (file != null)
            {
                file.SaveAs(_directory + privateName);
            }
        }

    }
}