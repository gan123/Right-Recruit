using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class StyleRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Css",
                url: "style/css",
                defaults: new { controller = "Style", action = "Css" }
                );
        }
    }
}