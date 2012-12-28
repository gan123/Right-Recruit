using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class ClientCreateBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/clients-create")
                .IncludeDirectory("~/Scripts/app/clients/new", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/clients", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/lookups", "*.js", searchSubdirectories: false);
        }
    }
}