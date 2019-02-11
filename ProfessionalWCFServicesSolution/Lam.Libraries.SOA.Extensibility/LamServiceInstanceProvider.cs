using Lam.Libraries.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Extensibility
{
    public class LamServiceInstanceProvider : IInstanceProvider
    {
        private IObjectBuilder objectBuilder = DIContext.Instance;
        private Type serviceType = default(Type);

        public LamServiceInstanceProvider(Type serviceType)
        {
            if (objectBuilder == default(IObjectBuilder))
                throw new ApplicationException("Invalid Object Build Reference Provided!");

            if (serviceType == default(Type))
                throw new ArgumentNullException(nameof(serviceType));

            this.serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            var resolvedObject = this.objectBuilder.GetObject(this.serviceType);

            return resolvedObject;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            instance = default(object);
        }
    }
}
