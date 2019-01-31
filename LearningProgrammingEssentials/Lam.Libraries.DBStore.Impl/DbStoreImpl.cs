using Lam.Libraries.DBStore.Interfaces;
using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.DBStore.Impl
{
    public class DbStoreImpl : IDbStore
    {
        private const int MIN_ORDER_AMOUNT = 1;

        public bool SaveOrderToDb(OnlineOrder onlineOrder)
        {
            const bool SUCCESS = true;

            var validation = onlineOrder != default(OnlineOrder) &&
                onlineOrder.OrderRefNumber != default(int) &&
                onlineOrder.Amount >= MIN_ORDER_AMOUNT;

            if (!validation)
                throw new ArgumentException("Invalid Order Info Speicfied", nameof(onlineOrder));

            Console.WriteLine("Order Information Saved to DB Successfully, Details : {0}", onlineOrder);

            return SUCCESS;
        }
    }
}
