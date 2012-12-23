using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
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

            bundles.BundleUp(
                new SecureBundle(),
                new ModernizerBundle(),
                new JqueryBundle(),
                new ThirdPartyJsBundle(),
                new TextEditorBundle(),
                new GlobalScriptsBundle(),
                new HomeBundle(),
                new InboxBundle(),
                new ClientsListBundle(),
                new ClientCreateBundle(),
                new AdminBundle(),
                new PersonalizeBundle(),
                new ExternalCssBundle());
        }
    }
}