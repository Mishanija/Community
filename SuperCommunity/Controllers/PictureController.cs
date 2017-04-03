
using System.Web.Mvc;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Entities.Pictures.Crud;
using SuperCommunity.Service.Entities.Pictures.Request;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        
        public ActionResult Details(int id)
        {
            var picture = new PictureFindDao().GetObjectById(id);

            if (picture == null)
            {
                return HttpNotFound();
            }

            return View(picture);
        }


        public ActionResult Edit(int id)
        {
            var picture = new PictureFindDao().GetObjectById(id);

            if (new PictureRequestService().IsBadRequest(picture, User.Identity.Name))
            {
                return HttpNotFound();
            }

            return View(picture);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Picture picture)
        {
            if (ModelState.IsValid)
            {
                new PictureUpdateDao().UpdateAndAttachObject(picture);

                return RedirectToAction("Details", new {Id = picture.PictureId});
            }
            
            return View(picture);
        }


        public ActionResult Delete(int id)
        {
            var picture = new PictureFindDao().GetObjectById(id);

            if (new PictureRequestService().IsBadRequest(picture, User.Identity.Name))
            {
                return HttpNotFound();
            }

            return View(picture);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var picture = new PictureFindDao().GetObjectById(id);

            if (new PictureRequestService().IsBadRequest(picture, User.Identity.Name))
            {
                return HttpNotFound();
            }

            new PictureDeleteService().DeletePicture(id);

            return RedirectToAction("Details", "Album", new { id = picture.AlbumId });
        }

    }
}