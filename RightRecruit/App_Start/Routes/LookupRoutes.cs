using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class LookupRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                name: "IndustriesLookup",
                url: "lookup/industries",
                defaults: new { controller = "Lookup", action = "Industries" }
                );

            routes.MapRoute(
                name: "CountriesLookup",
                url: "lookup/countries",
                defaults: new { controller = "Lookup", action = "Countries" }
                );

            routes.MapRoute(
                name: "StatesLookup",
                url: "lookup/states",
                defaults: new { controller = "Lookup", action = "States" }
                );

            routes.MapRoute(
                name: "CitiesLookup",
                url: "lookup/cities",
                defaults: new { controller = "Lookup", action = "Cities" }
                );

            routes.MapRoute(
                name: "PrioritiesLookup",
                url: "lookup/priorities",
                defaults: new { controller = "Lookup", action = "Priorities" }
                );
        }
    }
}