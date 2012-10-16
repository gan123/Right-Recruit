using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class ThirdPartyJsBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/jsextlibs")
                //.IncludeDirectory("~/Scripts/lib", "*.js", searchSubdirectories: false));
                .Include(
                    "~/Scripts/lib/json2.js", // IE7 needs this

                    // jQuery plugins
                    "~/Scripts/lib/jquery.mockjson.js",
                    "~/Scripts/lib/TrafficCop.js",
                    "~/Scripts/lib/infuser.js", // depends on TrafficCop

                    // Knockout and its plugins
                    "~/Scripts/lib/knockout-{version}.js",
                    "~/Scripts/lib/knockout.activity.js",
                    "~/Scripts/lib/knockout.asyncCommand.js",
                    "~/Scripts/lib/knockout.dirtyFlag.js",
                    "~/Scripts/lib/knockout.validation.js",
                    "~/Scripts/lib/koExternalTemplateEngine.js",

                    // Other 3rd party libraries
                    "~/Scripts/lib/underscore.js",
                    "~/Scripts/lib/moment.js",
                    "~/Scripts/lib/sammy.*",
                    "~/Scripts/lib/amplify.*",
                    "~/Scripts/lib/toastr.js",
                    "~/Scripts/lib/jquery.qtip.js",
                    "~/Scripts/lib/utils.js",
                    "~/Scripts/lib/colorpicker.js");
        }
    }
}