using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Contracts.Services
{
    [ServiceContract(
        Namespace = @"http://schemas.lamresearch.com/contracts/",
        CallbackContract = typeof(ICustomerServiceCallback))]
    public interface ICustomerDuplexService : ICustomerService
    {
        [OperationContract]
        void RegisterUIType(string uiType);
    }
}
