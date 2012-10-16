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

            routes.MapRoute(
                name: "Admin-Theme-Details",
                url: "admin/personalize/get",
                defaults: new { controller = "Admin", action = "GetPersonalizedTheme" }
                );

            routes.MapRoute(
                name: "Admin-Theme-Save",
                url: "admin/personalize/save",
                defaults: new { controller = "Admin", action = "SaveTheme" }
                );
        }
    }
}