using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RightRecruit.Mvc.Infrastructure.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Plumbing;

namespace RightRecruit.Installers
{
    public class MvcInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IControllerActivator>().ImplementedBy<ControllerActivator>(),
                Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>(),
                Component.For<ICurrentUserProvider>().ImplementedBy<CurrentUserProvider>(),
                Component.For<HttpSessionStateBase>().LifeStyle.PerWebRequest
                .UsingFactoryMethod(() => new HttpSessionStateWrapper(HttpContext.Current.Session)));
        }
    }
}