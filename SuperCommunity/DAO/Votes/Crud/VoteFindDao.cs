
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Votes.Crud
{
    public class VoteFindDao : DataEntitiesDao<Vote>
    {
        public VoteFindDao()
        {
            Table = Db.Votes;
        }

        public Vote FindVoteByParams(int userId, int pictureId)
        {
            var o = (from vote in Table where 
                        vote.UserId == userId && vote.PictureId == pictureId select vote).FirstOrDefault();

            return o;
        }

        public int GetDislikesVoteCount(int pictureId)
        {
            return (from vote in Table where vote.PictureId == pictureId && vote.Dislike select vote.VoteId).Count();
        }

        public int GetLikesVoteCount(int pictureId)
        {
            return (from vote in Table where vote.PictureId == pictureId && vote.Like select vote.VoteId).Count();
        }

    }
}