
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Service.Factoryes
{
    /// <summary>
    /// Фабрика. Создает модели с использованием данных,
    /// переданных через конструктор.
    /// TM - модель
    /// 
    /// Нужно реализовать:
    /// 1 - Определение метода BuildModel() 
    /// </summary>
    public abstract class ModelFactory<TModel> : IService
        where TModel : IPageModel
    {
        public abstract TModel BuildModel();
    }
}