using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class HomeBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/home")
                .IncludeDirectory("~/Scripts/app/home", "*.js", searchSubdirectories: false);
        }
    }
}