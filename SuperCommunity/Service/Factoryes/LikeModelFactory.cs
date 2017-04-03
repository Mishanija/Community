using SuperCommunity.DAO.Votes.Crud;
using SuperCommunity.Models.Entities;

namespace SuperCommunity.Service.Factoryes
{
    public class LikeModelFactory : ModelFactory<LikeModel>
    {
        private readonly int _pictureId;

        public LikeModelFactory(int pictureId)
        {
            _pictureId = pictureId;
        } 

        public override LikeModel BuildModel()
        {
            return new LikeModel { Likes = GetLikes() };
        }

        public LikeChangeModel BuildChangeModel()
        {
            return new LikeChangeModel { Likes = GetLikes(), PictureId = _pictureId};
        }

        private int GetLikes()
        {
            return new VoteFindDao().GetLikesVoteCount(_pictureId);
        }

    }
}