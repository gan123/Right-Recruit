using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public interface IRouteConfigurator
    {
        void Map(RouteCollection routes);
    }
}