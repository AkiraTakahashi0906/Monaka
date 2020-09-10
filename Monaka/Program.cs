using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Monaka
{
    static class Program
    {
        private static log4net.ILog _logger =
log4net.LogManager.GetLogger(
System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                _logger.Info("AAAA");
                var service = new Monaka();
                service.DebugRun();
            }
            else
            {
                _logger.Info("BBBB");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Monaka()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
