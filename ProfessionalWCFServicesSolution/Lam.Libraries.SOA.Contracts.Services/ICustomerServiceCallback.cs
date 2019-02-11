using Lam.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Contracts.Services
{
    public interface ICustomerServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyNewCustomerRecord(Customer newCustomerRecord);
    }
}
