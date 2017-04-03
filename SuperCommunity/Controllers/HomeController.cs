using System.Collections.Generic;
using System.Web.Mvc;
using SuperCommunity.Models.PageModels;
using SuperCommunity.Models.Support;

namespace SuperCommunity.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public ActionResult About()
        {
            var contactModel = new ContactModel
            {
                BoxFrontImageUrl = "/Images/MyContacts/box/box-front.png",
                BoxBackImageUrl = "/Images/MyContacts/box/box-back.png",
                IconsSize = 35,
                Contacts = new List<Contact>
                {
                    new Contact{ContactText = "+37529 2 765 123", ImageUrl = "/Images/MyContacts/icons/mobilePhone.png"}, 
                    new Contact{ContactText = "mishaasadchi", ImageUrl =     "/Images/MyContacts/icons/Skype-icon2.png"}, 
                    new Contact{ContactText = "https://vk.com/id47195387", ImageUrl =        "/Images/MyContacts/icons/vkontakte-logo.png"}, 
                    new Contact{ContactText = "p_ami@mail.by", ImageUrl =      "/Images/MyContacts/icons/email.png"}, 
                    new Contact{ContactText = "+37517 206 111 6", ImageUrl =     "/Images/MyContacts/icons/phone.png"}
                }
            };

            return View(contactModel);
        }

        public ActionResult Promotion()
        {
            return View();
        }

    }
}
