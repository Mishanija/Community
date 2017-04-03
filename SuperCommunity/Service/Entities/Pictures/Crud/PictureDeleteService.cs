

using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.DAO.Votes.Crud;

namespace SuperCommunity.Service.Entities.Pictures.Crud
{
    public class PictureDeleteService : IService
    {
        private readonly PictureTagDeleteDao _pictureTagDeleteDao = new PictureTagDeleteDao();

        private readonly PictureDeleteDao _pictureDeleteDao = new PictureDeleteDao();

        private readonly PictureVotesDao _pictureVotesDeleteDao = new PictureVotesDao();

        public void DeletePicture(int pictureId)
        {
            DeleteAllVotes(pictureId);

            DeleteAllTags(pictureId);

            _pictureDeleteDao.DeletePicture(pictureId);
        }

        private void DeleteAllVotes(int pictureId)
        {
            var votes = _pictureVotesDeleteDao.FindVotesByPictureId(pictureId);

            foreach (var vote in votes)
            {
                _pictureVotesDeleteDao.DeleteObject(vote);
            }
        }

        private void DeleteAllTags(int pictureId)
        {
            var tags = _pictureTagDeleteDao.GetPictureTagsByPictureId(pictureId);

            foreach (var pictureTag in tags)
            {
                _pictureTagDeleteDao.DeleteObject(pictureTag);
            }
        }
    }
}