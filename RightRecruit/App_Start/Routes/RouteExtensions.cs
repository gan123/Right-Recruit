using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public static class RouteExtensions
    {
         public static void Configure(this RouteCollection routes, params IRouteConfigurator[] configurators)
         {
             foreach(var configurator in configurators)
                 configurator.Map(routes);
         }
    }
}