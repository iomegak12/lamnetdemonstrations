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
    public class LoadOrdersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var commandInfo = parameter as CommandInfo;

            if (commandInfo != default(CommandInfo))
            {
                var input = commandInfo.Input as Customer;
                var result = commandInfo.Result as Orders;

                if (input != default(Customer) && result != default(Orders))
                {
                    var orderService = new OrderService();
                    var ordersList = orderService.GetOrders(input.Id) as List<Order>;

                    result.Clear();

                    ordersList.ForEach(
                        order => result.Add(order));
                }
            }
        }
    }
}
