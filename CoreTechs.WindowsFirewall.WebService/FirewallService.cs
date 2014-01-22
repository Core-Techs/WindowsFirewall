using System;
using System.ServiceProcess;
using CoreTechs.Logging;
using CoreTechs.WindowsFirewall.WebService.Infrastructure;
using Microsoft.Owin.Hosting;

namespace CoreTechs.WindowsFirewall.WebService
{
    partial class FirewallService : ServiceBase
    {
        private static readonly Logger Log = LogManager.Global.CreateLogger();
        private IDisposable _httpServer;

        public FirewallService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _httpServer = WebApp.Start<WebApiStartup>(AppSettings.ServiceUrl);
            Log.Data("URL", AppSettings.ServiceUrl).Info("Started HTTP server.");
        }

        protected override void OnStop()
        {
            _httpServer.Dispose();
        }
    }
}
