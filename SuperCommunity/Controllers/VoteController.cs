
using System.Web.Mvc;
using SuperCommunity.Service.Entities.Votes;
using SuperCommunity.Service.Factoryes;

namespace SuperCommunity.Controllers
{
    public class VoteController : Controller
    {
        public ActionResult Like(int pictureId)
        {
            if (!Request.IsAjaxRequest())
            {
                return HttpNotFound();
            }

            var service = new VoteService();

            var userId = service.FindUserId(User.Identity.Name);

            if (new VoteHonestService().CheckOwner(pictureId, userId))
            {
                return HttpNotFound();
            }

            var vote = service.FindVote(pictureId, userId);

            var factory = new LikeModelFactory(pictureId);

            
            if (vote == null)
            {
                service.AddLikeVote(userId);

                return PartialView("PictureLike", factory.BuildModel());
            }

            if (vote.Dislike)
            {
                service.UpdateLike(vote);

                var model = factory.BuildChangeModel();

                return PartialView("PictureLikeChange", model);
            }

            service.DeleteVote(vote);

            return PartialView("PictureLike", factory.BuildModel());
        }

        //
        // GET: /Vote/Details/5

        public ActionResult Dislike(int pictureId)
        {
            if (!Request.IsAjaxRequest())
            {
                return HttpNotFound();
            }

            var service = new VoteService();

            var userId = service.FindUserId(User.Identity.Name);

            if (new VoteHonestService().CheckOwner(pictureId, userId))
            {
                return HttpNotFound();
            }

            var vote = service.FindVote(pictureId, userId);

            var factory = new DislikeModelFactory(pictureId);

            if (vote == null)
            {
                service.AddDislikeVote(userId);

                return PartialView("PictureDislike", factory.BuildModel());
            }
            if (vote.Like)
            {
                service.UpdateDislike(vote);

                return PartialView("PictureDislikeChange", factory.BuildChangeModel() );
            }

            service.DeleteVote(vote);

            return PartialView("PictureDislike", factory.BuildModel());

        }
    }
}