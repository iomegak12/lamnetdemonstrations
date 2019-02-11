using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Libraries.Models.Services
{
    public class OrderService : IOrderService
    {
        public IEnumerable<Order> GetOrders(int customerId)
        {
            Thread.Sleep(1500);

            var random = new Random();
            var orders = new List<Order>(
                from index in Enumerable.Range(1, random.Next(1, 15))
                select new Order
                {
                    OrderId = random.Next(1, 100000),
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    CustomerId = customerId,
                    Amount = random.Next(10000, 50000)
                });

            return orders;
        }
    }
}
