using System.Collections.Generic;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.PageModels
{
    public class EditTagsModel : IPageModel
    {
        public string PictureUrl { get; set; }

        public List<SelectTag> SelectTags { get; set; }
    }
}