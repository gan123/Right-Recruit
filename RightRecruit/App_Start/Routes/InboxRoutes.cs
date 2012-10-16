using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class InboxRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Inbox",
                url: "inbox",
                defaults: new { controller = "Inbox", action = "Inbox" }
                );
        }
    }
}