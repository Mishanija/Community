using System.Collections.Generic;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Interfaces;

namespace SuperCommunity.Models.PageModels
{
    public class UserAlbumsModel : IPageModel
    {
        public List<AlbumEditModel> Albums;
    }
}