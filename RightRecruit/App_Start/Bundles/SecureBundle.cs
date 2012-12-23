using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class SecureBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/secure")
                .IncludeDirectory("~/Scripts/app/secure", "*.js", searchSubdirectories: false);
        }
    }
}