using Lam.Libraries.SOA.Contracts.Data;
using Lam.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Contracts.Services
{
    [ServiceContract(
        Namespace = @"http://schemas.lamresearch.com/contracts/services")]
    public interface ICustomerService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        IEnumerable<Customer> FindCustomers(string customerName);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        Customer GetCustomerDetail(int customerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        bool AddCustomerDetail(Customer customerDetail);
    }
}
