using Lam.Libraries.CreditCards.Impl;
using Lam.Libraries.CreditCards.Interfaces;
using Lam.Libraries.DBStore.Impl;
using Lam.Libraries.DBStore.Interfaces;
using Lam.Libraries.DI.Interfaces;
using Lam.Libraries.Orders.Impl;
using Lam.Libraries.Orders.Interfaces;
using Lam.Libraries.Stocks.Impl;
using Lam.Libraries.Stocks.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Lam.Libraries.DI.Impl
{
    public class LamObjectBuilder : IObjectBuilder
    {
        private IUnityContainer unityContainer = default(IUnityContainer);

        private LamObjectBuilder()
        {
            unityContainer = new UnityContainer().LoadConfiguration();

            //unityContainer.RegisterType<IStockVerifier, StockVerifierImpl>();
            //unityContainer.RegisterType<ICreditCardValidator, VisaCreditCardValidator>();
            //unityContainer.RegisterType<IDbStore, DbStoreImpl>();
            //unityContainer.RegisterType<IOnlineOrderProcessor, OnlineOrderProcessorImpl>();
        }

        public object GetObject(Type serviceType)
        {
            return unityContainer.Resolve(serviceType);
        }

        public T GetObject<T>()
        {
            return unityContainer.Resolve<T>();
        }

        #region Singleton Implementation

        private static IObjectBuilder objectBuilder = default(IObjectBuilder);

        public static IObjectBuilder Instance
        {
            get
            {
                if (objectBuilder == default(IObjectBuilder))
                    objectBuilder = new LamObjectBuilder();

                return objectBuilder;
            }
        }

        #endregion
    }
}
