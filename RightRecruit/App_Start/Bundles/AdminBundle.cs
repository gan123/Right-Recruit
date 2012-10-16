using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class AdminBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/admin-view")
                .IncludeDirectory("~/Scripts/app/admin", "*.js", searchSubdirectories: false);
        }
    }
}