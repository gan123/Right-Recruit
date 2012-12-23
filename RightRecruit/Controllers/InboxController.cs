using System.Web.Mvc;
using RightRecruit.Mvc.Infrastructure.Controllers;

namespace RightRecruit.Controllers
{
    public class InboxController : AbstractController
    {
        [HttpGet]
        public ActionResult Inbox()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Login", "Secure");
            return View();
        }
    }
}
