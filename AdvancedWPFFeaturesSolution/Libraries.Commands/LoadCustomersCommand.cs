using Libraries.Models;
using Libraries.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Libraries.Commands
{
    public class LoadCustomersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var customerService = new CustomerService();
            var customers = parameter as Customers;

            if (customers != default(Customers))
            {
                var customersList = customerService.GetCustomers() as List<Customer>;

                customers.Clear();

                customersList.ForEach(
                    customer => customers.Add(customer));
            }
        }
    }
}
