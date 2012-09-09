using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;

namespace RightRecruit.Mvc.Infrastructure.Plumbing
{
    public class WindsorViewPageActivator : IViewPageActivator
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorViewPageActivator"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public WindsorViewPageActivator(IKernel kernel)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            _kernel = kernel;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            if (!_kernel.HasComponent(type.FullName))
            {
                _kernel.Register(Component.For(type).Named(type.FullName).Activator<ViewPageComponentActivator>().LifestyleTransient());
            }
            return _kernel.Resolve(type.FullName, type);
        }
    }
}