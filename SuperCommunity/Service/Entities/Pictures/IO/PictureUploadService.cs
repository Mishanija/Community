
using SuperCommunity.DAO.Crud;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.IO;

namespace SuperCommunity.Service.Entities.Pictures.IO
{
    public class PictureUploadService : UploadFileService<Picture>
    {
        private readonly Counter _counter = new Counter("Service\\picture_id.counter");

        public PictureUploadService(int albumId)
            : this
                (new FileUploader("\\Images\\UserPhotos\\"),
                new PictureCreateDao(),
                new Picture { AlbumId = albumId, PictureDescribe = "describe" })
        { }

        public PictureUploadService(FileUploader fileUploader, CreateDao<Picture> createObject, Picture pattern)
            : base(fileUploader, createObject, pattern)
        { }

        protected override string GetPrivateName(string fileName)
        {
            var privateName = _counter.GetNumber() + "_" + fileName;

            Obj.PictureUrl = privateName; Obj.PictureName = fileName;

            return privateName;
        }

        protected override Picture CopyPattern()
        {
            return new Picture
                {
                    AlbumId = Pattern.AlbumId,
                    PictureDescribe = Pattern.PictureDescribe
                };
        }
    }
}