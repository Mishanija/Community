

using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// Для корректной работы класса, нужно:
    /// 1) Определить таблицу в конструкторе класса 
    /// </summary>
    public class DeleteDao<T> : DataEntitiesDao<T> where T : EntityObject
    {
        public void DeleteObject(T obj)
        {
            Table.DeleteObject(obj);
            Db.SaveChanges();
        }
    }
}