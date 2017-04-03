

using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.DAO.Votes.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Service.Entities.Votes
{
    public class VoteService : IService
    {
        private readonly VoteDao _dao = new VoteDao();

        private int _pictureId;

        public Vote FindVote(int pictureId, int userId)
        {
            _pictureId = pictureId;

            return _dao.FindVoteByParams(userId, pictureId);
        }

        public int FindUserId(string userName)
        {
            return new FindUserProfileDao().FindUserIdByUserName(userName);
        }

        public void AddDislikeVote(int userId)
        {
            AddVote(false, userId);
        }

        public void AddLikeVote(int userId)
        {
            AddVote(true, userId);
        }

        private void AddVote(bool isLike, int userId)
        {
            var vote = new Vote
            {
                Dislike = !isLike,
                Like = isLike,
                PictureId = _pictureId,
                UserId = userId
            };

            _dao.SaveObject(vote);
        }

        public void UpdateLike(Vote vote)
        {
            UpdateVoid(vote, true);
        }

        public void UpdateDislike(Vote vote)
        {
            UpdateVoid(vote, false);
        }

        private void UpdateVoid(Vote vote, bool isLike)
        {
            vote.Dislike = !isLike;
            vote.Like = isLike;

            _dao.UpdateObject(vote);
        }

        public void DeleteVote(Vote vote)
        {
            _dao.DeleteObject(vote);
        }

    }
}