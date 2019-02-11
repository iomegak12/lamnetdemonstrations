using Lam.Libraries.SOA.Proxies.Callbacks;
using Lam.Libraries.SOA.Proxies.CRMSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.CRMSystem.CmdUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press [ENTER] to add new customer record ...");
                Console.ReadLine();

                var callbackHandler = new CustomerServiceCallbackHandler();

                using (var proxy = new CustomerDuplexServiceClient(
                    new InstanceContext(callbackHandler)))
                {
                    proxy.RegisterUIType("CUI");

                    var newCustomerRecord = new Customer
                    {
                        CustomerId = 999,
                        CustomerName = "Kinley Waterservices",
                        Address = "Bangalore",
                        CreditLimit = 23000,
                        ActiveStatus = true,
                        Email = "info@email.com",
                        PhoneNumber = "080-39489834",
                        Remarks = "Simple Customer Record"
                    };

                    var status = proxy.AddCustomerDetail(newCustomerRecord);

                    Console.WriteLine("Customer Add Transaction Status : " + status);
                }
            }
            catch (Exception exceptionObject)
            {
                Console.WriteLine($"Error Occurred, Details : {exceptionObject.Message}");
            }

            Console.WriteLine("End of Application!");
            Console.ReadLine();
        }
    }
}
