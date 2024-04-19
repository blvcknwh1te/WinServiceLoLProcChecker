using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CustomService
{
    internal static class Program
    {
        public static string serviceName = "Microsoft Custom Serivce";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new CustomService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
