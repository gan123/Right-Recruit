using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class SecureRoutes: IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Secure", action = "Login" }
                );

            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "Secure", action = "Logout" }
                );
        }
    }
}