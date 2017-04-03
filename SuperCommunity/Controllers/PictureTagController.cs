
using System.Web.Mvc;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.PageModels;
using SuperCommunity.Service.Entities.PictureTags;
using SuperCommunity.Service.Factoryes;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class PictureTagController : Controller
    {

        //
        // GET: /PictureTag/Create
        public ActionResult MyPictures()
        {
            return View(new MyPicturesModelFactory(User.Identity.Name).BuildModel());
        }

        public ActionResult EditTags(int id)
        {
            return View(new EditTagsModelFactory(id).BuildModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTags(EditTagsModel editTagsModel)
        {
            // Security
            if (editTagsModel == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                new PictureTagEditProcessor().ToEditTags(editTagsModel);

                return RedirectToAction("MyPictures");
            }

            return View(editTagsModel);
        }


    }
}