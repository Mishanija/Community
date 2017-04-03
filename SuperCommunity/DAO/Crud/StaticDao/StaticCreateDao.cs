

using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public class StaticCreateDao<T> : StaticDataEntitiesDao<T> where T : EntityObject
    {
        public void SaveObject(T obj)
        {
            Table.AddObject(obj);
            Db.SaveChanges();
        }
    }
}