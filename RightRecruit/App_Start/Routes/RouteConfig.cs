using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Configure(
                new InboxRoutes(),
                new HomeRoutes(),
                new ClientRoutes(),
                new LookupRoutes(),
                new StyleRoutes(),
                new AdminRoutes(),
                new ImageRoutes());
        }
    }
}