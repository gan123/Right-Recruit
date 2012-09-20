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
                .Where(string.Format("Name:*{0}*", query))
                .AndAlso().Where(string.Format("Database:{0}", CurrentUserProvider.CurrentUser.User.Database))
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
            return View();
        }

        // POST : /clients/search
        [HttpPost]
        public ActionResult Search(ClientSearchFilter filter)
        {
            var clients = UnitOfWork.DocumentSession.Advanced.LuceneQuery<Domain.Summary.ClientSummary>("ClientSummaryIndex")
                .Where("Database:" + CurrentUserProvider.CurrentUser.User.Database)
                .Select(c => new ClientSearch
                                 {
                                     Id = c.Id,
                                     Name = c.Name,
                                     Country = c.Country,
                                     Industry = c.Industry,
                                     Priority = c.Priority,
                                     Contacts = c.Contacts.Aggregate((a, b) => a + ", " + b),
                                     NoOfPositions = c.NoOfPositions.HasValue ? c.NoOfPositions.Value : 0,
                                     Status = c.Status,
                                     BookedRev = 10000,
                                     ProjectedRev = 50000
                                 })
                .ToList();

            return new JsonNetResult {Data = clients};
        }

        // GET : /clients/new
        [HttpGet]
        public ActionResult New()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }

        // POST : clients/create
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Create()
        {
            return new JsonNetResult(new {});
        }
    }
}
