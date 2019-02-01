using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public int Units { get; set; }
        public int TotalAmount { get; set; }
        public string Remarks { get; set; }

        public override string ToString() =>
            $"{this.OrderId}, {this.OrderDate}, {this.CustomerId}, {this.BillingAddress}" +
            $"{this.ShippingAddress}, {this.Units}, {this.TotalAmount}, {this.Remarks}";
    }
}
