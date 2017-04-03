

using System.Collections.Generic;
using SuperCommunity.Models.Interfaces;
using SuperCommunity.Models.Support;

namespace SuperCommunity.Models.PageModels
{
    public class ContactModel : IPageModel
    {
        public List<Contact> Contacts;

        public int IconsSize;

        public string BoxFrontImageUrl;

        public string BoxBackImageUrl;
    }
}