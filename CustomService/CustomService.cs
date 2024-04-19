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

namespace CustomService
{
    public partial class CustomService : ServiceBase
    {
        public CustomService()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            checker.Check();
            try
            {
                Thread checkerThread = new Thread(() => checker.Start());
                checkerThread.Start();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Constr: " + ex.Message);
            }
        }

        protected override void OnStop()
        {
            checker.Stop();
        }
    }
}
