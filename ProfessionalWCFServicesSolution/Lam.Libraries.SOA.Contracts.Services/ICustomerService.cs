using Lam.Libraries.SOA.Contracts.Data;
using Lam.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
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
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/all")]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/search/{customerName}")]
        IEnumerable<Customer> FindCustomers(string customerName);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/details?id={customerId}")]
        Customer GetCustomerDetail(int customerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/save")]
        bool AddCustomerDetail(Customer customerDetail);
    }
}
