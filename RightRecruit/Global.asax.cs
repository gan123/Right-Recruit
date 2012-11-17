using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using RightRecruit.App_Start;
using RightRecruit.App_Start.Bundles;
using RightRecruit.App_Start.Routes;
using RightRecruit.Installers;
using RightRecruit.Mvc.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Infrastructure;
using RightRecruit.Mvc.Infrastructure.Plumbing;

namespace RightRecruit
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            AuthConfig.RegisterAuth();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ConventionBasedResolver(container.Kernel));
            container.Install(
                new MvcInstaller(),
                new ControllerInstaller(),
                new InfastructureInstaller());

            DependencyResolver.SetResolver(new WindsorDependencyResolver(container));
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Timeout = 60;
            HttpContext.Current.Session[Globals.CurrentUser] = new CurrentUser(null);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}