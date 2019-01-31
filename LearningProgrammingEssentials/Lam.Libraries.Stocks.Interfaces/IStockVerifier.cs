using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Stocks.Interfaces
{
    public interface IStockVerifier
    {
        bool VerifiyStockAvailability(int productId, int units);
    }
}
