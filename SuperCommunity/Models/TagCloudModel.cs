
using System.Collections.Generic;
using SuperCommunity.Models.Interfaces;
using SuperCommunity.Service.Entities.Tags;

namespace SuperCommunity.Models
{
    public class TagCloudModel : IPageModel
    {
        public List<TagModel> TagsList;
    }
}