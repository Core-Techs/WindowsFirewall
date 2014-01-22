using System;
using System.ServiceProcess;
using CoreTechs.Logging;
using CoreTechs.WindowsFirewall.WebService.Infrastructure;

namespace CoreTechs.WindowsFirewall.WebService
{
    static class Program
    {
        private static readonly Logger Log = SetupLogging();

        private static Logger SetupLogging()
        {
            var lm = LogManager.Global = LogManager.Configure("logging");
            var log = lm.CreateLogger();

            lm.UnhandledLoggingException +=
                (sender, args) => log.Exception(args.Exception).Error("Unhandled Logging Exception");

            return log;
        }

        private static void Main(string[] args)
        {
            var singleGlobalInstance = Attempt.Get(() => new SingleGlobalInstance()).Value;
            if (singleGlobalInstance == null)
            {
                if (!Environment.UserInteractive) return;
                Console.WriteLine("Another instance of the application is running. Press any key to exit.");
                Console.ReadKey();
                return;
            }

            using (singleGlobalInstance)
            {
                var svcs = new ServiceBase[]
                {
                    new FirewallService()
                };

                if (Environment.UserInteractive)
                {
                    foreach (var svc in svcs)
                        svc.Start(args);
                    
                    Console.WriteLine("Press Enter to stop the service...");
                    Console.ReadLine();

                    foreach (var svc in svcs)
                        svc.Stop();

                    Console.WriteLine("The service is stopped. Press Enter to terminate...");
                    Console.ReadLine();
                }
                else
                {
                    ServiceBase.Run(svcs);
                }

                // wait for any straggling async log entries
                LogManager.Global.Dispose();
            }
        }
    }
}