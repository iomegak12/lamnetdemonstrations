using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Customers.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
