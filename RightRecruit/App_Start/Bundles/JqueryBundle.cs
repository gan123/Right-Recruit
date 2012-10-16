using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class JqueryBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/jquery",
                                    "//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js")
                .Include("~/Scripts/lib/jquery-{version}.js",
                         "~/Scripts/lib/jquery-ui-1.8.23.custom.min.js");
        }
    }
}