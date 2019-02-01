using Lam.Libraries.Customers.Impl;
using Lam.Libraries.Orders.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.CRM.CmdUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var customersFileName = @"C:\000 - .NET\Data\customers.csv";
            var ordersFileName = @"C:\000 - .NET\Data\orders.csv";

            using (var customerService = new CustomerService(customersFileName))
            using (var orderService = new OrderService(ordersFileName))
            {
                var customersList = customerService.GetCustomers();
                var ordersList = orderService.GetOrders();

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

                Console.ForegroundColor = ConsoleColor.Green;

                foreach (var customer in processedCustomersGroup)
                {
                    PrintCustomerRecord(customer);
                }

                Console.ResetColor();
            }

            Console.WriteLine("End of the Application!");
            Console.ReadLine();
        }

        static void PrintCustomerRecord(dynamic processedCustomer)
        {
            Console.WriteLine($"{processedCustomer.CustomerId}, {processedCustomer.Name}, {processedCustomer.City}, {processedCustomer.TotalUnits}, {processedCustomer.TotalOrderAmount}, {processedCustomer.TotalNoOfOrders}");
        }

        // Using Reflection API
        //static void PrintCustomerRecordOld(object processedCustomer)
        //{
        //    var customerType = processedCustomer.GetType();
        //    var idProperty = customerType.GetProperty("CustomerId");
        //    var nameProperty = customerType.GetProperty("Name");
        //    var cityProperty = customerType.GetProperty("City");
        //    var totalUnitsProperty = customerType.GetProperty("TotalUnits");
        //    var orderAmountProperty = customerType.GetProperty("OrderAmount");

        //    var customerId = int.Parse(idProperty.GetValue(processedCustomer).ToString());
        //    var name = nameProperty.GetValue(processedCustomer).ToString();
        //    var city = cityProperty.GetValue(processedCustomer).ToString();
        //    var totalUnits = int.Parse(totalUnitsProperty.GetValue(processedCustomer).ToString());
        //    var orderAmount = int.Parse(orderAmountProperty.GetValue(processedCustomer).ToString());

        //    Console.WriteLine($"{customerId}, {name}, {city}, {totalUnits}, {orderAmount}");
        //}
    }
}
