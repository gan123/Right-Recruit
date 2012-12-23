using System.Web.Mvc;
using RightRecruit.Mvc.Infrastructure.Controllers;

namespace RightRecruit.Controllers
{
    public class HomeController : AbstractController
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
    }
}
