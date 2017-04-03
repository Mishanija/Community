
using System.Linq;
using SuperCommunity.DAO.Albums;
using SuperCommunity.Models.PageModels;
using SuperCommunity.Service.Factoryes.shared;

namespace SuperCommunity.Service.Factoryes
{
    public class UserAlbumsModelFactory : ModelFactory<UserAlbumsModel>
    {
        private readonly int _userId;

        public UserAlbumsModelFactory(int userId)
        {
            _userId = userId;
        }
        

        public override UserAlbumsModel BuildModel()
        {
            var userAlbums = new FindUsersAlbumsDao().GetAllAlbumsByUserId(_userId);

            var builder = new AlbumEditModelBuilder();

            var albums = userAlbums.Select(userAlbum => builder.BuildModel(userAlbum)).ToList();
            
            return new UserAlbumsModel
            {
                Albums = albums
            };
        }
    }
}