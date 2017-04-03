
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud.StaticDao
{
    public class StaticDataEntitiesDao<T> : StaticQueryDao where T : EntityObject
    {
        protected ObjectSet<T> Table;
    }
}