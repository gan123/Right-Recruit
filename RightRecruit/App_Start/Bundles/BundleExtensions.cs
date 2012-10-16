using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public static class BundleExtensions
    {
        public static void BundleUp(this BundleCollection bundles, params IBundleConfigurator[] configurators)
        {
            foreach(var configurator in configurators)
                bundles.Add(configurator.Create());
        }
    }
}