
using System.Data.Objects.DataClasses;

namespace SuperCommunity.Service.Request
{
    public abstract class RequestService<T> : IService where T : EntityObject
    {
        public abstract bool IsBadRequest(T model, string userName);
    }
}