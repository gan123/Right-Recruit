using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Raven.Client.Linq;
using RightRecruit.Models;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Result;

namespace RightRecruit.Controllers
{
    public class AdminController : AbstractController
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Admin()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Login", "Secure");
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Personalize()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Login", "Secure");
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult GetPersonalizedTheme()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated) return new JsonNetResult();

            var agency = UnitOfWork.DocumentSession.Query<Domain.Agency>()
                .SingleOrDefault(a => a.Database == CurrentUserProvider.CurrentUser.User.Database);

            if (agency == null)
                throw new HttpResponseException(new HttpResponseMessage {StatusCode = HttpStatusCode.Unauthorized, ReasonPhrase = "You are not authorized to view this page"});

            return new JsonNetResult { Data = new {agency.Branding, agency.Name} };
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SaveTheme(Personalize personalize)
        {
            try
            {
                var agency = UnitOfWork.DocumentSession.Query<Domain.Agency>()
                    .Single(a => a.Database == CurrentUserProvider.CurrentUser.User.Database);

                agency.Branding.Theme.BasicColor = personalize.BasicColor;
                agency.Branding.Theme.MidColor = personalize.MidColor;
                agency.Branding.Theme.BoldColor = personalize.BoldColor;
                agency.Branding.Theme.ControlBorderColor = personalize.ControlBorderColor;
                agency.Branding.Theme.ForegroundColor = personalize.ForegroundColor;
                HttpContext.Application[Request.Url.Host] = null;
                return new JsonNetResult();
            }
            catch (Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = "Could not update theme" });
            }
        }
    }
}
