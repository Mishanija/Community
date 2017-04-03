
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// 1) Определить таблицу в конструкторе класса. 
    /// Пример: Table = db.InfoUsers;
    /// </summary>
    public class CreateDao<T> : DataEntitiesDao<T> where T : EntityObject
    {

        public void SaveObject(T obj)
        {
            Table.AddObject(obj);
            Db.SaveChanges();
        }


    }
}