﻿using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace RightRecruit.Mvc.Infrastructure.Plumbing
{
    public class ConventionBasedResolver : ISubDependencyResolver
    {
        private readonly IKernel _kernel;
        private readonly IDictionary<DependencyModel, string> _knownDependencies = new Dictionary<DependencyModel, string>();

        public ConventionBasedResolver(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            _kernel = kernel;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            if (_knownDependencies.ContainsKey(dependency)) return true;

            var handlers = _kernel.GetHandlers(dependency.TargetType);

            // if theres just one, we're not interested
            if (handlers.Length < 2) return false;

            foreach (var handler in handlers)
            {
                if (IsMatch(handler.ComponentModel, dependency) && handler.CurrentState == HandlerState.Valid)
                {
                    if (!handler.ComponentModel.Name.EndsWith(dependency.DependencyKey, StringComparison.Ordinal))
                    {
                        _knownDependencies.Add(dependency, handler.ComponentModel.Name);
                    }
                    return true;
                }
            }
            return false;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            string componentName = null;
            if (!_knownDependencies.ContainsKey(dependency))
                componentName = dependency.DependencyKey;
            return _kernel.Resolve(componentName, dependency.TargetType);
        }

        private static bool IsMatch(ComponentModel model, DependencyModel dependency)
        {
            return dependency.DependencyKey.EndsWith(model.Implementation.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}