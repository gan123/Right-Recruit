using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class InboxBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/inbox")
                .IncludeDirectory("~/Scripts/app/inbox", "*.js", searchSubdirectories: false);
        }
    }
}