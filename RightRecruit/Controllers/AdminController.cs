using System.Web.Mvc;
using RightRecruit.Mvc.Infrastructure.Controllers;

namespace RightRecruit.Controllers
{
    public class AdminController : AbstractController
    {
        [HttpGet]
        public ActionResult Admin()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }

        [HttpGet]
        public ActionResult Personalize()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }
    }
}
