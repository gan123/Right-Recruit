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
using RightRecruit.Mvc.Infrastructure.Filters;
using RightRecruit.Mvc.Infrastructure.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Result;
using RightRecruit.Mvc.Infrastructure.Security;

namespace RightRecruit.Controllers
{
    public class HomeController : AbstractController
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Home()
        {
            if (HttpContext.Response.Cookies["UserName"] != null && HttpContext.Response.Cookies["Password"] != null)
            {
                if (!string.IsNullOrEmpty(HttpContext.Response.Cookies["UserName"].Value) && !string.IsNullOrEmpty(HttpContext.Response.Cookies["Password"].Value))
                    return
                        Login(new LoginModel
                                  {
                                      Login = HttpContext.Response.Cookies["UserName"].Value,
                                      Password = HttpContext.Response.Cookies["Password"].Value
                                  });
            }
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [RavenActionFilter]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = UnitOfWork.DocumentSession.Query<User>()
                .SingleOrDefault(u => u.Username == loginModel.Login);

            if (user == null)
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "Your user name was not recognized!", StatusCode = HttpStatusCode.Unauthorized });

            if (user.Password.Text.ToPlainString() != loginModel.Password)
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "You were not authenticated!", StatusCode = HttpStatusCode.Unauthorized });

            var savedSalt = user.Password.Salt.ToPlainString();
            var savedHash = user.Password.Hash.ToPlainString();

            if (new SaltedHash().VerifyHashString(loginModel.Password, savedHash, savedSalt))
            {
                if (loginModel.RememberMe)
                {
                    HttpContext.Response.Cookies.Add(new HttpCookie("UserName", loginModel.Login));
                    HttpContext.Response.Cookies.Add(new HttpCookie("Password", loginModel.Password));
                }
                var photoAsString = GetAttachmentString(user.PhotoAttachment, useBase64: true);
                HttpContext.Session[Globals.CurrentUser] = new CurrentUser(user)
                                                               {
                                                                   IsAuthenticated = true,
                                                                   PhotoString = "data:image/jpeg;base64," + photoAsString
                                                               };
                return new JsonNetResult(new { LoggedInUserName = user.Name });
            }

            return View("Home");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session[Globals.CurrentUser] = new CurrentUser(null);
            HttpContext.Response.Cookies.Remove("UserName");
            HttpContext.Response.Cookies.Remove("Password");
            return new JsonNetResult();
        }
    }
}
