using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RightRecruit.Models;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Result;

namespace RightRecruit.Controllers
{
    public class LookupController : AbstractController
    {
       [HttpGet]
        [OutputCache(CacheProfile = "Lookups")]
        public ActionResult Industries()
        {
            var industries = UnitOfWork.DocumentSession.Query<Domain.Industry>()
                    .Select(i => new Industry { Id = i.Id, Name = i.Name })
                    .ToList();

            return new JsonNetResult{ Data = industries};
        }

        [HttpGet]
        [OutputCache(CacheProfile = "Lookups")]
        public ActionResult Countries()
        {
            var countries = UnitOfWork.DocumentSession.Query<Domain.Country>()
                    .Select(i => new Country { Id = i.Id, Name = i.Name })
                    .ToList();

            return new JsonNetResult { Data = countries };
        }

        [HttpGet]
        [OutputCache(CacheProfile = "Lookups")]
        public ActionResult States()
        {
            var states = UnitOfWork.DocumentSession.Query<Domain.State>()
                    .Select(i => new State { Id = i.Id, Name = i.Name, CountryId = i.Country.Id })
                    .ToList();

            return new JsonNetResult { Data = states };
        }

        [HttpGet]
        [OutputCache(CacheProfile = "Lookups")]
        public ActionResult Cities()
        {
            var cities = UnitOfWork.DocumentSession.Query<Domain.City>()
                    .Select(i => new City { Id = i.Id, Name = i.Name, StateId = i.State.Id })
                    .ToList();

            return new JsonNetResult { Data = cities };
        }

        [HttpGet]
        [OutputCache(CacheProfile = "Lookups")]
        public ActionResult Priorities()
        {
            return new JsonNetResult { Data = PrioritiesList };
        }

        private static IEnumerable<string> PrioritiesList
        {
            get
            {
                yield return "Platinum";
                yield return "Diamond";
                yield return "Gold";
                yield return "No Priority";
            }
        }
    }
}
