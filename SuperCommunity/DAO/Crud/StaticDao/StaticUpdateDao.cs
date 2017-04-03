

using System.Data;
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public class StaticUpdateDao<T> : StaticDataEntitiesDao<T> where T : EntityObject
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