using System;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public class StaticQueryDao : IDao, IDisposable
    {
        protected MyEntities Db = new MyEntities();

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}