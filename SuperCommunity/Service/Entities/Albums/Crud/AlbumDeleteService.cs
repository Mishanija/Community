
using SuperCommunity.DAO.Albums.Crud;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.Service.Entities.Pictures.Crud;

namespace SuperCommunity.Service.Entities.Albums.Crud
{
    public class AlbumDeleteService : IService
    {
        private readonly PictureDeleteDao _dao = new PictureDeleteDao();

        public void DeleteAlbum(int albumId)
        {
            DeletePicturesInAlbums(albumId);

            new DeleteAlbumDao().DeleteAlbum(albumId);
        }

        private void DeletePicturesInAlbums(int albumId)
        {
            var service = new PictureDeleteService();

            foreach (var pictureId in _dao.GetPictureIdsInAlbum(albumId))
            {
                service.DeletePicture(pictureId);
            }
        }
    }
}