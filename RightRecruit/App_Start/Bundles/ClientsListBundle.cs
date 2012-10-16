using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class ClientsListBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/clients-list")
                .IncludeDirectory("~/Scripts/app/clients/list", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/clients", "*.js", searchSubdirectories: false);
        }
    }
}