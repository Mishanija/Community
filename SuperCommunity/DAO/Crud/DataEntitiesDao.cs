
// ---------- DataService ---------

using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace SuperCommunity.DAO.Crud
{
    /// <summary>
    /// Базовый класс для всех сервисов, которые работают только
    /// с одной сущностью. 
    /// Знает о таблице, с которой работает сервис.
    /// Наследует:
    /// 1) доступ к базе данных.
    /// 2) Метод освобождения ресурсов системы, когда они оказываются уже ненужными.
    /// </summary>
    public class DataEntitiesDao<T> : QueryDao where T : EntityObject
    {
        protected ObjectSet<T> Table;
    }
}

