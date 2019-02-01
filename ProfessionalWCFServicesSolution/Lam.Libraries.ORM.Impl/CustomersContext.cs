using Lam.Libraries.ORM.Interfaces;
using Lam.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.ORM.Impl
{
    public class CustomersContext : DbContext, ICustomersContext
    {
        private const int MIN_ROWS = 1;

        public CustomersContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add<Customer>(new CustomerEntityTypeConfiguration());
        }

        public IDbSet<Customer> Customers { get; set; }

        public bool CommitChanges()
        {
            var noOfRowsAffected = this.SaveChanges();

            return noOfRowsAffected >= MIN_ROWS;
        }
    }
}
