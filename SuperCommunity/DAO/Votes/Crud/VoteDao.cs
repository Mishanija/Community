using System.Data;
using System.Linq;
using SuperCommunity.DAO.Crud;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Votes.Crud
{
    public class VoteDao : DataEntitiesDao<Vote>
    {
        public VoteDao()
        {
            Table = Db.Votes;
        }

        public void UpdateObject(Vote obj)
        {
            Db.ObjectStateManager.ChangeObjectState(obj, EntityState.Modified);
            Db.SaveChanges();
        }

        public void UpdateAndAttachObject(Vote obj)
        {
            Table.Attach(obj);
            UpdateObject(obj);
        }

        public void SaveObject(Vote obj)
        {
            Table.AddObject(obj);
            Db.SaveChanges();
        }

        public void DeleteObject(Vote obj)
        {
            Table.DeleteObject(obj);
            Db.SaveChanges();
        }

        public Vote FindVote(int id)
        {
            return (from vote in Table where vote.VoteId == id select vote).FirstOrDefault();
        }

        public Vote FindVoteByParams(int userId, int pictureId)
        {
            var o = (from vote in Table
                     where
                         vote.UserId == userId && vote.PictureId == pictureId
                     select vote).FirstOrDefault();

            return o;
        }
        
    }
}