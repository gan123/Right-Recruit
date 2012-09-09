using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace RightRecruit.Mvc.Infrastructure.Plumbing
{
    public class ControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}