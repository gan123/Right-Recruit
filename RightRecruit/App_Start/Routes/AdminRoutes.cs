using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class AdminRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
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
        }
    }
}