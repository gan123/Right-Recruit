using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class ClientRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ClientsPage",
                url: "clients",
                defaults: new { controller = "Client", action = "List" }
                );

            routes.MapRoute(
                name: "ClientsQuickSearch",
                url: "clients/quicksearch",
                defaults: new { controller = "Client", action = "QuickSearch" }
                );

            routes.MapRoute(
                name: "ClientsSearch",
                url: "clients/search",
                defaults: new { controller = "Client", action = "Search" }
                );

            routes.MapRoute(
                name: "ClientsNew",
                url: "clients/new",
                defaults: new { controller = "Client", action = "New" }
                );

            routes.MapRoute(
                name: "ClientsCreate",
                url: "clients/create",
                defaults: new { controller = "Client", action = "Create" }
                );
        }
    }
}