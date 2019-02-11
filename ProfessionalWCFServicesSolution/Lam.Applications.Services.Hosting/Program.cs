using Lam.Libraries.DI.Impl;
using Lam.Libraries.DI.Interfaces;
using Lam.Libraries.SOA.Extensibility;
using Lam.Libraries.SOA.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.Services.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            DIContext.Instance = UnityObjectBuilder.Instance;

            using (var serviceHost = new LamInstancingServiceHost(typeof(CustomerDuplexService)))
            //using (var webServiceHost = new WebServiceHost(typeof(CustomerService)))
            {
                serviceHost.Opened += (sender, arguments) =>
                 {
                     Console.WriteLine("Service Host is Ready!");
                 };

                serviceHost.Closed += (sender, arguments) =>
                {
                    Console.WriteLine("Service is Closed!");
                };

                //webServiceHost.Opened += (sender, arguments) => Console.WriteLine("REST service is Ready!");
                //webServiceHost.Closed += (sender, arguments) => Console.WriteLine("REST service is Closed!");

                serviceHost.Open();
                //webServiceHost.Open();

                Console.WriteLine("Press [ENTER] to stop both the hosts!");
                Console.ReadLine();
            }
        }
    }
}
