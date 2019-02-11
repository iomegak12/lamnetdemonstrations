using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Models.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(int customerId);
    }
}
