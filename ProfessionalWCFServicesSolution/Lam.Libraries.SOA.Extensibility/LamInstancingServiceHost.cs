using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Extensibility
{
    public class LamInstancingServiceHost : ServiceHost
    {
        public LamInstancingServiceHost(
            Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
            var instancingBehavior = new LamInstancingServiceBehavior(serviceType);

            Description.Behaviors.Add(instancingBehavior);
        }
    }
}
