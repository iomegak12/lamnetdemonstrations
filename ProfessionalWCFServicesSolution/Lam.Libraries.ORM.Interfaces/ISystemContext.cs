using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.ORM.Interfaces
{
    public interface ISystemContext : IDisposable
    {
        bool CommitChanges();
    }
}
