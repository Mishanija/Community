
using SuperCommunity.DAO.Votes.Crud;
using SuperCommunity.Models.Entities;

namespace SuperCommunity.Service.Factoryes
{
    public class DislikeModelFactory : ModelFactory<DislikeModel>
    {
        private readonly int _pictureId;

        public DislikeModelFactory(int pictureId)
        {
            _pictureId = pictureId;
        }

        public override DislikeModel BuildModel()
        {
            return new DislikeModel { Dislikes = GetDislikes() }; 
        }

        public DislikeChangeModel BuildChangeModel()
        {
            return new DislikeChangeModel { Dislikes = GetDislikes(), PictureId = _pictureId };
        }

        private int GetDislikes()
        {
            return new VoteFindDao().GetDislikesVoteCount(_pictureId);
        }
    }
}