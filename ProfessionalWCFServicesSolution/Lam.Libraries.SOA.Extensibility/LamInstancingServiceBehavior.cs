using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Extensibility
{
    public class LamInstancingServiceBehavior : IServiceBehavior
    {
        private Type serviceType = default(Type);

        public LamInstancingServiceBehavior(Type serviceType)
        {
            if (serviceType == default(Type))
                throw new ArgumentNullException(nameof(serviceType));

            this.serviceType = serviceType;
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var instanceProvider = new LamServiceInstanceProvider(this.serviceType);
            var channelDispatchers = serviceHostBase.ChannelDispatchers;

            foreach (ChannelDispatcher dispatcher in channelDispatchers)
            {
                var endpoints = dispatcher.Endpoints;

                foreach (var endpoint in endpoints)
                {
                    endpoint.DispatchRuntime.InstanceProvider = instanceProvider;
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
}
