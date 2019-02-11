using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.DI.Interfaces
{
    public interface IObjectBuilder
    {
        object GetObject(Type serviceType);
        T GetObject<T>();

        object GetObject(Type serviceType, string serviceName);
        T GetObject<T>(string serviceName);
    }
}
