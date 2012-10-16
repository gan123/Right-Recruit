using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public class TextEditorBundle : IBundleConfigurator
    {
        public Bundle Create()
        {
            return new ScriptBundle("~/bundles/texteditor")
                .Include(
                    "~/Scripts/lib/jquery.wysiwyg.js",
                    "~/Scripts/lib/wysiwyg.*");
        }
    }
}