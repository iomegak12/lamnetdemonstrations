using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Models.Services
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            var names = new string[] { "Rajesh", "Ramesh", "Mahesh", "Mukhesh", "Suresh", "Rajish" };
            var customers = new List<Customer>(
                from index in Enumerable.Range(1, names.Length)
                select new Customer
                {
                    Id = index,
                    Name = names[index - 1]
                });

            return customers;
        }
    }
}
