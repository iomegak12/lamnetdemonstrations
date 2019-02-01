using Lam.Libraries.SOA.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.Services.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceHost = new ServiceHost(typeof(CustomerService)))
            {
                serviceHost.Opened += (sender, arguments) =>
                 {
                     Console.WriteLine("Service Host is Ready!");
                 };

                serviceHost.Closed += (sender, arguments) =>
                {
                    Console.WriteLine("Service is Closed!");
                };

                serviceHost.Open();

                Console.WriteLine("Press [ENTER] to stop the host!");
                Console.ReadLine();
            }
        }
    }
}
