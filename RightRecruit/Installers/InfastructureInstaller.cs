using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RightRecruit.Mvc.Infrastructure.CacheProvider;

namespace RightRecruit.Installers
{
    public class InfastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICacheProvider>().ImplementedBy<CacheProvider>());
        }
    }
}