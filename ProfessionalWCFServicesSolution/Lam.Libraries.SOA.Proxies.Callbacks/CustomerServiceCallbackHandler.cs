using Lam.Libraries.SOA.Proxies.CRMSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Proxies.Callbacks
{
    public class CustomerServiceCallbackHandler : ICustomerDuplexServiceCallback
    {
        public event Action<Customer> NewCustomerRecordAdded;

        public void NotifyNewCustomerRecord(Customer newCustomerRecord)
        {
            Debug.WriteLine("Notification Received ... " +
                Process.GetCurrentProcess().ProcessName + ", " +
                newCustomerRecord.CustomerId + ", " +
                newCustomerRecord.CustomerName);

            if (this.NewCustomerRecordAdded != default(Action<Customer>))
            {
                this.NewCustomerRecordAdded(newCustomerRecord);
            }
        }
    }
}
