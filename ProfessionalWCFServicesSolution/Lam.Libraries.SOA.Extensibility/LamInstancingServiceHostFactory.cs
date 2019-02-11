using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Extensibility
{
    public class LamInstancingServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var instancingServiceHost = new LamInstancingServiceHost(serviceType, baseAddresses);

            return instancingServiceHost;
        }
    }
}
