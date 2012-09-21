using System.Web;
using System.Web.Optimization;
using RightRecruit.Helpers;

namespace RightRecruit
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Force optimization to be on or off, regardless of web.config setting
            //BundleTable.EnableOptimizations = false;
            bundles.UseCdn = false;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            // Modernizr goes separate since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-{version}.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js")
                .Include("~/Scripts/lib/jquery-{version}.js",
                "~/Scripts/lib/jquery-ui-1.8.23.custom.min.js"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
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
                    "~/Scripts/lib/toastr.js"
                    ));

            // Text editor
            bundles.Add(new ScriptBundle("~/bundles/texteditor")
                .Include(
                "~/Scripts/lib/jquery.wysiwyg.js",
                "~/Scripts/lib/wysiwyg.*"));

            // TODO : All application JS files (except mocks)
            bundles.Add(new ScriptBundle("~/bundles/jsappglobals")
                            .IncludeDirectory("~/Scripts/app/common", "*.js", searchSubdirectories: false)
                            .IncludeDirectory("~/Scripts/app/search", "*.js", searchSubdirectories: false)
                            .IncludeDirectory("~/Scripts/app/lookups", "*.js", searchSubdirectories: false)
                            .IncludeDirectory("~/Scripts/app/global", "*.js", searchSubdirectories: false));

            // Home bundle
            bundles.Add(new ScriptBundle("~/bundles/home")
                .IncludeDirectory("~/Scripts/app/home", "*.js", searchSubdirectories: false));

            // Inbox bundle
            bundles.Add(new ScriptBundle("~/bundles/inbox")
                .IncludeDirectory("~/Scripts/app/inbox", "*.js", searchSubdirectories: false));

            // Clients list bundle
            bundles.Add(new ScriptBundle("~/bundles/clients-list")
                .IncludeDirectory("~/Scripts/app/clients/list", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/clients", "*.js", searchSubdirectories: false));

            // Clients create bundle
            bundles.Add(new ScriptBundle("~/bundles/clients-create")
                .IncludeDirectory("~/Scripts/app/clients/new", "*.js", searchSubdirectories: false)
                .IncludeDirectory("~/Scripts/app/clients", "*.js", searchSubdirectories: false));

            // 3rd Party CSS files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/themes/custom/jquery-ui-1.8.23.custom.css",
                "~/Content/boilerplate-styles.css",
                "~/Content/toastr.css",
                "~/Content/toastr-responsive.css"));

            // Text editor
            bundles.Add(new Bundle("~/Content/texteditorStyles", new LessTransform(), new CssMinify())
                .Include("~/Content/jquery.wysiwyg.css"));

            // Custom LESS files
            bundles.Add(new Bundle("~/Content/less", new LessTransform(), new CssMinify())
                .Include("~/Content/styles.less"));
        }
    }
}