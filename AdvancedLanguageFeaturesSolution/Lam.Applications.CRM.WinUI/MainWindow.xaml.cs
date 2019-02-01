using Lam.Libraries.Customers.Impl;
using Lam.Libraries.Orders.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lam.Applications.CRM.WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var customersFileName = @"C:\000 - .NET\Data\customers.csv";
            var ordersFileName = @"C:\000 - .NET\Data\orders.csv";

            using (var customerService = new CustomerService(customersFileName))
            using (var orderService = new OrderService(ordersFileName))
            {
                var customersList = await customerService.GetCustomersAsync();
                var ordersList = await orderService.GetOrdersAsync();

                var processedCustomersGroup =
                    from customer in customersList
                    where customer.Status
                    orderby customer.Name ascending
                    join order in ordersList on customer.Id equals order.CustomerId
                    group new
                    {
                        CustomerId = customer.Id,
                        customer.Name,
                        City = customer.Address,
                        order.Units,
                        OrderAmount = order.TotalAmount
                    } by customer.Id into groupedCustomers
                    select new
                    {
                        CustomerId = groupedCustomers.Key,
                        Name = groupedCustomers.FirstOrDefault()?.Name,
                        City = groupedCustomers.FirstOrDefault()?.City,
                        TotalUnits = groupedCustomers.Sum(record => record.Units),
                        TotalOrderAmount = groupedCustomers.Sum(record => record.OrderAmount),
                        TotalNoOfOrders = groupedCustomers.Count()
                    };

                this.dgProcessedRecords.ItemsSource = processedCustomersGroup;
            }
        }
    }
}
