using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class ExternalCssBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new StyleBundle("~/Content/css").Include(
                "~/Content/themes/custom/jquery-ui-1.8.23.custom.css",
                "~/Content/boilerplate-styles.css",
                "~/Content/jquery.qtip.css",
                "~/Content/toastr.css",
                "~/Content/toastr-responsive.css",
                "~/Content/colorpicker.css");
        }
    }
}