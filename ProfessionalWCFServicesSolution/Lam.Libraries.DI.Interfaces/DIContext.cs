using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.DI.Interfaces
{
    public static class DIContext
    {
        public static IObjectBuilder Instance { get; set; }
    }
}
