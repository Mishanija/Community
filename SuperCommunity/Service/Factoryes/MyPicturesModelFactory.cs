using System.Linq;
using SuperCommunity.DAO.Other;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.PageModels;

namespace SuperCommunity.Service.Factoryes
{
    public class MyPicturesModelFactory : ModelFactory<MyPicturesModel>
    {
        private readonly string _userName;

        public MyPicturesModelFactory(string userName)
        {
            _userName = userName;
        }

        public override MyPicturesModel BuildModel()
        {
            var userId = new FindUserProfileDao().FindUserIdByUserName(_userName);

            var userPictures = new UserPictureDao().GetAllUserPictures(userId);

            var images = userPictures.Select(userPicture => new ImageEditModel { PictureId = userPicture.PictureId, PictureUrl = userPicture.PictureUrl }).ToList();

            return new MyPicturesModel { Images = images };
        }
    }
}