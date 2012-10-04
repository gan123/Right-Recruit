using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RightRecruit.Controllers;

namespace RightRecruit.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<InboxController>().ImplementedBy<InboxController>().LifeStyle.Transient,
                Component.For<HomeController>().ImplementedBy<HomeController>().LifeStyle.Transient,
                Component.For<ClientController>().ImplementedBy<ClientController>().LifeStyle.Transient,
                Component.For<LookupController>().ImplementedBy<LookupController>().LifeStyle.Transient,
                Component.For<StyleController>().ImplementedBy<StyleController>().LifeStyle.Transient,
                Component.For<AdminController>().ImplementedBy<AdminController>().LifeStyle.Transient);
        }
    }
}