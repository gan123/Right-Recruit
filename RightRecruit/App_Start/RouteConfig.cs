using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Inbox",
                url: "inbox",
                defaults: new { controller = "Inbox", action = "Inbox" }
            );

            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Home" }
            );

            routes.MapRoute(
                name: "LoginVerify",
                url: "login",
                defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "Home", action = "Logout" }
            );

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