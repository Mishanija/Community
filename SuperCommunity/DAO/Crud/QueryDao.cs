using System;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// Базовый класс для всех сервисов, которые 
    /// работают с базой данных.
    /// </summary>
    public class QueryDao : IDao, IDisposable
    {
        protected MyEntities Db = new MyEntities();

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}