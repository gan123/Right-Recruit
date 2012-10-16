using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class HomeRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
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
        }
    }
}