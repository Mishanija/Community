
using System.Web.Mvc;
using SuperCommunity.DAO.Forms.Crud;
using SuperCommunity.DAO.UserProfiles.Crud;
using SuperCommunity.Models.PageModels;
using SuperCommunity.Service.Entities.Forms;
using SuperCommunity.Service.Factoryes;
using SuperCommunity.Service.Request;

namespace SuperCommunity.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        //
        // GET: /Form/Details/

        public ActionResult Details()
        {   
            var form = new FindFormDao().GetFormByUserId(new FindUserProfileDao().FindUserIdByUserName(User.Identity.Name));

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }


        //
        // GET: /Form/Create

        public ActionResult Create()
        {
            return View(new FormModelFactory(new FormFactory().BuildNewForm(User.Identity.Name)).BuildModel());
        }

        //
        // POST: /Form/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormModel formModel)
        {
            if (new FormConvertService().Convert(formModel, ModelState.IsValid, true))
            {
                return RedirectToAction("Index", "User");
            }

            return View(formModel);
        }

        

        //
        // GET: /Form/Edit/<id> or 0

        public ActionResult Edit()
        {
            return View(new FormModelFactory(new FormComplexFindService().GetFormByUserName(User.Identity.Name)).BuildModel());
        }

        //
        // POST: /Form/Edit/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormModel model)
        {
            if (new FormConvertService().Convert(model, ModelState.IsValid, false))
            {
                return RedirectToAction("Index", "User");
            }

            return View(model);
        }

        //
        // GET: /Form/Delete/<id> or 0

        public ActionResult Delete(int id)
        {
            var form = new FindFormDao().GetObjectById(id);

            if (!new Security().CheckUser(form.UserId, User.Identity.Name))
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // POST: /Form/Delete/<id> or 0

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var form = new FindFormDao().GetObjectById(id);

            if (!new Security().CheckUser(form.UserId, User.Identity.Name))
            {
                return HttpNotFound();
            }

            new FormDeleteDao().DeleteObject(form);
            
            return RedirectToAction("Index", "Home");
        }

    }
}