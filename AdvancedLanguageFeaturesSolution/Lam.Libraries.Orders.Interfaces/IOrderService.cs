using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Orders.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
