using System.Web;
using System.Web.Mvc;
using RightRecruit.Mvc.Infrastructure.Filters;

namespace RightRecruit
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RavenActionFilter());
        }
    }
}