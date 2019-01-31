using Lam.Libraries.Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Stocks.Impl
{
    public class StockVerifierImpl : IStockVerifier
    {
        private static Dictionary<int, int> REGISTERED_PRODUCTS = new Dictionary<int, int>
        {
            { 10, 100 },
            { 11, 200 },
            { 12, 300 },
            { 14, 400 },
            { 15, 500 }
        };

        public bool VerifiyStockAvailability(int productId, int units)
        {
            var isProductValid = productId != default(int) &&
                REGISTERED_PRODUCTS.ContainsKey(productId);

            if (!isProductValid)
            {
                throw new ArgumentNullException("Invalid Product Id Specified!", nameof(productId));
            }

            var availableUnits = REGISTERED_PRODUCTS[productId];
            var isStockAvailable = availableUnits >= units;

            return isStockAvailable;
        }
    }
}
