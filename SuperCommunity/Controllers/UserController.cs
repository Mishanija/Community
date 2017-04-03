
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using SuperCommunity.DAO.Forms.Crud;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Entities.Albums.Request;
using SuperCommunity.Service.Entities.Pictures.IO;
using SuperCommunity.Service.Entities.Pictures.Request;
using SuperCommunity.Service.Factoryes;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var userForm =
                new FindFormDao().GetFormByUserId(
                    new FindUserProfileDao().FindUserIdByUserName(User.Identity.Name));

            if (userForm == null)
            {
                return RedirectToAction("Create", "Form");
            }

            return View(userForm);
        }

        public ActionResult Gallery(int pageNumber = 0, int tagId = 0)
        {
            var model = new GalleryModelFactory(pageNumber, tagId, User.Identity.Name).BuildModel();

            if (Request.IsAjaxRequest())
            {
                return PartialView("AjaxGallery", model);
            }

            return View(model);
        }
        
        public ActionResult EditEffects(int id)
        {
            var editPicture = new PictureFindDao().GetObjectById(id);

            if (!new PictureRequestService().IsBadRequest(editPicture, User.Identity.Name))
            {
                return HttpNotFound();
            }

            return View(editPicture);
        }

        [HttpPost]
        public ActionResult EditEffects(Picture picture)
        {
            // ?
            return View();
        }

        public ActionResult UploadPhotos(int albumId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhotos(IEnumerable<HttpPostedFileBase> fileUpload, int id)
        {
            if (new AlbumRequestService().IsBadRequest(id, User.Identity.Name))
            {
                return HttpNotFound();
            }

            new PictureUploadService(id).UploadFiles(fileUpload);

            return RedirectToAction("Index", "Album");
        }


    }
}
