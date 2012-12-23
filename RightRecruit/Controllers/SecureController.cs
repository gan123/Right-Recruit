using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RightRecruit.Domain;
using RightRecruit.Models;
using RightRecruit.Mvc.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Security;

namespace RightRecruit.Controllers
{
    public class SecureController : AbstractController
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [RequireHttps]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = UnitOfWork.DocumentSession.Query<User>()
                .SingleOrDefault(u => u.Username == loginModel.Login);

            if (user == null)
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "Your user name was not recognized!", StatusCode = HttpStatusCode.Unauthorized });

            var hash = new Hasher() { SaltSize = 10 };
            if (!hash.CompareStringToHash(loginModel.Password, user.Password.Value.ToPlainString()))
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "You were not authenticated!", StatusCode = HttpStatusCode.Unauthorized });

            HttpContext.Response.Cookies.Set(new HttpCookie("username", user.Username) { Expires = DateTime.Now.AddDays(1) });
            HttpContext.Session[Globals.CurrentUser] = new CurrentUser(user)
                                                           {
                                                               IsAuthenticated = true,
                                                               Photo = user.PhotoAttachment
                                                           };
            return RedirectToAction("Home","Home");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session[Globals.CurrentUser] = new CurrentUser(null);
            return RedirectToAction("Login", "Secure");
        }
    }
}
