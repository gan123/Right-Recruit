using System.Web.Mvc;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Filters;

namespace RightRecruit.Controllers
{
    public class InboxController : AbstractController
    {
        [HttpGet]
        [RavenActionFilter]
        public ActionResult Inbox()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }
    }
}
