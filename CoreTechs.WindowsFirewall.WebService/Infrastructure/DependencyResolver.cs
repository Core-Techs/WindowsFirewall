using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using CoreTechs.Logging;

namespace CoreTechs.WindowsFirewall.WebService.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        public void Dispose()
        {
            
        }

        public object GetService(Type type)
        {
            if (type == typeof (FirewallController))
                return new FirewallController(GetService<IWinFirewallApi>(), GetService<LogManager>());

            if (type == typeof (IWinFirewallApi))
                return AppSettings.FirewallApi;

            if (type == typeof (LogManager))
                return LogManager.Global;

            return null;
        }

        public T GetService<T>()
        {
            return (T) GetService(typeof (T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new object[0];
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}