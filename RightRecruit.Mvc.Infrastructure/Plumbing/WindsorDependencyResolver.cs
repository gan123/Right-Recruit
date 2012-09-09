using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace RightRecruit.Mvc.Infrastructure.Plumbing
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _windsorContainer;

        public WindsorDependencyResolver(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        public object GetService(Type serviceType)
        {
            return TryResolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _windsorContainer.ResolveAll(serviceType).Cast<object>();
        }

        private object TryResolve(Type serviceType)
        {
            if (_windsorContainer.Kernel.HasComponent(serviceType))
                return _windsorContainer.Resolve(serviceType);
            return null;
        }
    }
}