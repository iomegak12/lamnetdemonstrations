using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Credit { get; set; }
        public bool Status { get; set; }

        public override string ToString() =>
            $"{this.Id}, {this.Name}, {this.Address}, {this.Credit}, {this.Status}";
    }
}
