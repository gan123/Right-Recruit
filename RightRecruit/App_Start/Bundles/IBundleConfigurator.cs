using System.Web.Optimization;

namespace RightRecruit.App_Start.Bundles
{
    public interface IBundleConfigurator
    {
        Bundle Create();
    }
}