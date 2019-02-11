using Lam.Libraries.ORM.Interfaces;
using Lam.Libraries.SOA.Contracts.Data;
using Lam.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Impl
{
    [ServiceBehavior(
        Namespace = @"http://schemas.lamresearch.com/behaviors/services")]
    public class CustomerDuplexService : CustomerService, ICustomerDuplexService
    {
        private const int MIN_CALLBACKS = 1;
        private static List<ICustomerServiceCallback> registeredCallbacks = default(List<ICustomerServiceCallback>);

        static CustomerDuplexService()
        {
            registeredCallbacks = new List<ICustomerServiceCallback>();
        }

        public CustomerDuplexService(ICustomersContext customersContext) : base(customersContext) { }

        public override bool AddCustomerDetail(Customer customerDetail)
        {
            var status = base.AddCustomerDetail(customerDetail);

            if (status)
            {
                if (registeredCallbacks != default(List<ICustomerServiceCallback>) &&
                    registeredCallbacks.Count >= MIN_CALLBACKS)
                {
                    Parallel.ForEach<ICustomerServiceCallback>(
                        registeredCallbacks,
                        callback =>
                        {
                            try
                            {
                                if (callback != default(ICustomerServiceCallback))
                                    callback.NotifyNewCustomerRecord(customerDetail);
                            }
                            catch { }
                        });
                }
            }

            return status;
        }

        [OperationBehavior]
        public void RegisterUIType(string uiType)
        {
            if (uiType.Equals("GUI", StringComparison.OrdinalIgnoreCase))
            {
                var callbackChannel = OperationContext.Current.GetCallbackChannel<ICustomerServiceCallback>();

                if (callbackChannel != default(ICustomerServiceCallback))
                    registeredCallbacks.Add(callbackChannel);
            }
        }
    }
}
