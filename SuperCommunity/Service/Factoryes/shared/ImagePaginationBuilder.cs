
using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.DAO.Votes;
using SuperCommunity.DAO.Votes.Crud;
using SuperCommunity.Models;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Entities.Pictures.Pagination;
using SuperCommunity.Service.Pagination;

namespace SuperCommunity.Service.Factoryes.shared
{
    public class ImagePaginationBuilder
    {
        public PaginationModel<ImageReadModel> BuildPicturePaginationModel(int albumId, int pageNumber)
        {
            var pagination = new UserAlbumsPaginationService(albumId);

            return BuildReadPaginationModel(pagination, pageNumber);
        }

        public PaginationModel<ImageLikesModel> BuildGalleryPaginationModel(int pageNumber, string userName, int tagId)
        {
            var pagination = new GalleryPaginationService(tagId);

            var userId = new FindUserProfileDao().FindUserIdByUserName(userName);

            return BuildEditPaginationModel(pagination, pageNumber, userId);
        }

        private static PaginationModel<ImageLikesModel> BuildEditPaginationModel<TFinder>
            (PaginationService<Picture, TFinder> pagination,
            int pageNumber, int userId)
            where TFinder : PaginationFinder<Picture> 
        {
            var pictures = pagination.GetPageObjects(pageNumber);

            var models = new List<ImageLikesModel>(12);

            var dao = new VoteFindDao();

            var ownerDao = new VoteOwnerDao();

            models.AddRange(pictures.Select(picture => new ImageLikesModel
            {
                VotesModel = new VotesModel
                {
                    Dislikes = dao.GetDislikesVoteCount(picture.PictureId), 
                    Likes = dao.GetLikesVoteCount(picture.PictureId),
                    IsOwner = ownerDao.CheckOwner(userId, picture.PictureId)
                },
                ImageModel = new ImageEditModel
                {
                    PictureUrl = picture.PictureUrl, PictureId = picture.PictureId
                }
            }));


            return new PaginationModel<ImageLikesModel>
            {
                ObjectsList = models,
                PagesCount = pagination.GetPagesCount(),
                PageNumber = pageNumber
            };
        }

        private static PaginationModel<ImageReadModel> BuildReadPaginationModel<TFinder>
            (PaginationService<Picture, TFinder> pagination,
            int pageNumber)
            where TFinder : PaginationFinder<Picture>
        {
            var pictures = pagination.GetPageObjects(pageNumber);

            var images = pictures.Select(picture => new ImageReadModel { PictureUrl = picture.PictureUrl }).ToList();

            return new PaginationModel<ImageReadModel>
            {
                ObjectsList = images,
                PagesCount = pagination.GetPagesCount(),
                PageNumber = pageNumber
            };
        }

    }
}