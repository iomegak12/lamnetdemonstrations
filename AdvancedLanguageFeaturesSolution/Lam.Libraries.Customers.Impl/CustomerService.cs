using Lam.Libraries.Customers.Interfaces;
using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Customers.Impl
{
    public class CustomerService : ICustomerService, IDisposable
    {
        private const char COLUMN_DELIMITER = ',';
        private FileStream fileStream = default(FileStream);
        private StreamReader streamReader = default(StreamReader);

        public CustomerService(string fileName)
        {
            var validation = !string.IsNullOrEmpty(fileName) &&
                File.Exists(fileName);

            if (!validation)
                throw new ArgumentException("Invalid File Name Specified!", nameof(fileName));

            this.fileStream = File.OpenRead(fileName);
            this.streamReader = new StreamReader(this.fileStream);
        }

        public void Dispose()
        {
            if (this.streamReader != default(StreamReader))
                this.streamReader.Close();

            if (this.fileStream != default(FileStream))
                this.fileStream.Close();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            // SKIP THE HEADER
            this.streamReader.ReadLine();

            var customersList = new List<Customer>();

            while (true)
            {
                var currentLine = this.streamReader.ReadLine();

                if (string.IsNullOrEmpty(currentLine))
                    break;

                var splittedLine = currentLine.Split(COLUMN_DELIMITER);
                var customer = new Customer
                {
                    Id = int.Parse(splittedLine[0]),
                    Name = splittedLine[1],
                    Address = splittedLine[2],
                    Credit = int.Parse(splittedLine[3]),
                    Status = bool.Parse(splittedLine[4])
                };

                customersList.Add(customer);
            }

            return customersList;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            await this.streamReader.ReadLineAsync();

            var customersList = new List<Customer>();

            while (true)
            {
                var currentLine = await this.streamReader.ReadLineAsync();

                if (string.IsNullOrEmpty(currentLine))
                    break;

                var splittedLine = currentLine.Split(COLUMN_DELIMITER);
                var customer = new Customer
                {
                    Id = int.Parse(splittedLine[0]),
                    Name = splittedLine[1],
                    Address = splittedLine[2],
                    Credit = int.Parse(splittedLine[3]),
                    Status = bool.Parse(splittedLine[4])
                };

                customersList.Add(customer);
            }

            await Task.Delay(2000);

            return customersList;
        }
    }
}
