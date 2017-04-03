

using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public class StaticDeleteDao<T> : StaticDataEntitiesDao<T> where T : EntityObject
    {
        public void DeleteObject(T obj)
        {
            Table.DeleteObject(obj);
            Db.SaveChanges();
        }
    }
}