
using System.Web.Mvc;
using SuperCommunity.DAO.Tags.Crud;
using SuperCommunity.Models.Membership;
using SuperCommunity.Service.Entities.Tags;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View(new TagFindDao().GetAllTags());
        }

        //
        // GET: /Tag/Details/<id> or 0

        public ActionResult Details(int id)
        {
            var tag = new TagFindDao().GetObjectById(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return View(tag);
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                new TagCreateDao().SaveObject(tag);

                return RedirectToAction("Index");
            }

            return View(tag);
        }

        //
        // GET: /Tag/Edit/<id> or 0

        public ActionResult Edit(int id)
        {
            var tag = new TagFindDao().GetObjectById(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return View(tag);
        }

        //
        // POST: /Tag/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                new TagUpdateDao().UpdateAndAttachObject(tag);

                return RedirectToAction("Index");
            }

            return View(tag);
        }

        //
        // GET: /Tag/Delete/<id> or 0

        public ActionResult Delete(int id)
        {
            var tag = new TagFindDao().GetObjectById(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return View(tag);
        }

        //
        // POST: /Tag/Delete/<id>

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new DeleteTagService().DeleteTag(id);

            return RedirectToAction("Index");
        }


    }
}