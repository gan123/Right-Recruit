using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class ModernizerBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-{version}.js");
        }
    }
}