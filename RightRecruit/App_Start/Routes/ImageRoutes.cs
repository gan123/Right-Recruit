using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.App_Start.Routes
{
    public class ImageRoutes : IRouteConfigurator
    {
        public void Map(RouteCollection routes)
        {
            routes.MapRoute(
                "RenderImage",
                "image/{file}",
                new { controller = "Image", action = "Render", file = "" }
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