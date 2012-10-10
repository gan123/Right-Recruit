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
                defaults: new {controller = "Inbox", action = "Inbox"}
                );

            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new {controller = "Home", action = "Home"}
                );

            routes.MapRoute(
                name: "LoginVerify",
                url: "login",
                defaults: new {controller = "Home", action = "Login"}
                );

            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new {controller = "Home", action = "Logout"}
                );

            routes.MapRoute(
                name: "ClientsPage",
                url: "clients",
                defaults: new {controller = "Client", action = "List"}
                );

            routes.MapRoute(
                name: "ClientsQuickSearch",
                url: "clients/quicksearch",
                defaults: new {controller = "Client", action = "QuickSearch"}
                );

            routes.MapRoute(
                name: "ClientsSearch",
                url: "clients/search",
                defaults: new {controller = "Client", action = "Search"}
                );

            routes.MapRoute(
                name: "ClientsNew",
                url: "clients/new",
                defaults: new {controller = "Client", action = "New"}
                );

            routes.MapRoute(
                name: "ClientsCreate",
                url: "clients/create",
                defaults: new {controller = "Client", action = "Create"}
                );

            routes.MapRoute(
                name: "IndustriesLookup",
                url: "lookup/industries",
                defaults: new {controller = "Lookup", action = "Industries"}
                );

            routes.MapRoute(
                name: "CountriesLookup",
                url: "lookup/countries",
                defaults: new {controller = "Lookup", action = "Countries"}
                );

            routes.MapRoute(
                name: "StatesLookup",
                url: "lookup/states",
                defaults: new {controller = "Lookup", action = "States"}
                );

            routes.MapRoute(
                name: "CitiesLookup",
                url: "lookup/cities",
                defaults: new {controller = "Lookup", action = "Cities"}
                );

            routes.MapRoute(
                name: "PrioritiesLookup",
                url: "lookup/priorities",
                defaults: new {controller = "Lookup", action = "Priorities"}
                );

            routes.MapRoute(
                name: "Css",
                url: "style/css",
                defaults: new {controller = "Style", action = "Css"}
                );

            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Admin", action = "Admin" }
                );

            routes.MapRoute(
                name: "Admin-Theme",
                url: "admin/personalize",
                defaults: new { controller = "Admin", action = "Personalize" }
                );

            routes.MapRoute(
                "RenderImage",
                "image/{file}",
                new {controller = "Image", action = "Render", file = ""}
                );

            routes.MapRoute(
                "RenderImageWithResizeAndWatermark",
                "image/{width}/{height}/w/{file}",
                new
                    {
                        controller = "Image",
                        action = "RenderWithResizeAndWatermark",
                        width = "",
                        height = "",
                        file = ""
                    }
                );
            routes.MapRoute(
                "RenderImageWithResize",
                "image/{width}/{height}/{file}",
                new
                    {
                        controller = "Image",
                        action = "RenderWithResize",
                        width = "",
                        height = "",
                        file = ""
                    }
                );
        }
    }
}