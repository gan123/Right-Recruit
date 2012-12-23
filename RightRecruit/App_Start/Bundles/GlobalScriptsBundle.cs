using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class GlobalScriptsBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/jsappglobals")
                .IncludeDirectory("~/Scripts/app/common", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/search", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/lookups", "*.js", searchSubdirectories: false)
                .Include("~/Scripts/app/global/binder.js");
        }
    }
}