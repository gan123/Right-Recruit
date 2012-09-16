using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RightRecruit.Models;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Result;

namespace RightRecruit.Controllers
{
    public class ClientController : AbstractController
    {
        // POST: /clients/quicksearch
        [HttpPost]
        public ActionResult QuickSearch(string query)
        {
            var clients = UnitOfWork.DocumentSession.Advanced.LuceneQuery<Domain.Client>("ClientSearchIndex")
                .Where("Name:*" + query + "*")
                .AndAlso().Where("Database:" + CurrentUserProvider.CurrentUser.User.Database)
                .Select(s => new ClientQuickSearch
                                 {
                                     Id = s.Id,
                                     Name = s.Name,
                                     Country = s.Address.Country.Name,
                                     Industry = s.Industry.Name
                                 })
                .ToList();

            return new JsonNetResult { Data = clients};
        }

        // GET : /clients
        [HttpGet]
        public ActionResult List()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View("List");
        }

        // POST : /clients/search
        [HttpPost]
        public ActionResult Search(ClientSearchFilter filter)
        {
            return View("List");
        }

        private List<ClientSearch> Filter(ClientSearchFilter filter = null)
        {
            return new List<ClientSearch>();
        }
    }
}
