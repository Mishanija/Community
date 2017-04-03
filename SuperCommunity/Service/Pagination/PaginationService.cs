using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;

namespace SuperCommunity.Service.Pagination
{

    /// <summary>
    /// Класс для постраничного получения данных из базы.
    /// TType - тип объектов из базы данных.
    /// TFinder - класс для поиска сущностей. Там можно реализовать 
    /// нужный механизм возврата блока данных (способ сортировки данных).
    /// </summary>
    public abstract class PaginationService<TType, TFinder> : IService
        where TType : EntityObject
        where TFinder : PaginationFinder<TType>
    {
        public readonly int PaginationSize;

        private readonly TFinder _finder;

        private int _pagesCount;

        protected PaginationService(TFinder finder, int paginationSize)
        {
            PaginationSize = paginationSize;

            _finder = finder;
        }

        public List<TType> GetPageObjects(int pageNumber)
        {
            var skip = pageNumber * PaginationSize;

            var pageList = _finder.GetPageList(skip, PaginationSize);

            _pagesCount = SetPagesCount();

            return !IsCorrecrtRequest(pageNumber) ? new List<TType>() : pageList;
        }

        private int SetPagesCount()
        {
            var length = _finder.GetElementsLength();

            return (int)Math.Ceiling((double)length / PaginationSize);
        }

        public int GetPagesCount()
        {
            return _pagesCount;
        }

        private bool IsCorrecrtRequest(int pageNumber)
        {
            return pageNumber >= 0 && pageNumber < GetPagesCount();
        }
    }
}