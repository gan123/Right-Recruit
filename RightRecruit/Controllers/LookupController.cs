using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RightRecruit.Models;
using RightRecruit.Mvc.Infrastructure.CacheProvider;
using RightRecruit.Mvc.Infrastructure.Controllers;
using RightRecruit.Mvc.Infrastructure.Result;

namespace RightRecruit.Controllers
{
    public class LookupController : AbstractController
    {
        private const string IndustriesLookupKey = "IndustriesLookup";
        private const string CountriesLookupKey = "CountriesLookup";
        private const string StatesLookupKey = "StatesLookup";
        private const string CitiesLookupKey = "CitiesLookup";
        private const string PrioritiesLookupKey = "PrioritiesLookup";

        private readonly ICacheProvider _cacheProvider;

        public LookupController(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        [HttpGet]
        public ActionResult Industries()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return new JsonNetResult();

            List<Industry> industries;
            if (_cacheProvider.HasKey(IndustriesLookupKey))
                industries = (List<Industry>)_cacheProvider.Get(IndustriesLookupKey);
            else
            {
                industries = UnitOfWork.DocumentSession.Query<Domain.Industry>()
                    .Select(i => new Industry {Id = i.Id, Name = i.Name})
                    .ToList();
                _cacheProvider.Insert(IndustriesLookupKey, industries);
            }

            return new JsonNetResult{ Data = industries};
        }

        [HttpGet]
        public ActionResult Countries()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return new JsonNetResult();

            List<Country> countries;
            if (_cacheProvider.HasKey(CountriesLookupKey))
                countries = (List<Country>)_cacheProvider.Get(CountriesLookupKey);
            else
            {
                countries = UnitOfWork.DocumentSession.Query<Domain.Country>()
                    .Select(i => new Country { Id = i.Id, Name = i.Name })
                    .ToList();
                _cacheProvider.Insert(CountriesLookupKey, countries);
            }

            return new JsonNetResult { Data = countries };
        }

        [HttpGet]
        public ActionResult States()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return new JsonNetResult();

            List<State> states;
            if (_cacheProvider.HasKey(StatesLookupKey))
                states = (List<State>)_cacheProvider.Get(StatesLookupKey);
            else
            {
                states = UnitOfWork.DocumentSession.Query<Domain.State>()
                    .Select(i => new State { Id = i.Id, Name = i.Name, CountryId = i.Country.Id})
                    .ToList();
                _cacheProvider.Insert(StatesLookupKey, states);
            }

            return new JsonNetResult { Data = states };
        }

        [HttpGet]
        public ActionResult Cities()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return new JsonNetResult();

            List<City> cities;
            if (_cacheProvider.HasKey(CitiesLookupKey))
                cities = (List<City>)_cacheProvider.Get(CitiesLookupKey);
            else
            {
                cities = UnitOfWork.DocumentSession.Query<Domain.City>()
                    .Select(i => new City { Id = i.Id, Name = i.Name, StateId = i.State.Id })
                    .ToList();
                _cacheProvider.Insert(CitiesLookupKey, cities);
            }

            return new JsonNetResult { Data = cities };
        }

        [HttpGet]
        public ActionResult Priorities()
        {
            if (!CurrentUserProvider.CurrentUser.IsAuthenticated)
                return new JsonNetResult();

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
