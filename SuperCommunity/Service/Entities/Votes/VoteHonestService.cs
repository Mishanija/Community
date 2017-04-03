
using SuperCommunity.DAO.Votes;

namespace SuperCommunity.Service.Entities.Votes
{
    public class VoteHonestService : IService
    {
        public bool CheckOwner(int pictureId, int userId)
        {
            return new VoteOwnerDao().CheckOwner(userId, pictureId);
        }
    }
}