using System.Collections.Generic;
using SuperCommunity.Models.Interfaces;
using SuperCommunity.Models.Membership;

namespace SuperCommunity.Models.PageModels
{
    public class FormModel : IPageModel
    {
        public Form Form { get; set; }
        
        public List<string> PictureLinks { get; set; }
    }
}