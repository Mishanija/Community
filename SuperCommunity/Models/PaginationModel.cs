

using System.Collections.Generic;
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models
{
    public class PaginationModel<TDataModel> : IDataModel
        where TDataModel : IDataModel
    {
        public List<TDataModel> ObjectsList;

        public int PageNumber;

        public int PagesCount;
    }
}