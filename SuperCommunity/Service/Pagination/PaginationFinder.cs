using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using SuperCommunity.DAO.Crud;

namespace SuperCommunity.Service.Pagination
{
    /// <summary>
    /// Класс для задания нужного способа сортировки данных и их возврата.
    /// 
    /// TType - Тип данных (сущность), для которых будет настроен поисковик страниц.
    /// 
    /// Требуется:
    /// 1) реализация метода GetPageList, который должен возвращать 
    /// блок данных в зависимости от входных аргументов 
    /// (сколько пропустить, сколько взять)
    /// 
    /// 2) Также нужно реализовать определения свойства Table в конструкторе класса.
    /// Это свойство должно указывать где (в какой таблице в базе данных) хранятся
    /// сущности, с которыми будет работать класс.
    /// </summary>
    public abstract class PaginationFinder<TType> : DataEntitiesDao<TType> 
        where TType : EntityObject
    {
        public abstract List<TType> GetPageList(int skip, int take);

        protected int ElementsLength;
        
        public int GetElementsLength()
        {
            return ElementsLength;
        }
    }
}