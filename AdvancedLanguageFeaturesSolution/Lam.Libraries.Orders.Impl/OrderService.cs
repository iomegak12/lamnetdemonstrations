using Lam.Libraries.Models;
using Lam.Libraries.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Orders.Impl
{
    public class OrderService : IOrderService, IDisposable
    {
        private const char NEW_LINE = '\n';
        private const char COLUMN_DELIMITER = ',';
        private string fileName = default(string);

        public OrderService(string fileName)
        {
            var validation = !string.IsNullOrEmpty(fileName) &&
                 File.Exists(fileName);

            if (!validation)
                throw new ArgumentNullException("Invalid File Name Specified!", nameof(fileName));

            this.fileName = fileName;
        }

        public void Dispose() => this.fileName = default(string);

        public IEnumerable<Order> GetOrders()
        {
            var ordersList = default(IEnumerable<Order>);

            using (var fileStream = File.OpenRead(this.fileName))
            using (var streamReader = new StreamReader(fileStream))
            {
                // SKIP THE HEADER
                streamReader.ReadLine();

                var splittedOrders = streamReader.ReadToEnd().Split(NEW_LINE);

                ordersList = new List<Order>(
                    from orderLine in splittedOrders
                    let splittedOrderLine = orderLine.Split(COLUMN_DELIMITER)
                    select new Order
                    {
                        OrderId = int.Parse(splittedOrderLine[0]),
                        OrderDate = splittedOrderLine[1],
                        CustomerId = int.Parse(splittedOrderLine[2]),
                        BillingAddress = splittedOrderLine[3],
                        ShippingAddress = splittedOrderLine[4],
                        Units = int.Parse(splittedOrderLine[5]),
                        TotalAmount = int.Parse(splittedOrderLine[6]),
                        Remarks = splittedOrderLine[7]
                    });
            }

            return ordersList;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var ordersList = default(IEnumerable<Order>);

            using (var fileStream = File.OpenRead(this.fileName))
            using (var streamReader = new StreamReader(fileStream))
            {
                // SKIP THE HEADER
                await streamReader.ReadLineAsync();

                var splittedOrders = streamReader.ReadToEnd().Split(NEW_LINE);

                ordersList = new List<Order>(
                    from orderLine in splittedOrders
                    let splittedOrderLine = orderLine.Split(COLUMN_DELIMITER)
                    select new Order
                    {
                        OrderId = int.Parse(splittedOrderLine[0]),
                        OrderDate = splittedOrderLine[1],
                        CustomerId = int.Parse(splittedOrderLine[2]),
                        BillingAddress = splittedOrderLine[3],
                        ShippingAddress = splittedOrderLine[4],
                        Units = int.Parse(splittedOrderLine[5]),
                        TotalAmount = int.Parse(splittedOrderLine[6]),
                        Remarks = splittedOrderLine[7]
                    });
            }

            return ordersList;
        }
    }
}
