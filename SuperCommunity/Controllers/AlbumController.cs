
using System.Web.Mvc;
using SuperCommunity.DAO.Albums.Crud;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Entities.Albums.Crud;
using SuperCommunity.Service.Entities.Albums.Request;
using SuperCommunity.Service.Factoryes;
using SuperCommunity.Service.Factoryes.shared;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {

        public ActionResult Index()
        {
            var userId = new FindUserProfileDao().FindUserIdByUserName(User.Identity.Name);

            var model = new UserAlbumsModelFactory(userId).BuildModel();

            return View(model);
        }

        public ActionResult AlbumPage(int pageNumber, int albumId)
        {
            if (!Request.IsAjaxRequest())
            {
                return HttpNotFound();
            }

            var album = new FindAlbumDao().GetObjectById(albumId);

            if (new AlbumRequestService().IsBadRequest(album, User.Identity.Name))
            {
                return HttpNotFound();
            }

            var model = new AlbumEditModelBuilder().BuildModel(album, pageNumber);

            return PartialView("AlbumPage", model);
        }
        
        public ActionResult Details(int id)
        {
            return View(new FindAlbumDao().GetObjectById(id));
        }
        
        public ActionResult Create()
        {
            return View(new Album { UserId = new FindUserProfileDao().FindUserIdByUserName(User.Identity.Name)});
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                new CreateAlbumDao().SaveObject(album);
                
                return RedirectToAction("Index");
            }

            return View(album);
        }

        public ActionResult Edit(int id = 0)
        {
            var album = new FindAlbumDao().GetObjectById(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (!ModelState.IsValid) return View(album);

            new UpdateAlbumDao().UpdateAndAttachObject(album);

            return RedirectToAction("Index");
        }

        //
        // GET: /Album/Delete/<id>

        public ActionResult Delete(int id)
        {
            var album = new FindAlbumDao().GetObjectById(id);

            if (new AlbumRequestService().IsBadRequest(album, User.Identity.Name))
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /Album/Delete/<id>

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var album = new FindAlbumDao().GetObjectById(id);

            if (new AlbumRequestService().IsBadRequest(album, User.Identity.Name))
            {
                return HttpNotFound();
            }

            new AlbumDeleteService().DeleteAlbum(id);

            return RedirectToAction("Index");
        }

        
    }
}