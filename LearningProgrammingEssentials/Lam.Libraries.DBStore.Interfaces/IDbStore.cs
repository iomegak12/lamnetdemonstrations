using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.DBStore.Interfaces
{
    public interface IDbStore
    {
        bool SaveOrderToDb(OnlineOrder onlineOrder);
    }
}
