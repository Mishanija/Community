
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// Для того, чтобы класс работал с сущностью-параметром, нужно:
    /// 1) Определить его таблицу в конструкторе
    /// 2) Реализовать метод поиска сущности по id
    /// 
    /// Если нужно, реализовать другие методы поиска сущности
    /// </summary>
    public abstract class FindDao<T> : DataEntitiesDao<T> where T : EntityObject
    {
        public abstract T GetObjectById(int id);
    }
}
