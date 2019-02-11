using Lam.Libraries.DI.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Lam.Libraries.DI.Impl
{
    public class UnityObjectBuilder : IObjectBuilder
    {
        private IUnityContainer container = default(IUnityContainer);

        private UnityObjectBuilder()
        {
            this.container = new UnityContainer().LoadConfiguration();
        }

        public object GetObject(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public T GetObject<T>()
        {
            return this.container.Resolve<T>();
        }

        public object GetObject(Type serviceType, string serviceName)
        {
            return this.container.Resolve(serviceType, serviceName);
        }

        public T GetObject<T>(string serviceName)
        {
            return this.container.Resolve<T>(serviceName);
        }

        #region Singleton Implementation

        private static IObjectBuilder objectBuilder = default(IObjectBuilder);

        static UnityObjectBuilder()
        {
            objectBuilder = new UnityObjectBuilder();
        }

        public static IObjectBuilder Instance { get { return objectBuilder; } }

        #endregion
    }
}
