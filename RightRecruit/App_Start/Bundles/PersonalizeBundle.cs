using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class PersonalizeBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/personalize")
                .IncludeDirectory("~/Scripts/app/admin/personalize", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/admin/services", "*.js", searchSubdirectories: false);
        }
    }
}