
using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Votes.Crud
{
    public class PictureVotesDao : DeleteDao<Vote>
    {
        public PictureVotesDao()
        {
            Table = Db.Votes;
        }

        public List<Vote> FindVotesByPictureId(int pictureId)
        {
            return (from vote in Table where vote.PictureId == pictureId select vote).ToList();
        }
    }
}