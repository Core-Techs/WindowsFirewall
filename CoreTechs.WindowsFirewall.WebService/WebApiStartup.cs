using System.Web.Http;
using CoreTechs.Logging;
using CoreTechs.WindowsFirewall.WebService.Infrastructure;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>,System.Threading.Tasks.Task>;

namespace CoreTechs.WindowsFirewall.WebService
{
    public class WebApiStartup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.Use<RequestLogger>(LogManager.Global);

            config.DependencyResolver = new DependencyResolver();
            appBuilder.UseWebApi(config);
        }
    }
}