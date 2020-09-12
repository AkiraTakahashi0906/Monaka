using Monaka.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monaka
{
    public partial class Monaka : ServiceBase
    {
        private static log4net.ILog _logger =
log4net.LogManager.GetLogger(
System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Threading.Timer _timer;
        private Random _random = new Random();

        public Monaka()
        {
            InitializeComponent();
            _timer = new System.Threading.Timer(Timer_Callback,
                                                                      null,
                                                                      Timeout.Infinite,
                                                                      Timeout.Infinite);
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("start");
            _timer.Change(0, 1000);
        }

        protected override void OnStop()
        {
            _logger.Info("stop");
        }

        internal void DebugRun()
        {
            OnStart(null);
            Console.ReadLine();
            OnStop();
        }

        private void Timer_Callback(object o)
        {
            try
            {
                _logger.Info("Timer_Callback");
                var measure = new MeasureSQLServer();
                measure.Insert(DateTime.Now, Convert.ToSingle(_random.NextDouble()));
            }
            catch(Exception ex)
            {
                _logger.Error("Timer_Callback error!!!", ex);
            }
        }
    }
}
