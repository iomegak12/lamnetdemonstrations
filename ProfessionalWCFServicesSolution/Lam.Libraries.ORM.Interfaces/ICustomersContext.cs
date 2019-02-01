using Lam.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.ORM.Interfaces
{
    public interface ICustomersContext : ISystemContext
    {
        IDbSet<Customer> Customers { get; set; }
    }
}
