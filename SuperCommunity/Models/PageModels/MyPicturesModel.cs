using System.Collections.Generic;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.PageModels
{
    public class MyPicturesModel : IPageModel
    {
        public List<ImageEditModel> Images { get; set; }
    }
}