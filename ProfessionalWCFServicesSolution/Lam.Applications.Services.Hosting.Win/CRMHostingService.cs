using Lam.Libraries.SOA.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.Services.Hosting.Win
{
    public partial class CRMHostingService : ServiceBase
    {
        private ServiceHost serviceHost = default(ServiceHost);

        public CRMHostingService()
        {
            InitializeComponent();

            this.serviceHost = new ServiceHost(typeof(CustomerDuplexService));

            this.serviceHost.Opened += (sender, args) =>
            {
                EventLog.WriteEntry("CRM System Services Started Successfully!");
            };

            this.serviceHost.Closed += (sender, args) =>
            {
                EventLog.WriteEntry("CRM System Services Stopped Successfully!");
            };
        }

        protected override void OnStart(string[] args)
        {
            this.serviceHost.Open();
        }

        protected override void OnStop()
        {
            this.serviceHost.Close();
        }
    }
}
