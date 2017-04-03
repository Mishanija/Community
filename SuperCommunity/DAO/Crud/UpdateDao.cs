using System.Data;
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// Для корректной работы класса-потомка, нужно:
    /// 1) Определить таблицу в конструкторе класса
    /// </summary>
    public class UpdateDao<T> : DataEntitiesDao<T> where T : EntityObject
    {

        public void UpdateObject(T obj)
        {
            Db.ObjectStateManager.ChangeObjectState(obj, EntityState.Modified);
            Db.SaveChanges();
        }

        public void UpdateAndAttachObject(T obj)
        {
            Table.Attach(obj);
            UpdateObject(obj);
        }

    }
}