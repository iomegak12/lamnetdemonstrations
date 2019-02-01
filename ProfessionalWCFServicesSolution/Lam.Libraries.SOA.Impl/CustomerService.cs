using Lam.Libraries.ORM.Impl;
using Lam.Libraries.ORM.Interfaces;
using Lam.Libraries.SOA.Contracts.Data;
using Lam.Libraries.SOA.Contracts.Faults;
using Lam.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Impl
{
    [ServiceBehavior(
        Namespace = @"http://schemas.lamresearch.com/behaviors/services")]
    public class CustomerService : ICustomerService, IDisposable
    {
        private const string CUSTOMERS_CONNECTION_STRING = "CustomersDB";

        private ICustomersContext customersContext = default(ICustomersContext);

        public CustomerService()
        {
            this.customersContext = new CustomersContext(
                connectionString: ConfigurationManager.ConnectionStrings[CUSTOMERS_CONNECTION_STRING].ConnectionString);
        }

        [OperationBehavior]
        public bool AddCustomerDetail(Customer customerDetail)
        {
            var status = default(bool);

            try
            {
                var addedRecord = this.customersContext.Customers.Add(customerDetail);
                var commitStatus = this.customersContext.CommitChanges();

                status = addedRecord.CustomerId != default(int) && commitStatus;
            }
            catch (Exception exceptionObject)
            {
                throw new FaultException<ServiceError>(
                    new ServiceError
                    {
                        ErrorId = 4,
                        Message = exceptionObject.Message,
                        StackTrace = exceptionObject.StackTrace
                    },
                    new FaultReason(exceptionObject.Message));
            }


            return status;
        }

        public void Dispose() => this.customersContext?.Dispose();

        [OperationBehavior]
        public IEnumerable<Customer> FindCustomers(string customerName)
        {
            var filteredCustomers = default(IEnumerable<Customer>);

            try
            {
                filteredCustomers = (
                    from customer in customersContext.Customers
                    where customer.CustomerName.Contains(customerName)
                    select customer).ToList();
            }
            catch (Exception exceptionObject)
            {
                throw new FaultException<ServiceError>(
                    new ServiceError
                    {
                        ErrorId = 3,
                        Message = exceptionObject.Message,
                        StackTrace = exceptionObject.StackTrace
                    },
                    new FaultReason(exceptionObject.Message));
            }

            return filteredCustomers;
        }

        [OperationBehavior]
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customersList = default(List<Customer>);

            try
            {
                customersList = this.customersContext.Customers.ToList();
            }
            catch (Exception exceptionObject)
            {
                throw new FaultException<ServiceError>(
                    new ServiceError
                    {
                        ErrorId = 1,
                        Message = exceptionObject.Message,
                        StackTrace = exceptionObject.StackTrace
                    },
                    new FaultReason(exceptionObject.Message));
            }

            return customersList;
        }

        [OperationBehavior]
        public Customer GetCustomerDetail(int customerId)
        {
            var filteredCustomer = default(Customer);

            try
            {
                filteredCustomer =
                       (from customer in customersContext.Customers
                        where customer.CustomerId == customerId
                        select customer).FirstOrDefault();
            }
            catch (Exception exceptionObject)
            {
                throw new FaultException<ServiceError>(
                    new ServiceError
                    {
                        ErrorId = 2,
                        Message = exceptionObject.Message,
                        StackTrace = exceptionObject.StackTrace
                    },
                    new FaultReason(exceptionObject.Message));
            }

            return filteredCustomer;
        }
    }
}
