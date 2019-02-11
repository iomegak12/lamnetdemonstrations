using Lam.Libraries.ORM.Interfaces;
using Lam.Libraries.SOA.Contracts.Data;
using Lam.Libraries.SOA.Contracts.Faults;
using Lam.Libraries.SOA.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Lam.Libraries.SOA.Impl
{
    [ServiceBehavior(
        Namespace = @"http://schemas.lamresearch.com/behaviors/services")]
    public class CustomerService : ICustomerService, IDisposable
    {
        private ICustomersContext customersContext = default(ICustomersContext);

        public CustomerService(ICustomersContext customersContext)
        {
            if (customersContext == default(ICustomersContext))
                throw new ArgumentNullException(nameof(customersContext));

            this.customersContext = customersContext;
        }

        [OperationBehavior]
        public virtual bool AddCustomerDetail(Customer customerDetail)
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
