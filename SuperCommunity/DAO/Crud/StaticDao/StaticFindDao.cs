
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public abstract class StaticFindDao<T> : StaticDataEntitiesDao<T> where T : EntityObject
    {
        public abstract T GetObjectById(int id);
    }
}