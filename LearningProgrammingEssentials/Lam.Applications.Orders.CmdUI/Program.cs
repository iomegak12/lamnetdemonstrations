using Lam.Libraries.DI.Impl;
using Lam.Libraries.Models;
using Lam.Libraries.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Applications.Orders.CmdUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var onlineOrder = new OnlineOrder
                {
                    OrderRefNumber = 11,
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    BillingAddress = "Bangalore",
                    Units = 20,
                    Amount = 2000,
                    Remarks = "Simple Order Record",
                    ProductId = 11
                };

                var creditCardInfo = new CreditCardInfo
                {
                    CreditCardNumber = "VISA-1111-1212-1212",
                    ExpiryDate = DateTime.Now.AddYears(1),
                    CustomerName = "Rajkumar",
                    CVVCode = "231"
                };

                var orderProcessor = LamObjectBuilder.Instance.GetObject<IOnlineOrderProcessor>();

                orderProcessor.OrderCompleted += delegate (OnlineOrder orderInfo, string status)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Order {orderInfo.OrderRefNumber} Completed Successfully ... Status : {status}");
                    Console.ResetColor();
                };

                orderProcessor.ProcessOrder(onlineOrder, creditCardInfo);

                Console.WriteLine("End of App!");
                Console.ReadLine();
            }
            catch (Exception exceptionObject)
            {
                Console.WriteLine($"Error Occurred, Details : {exceptionObject.Message}");
            }
        }
    }
}
