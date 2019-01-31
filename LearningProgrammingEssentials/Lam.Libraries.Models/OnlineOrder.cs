using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Models
{
    public class OnlineOrder
    {
        public int OrderRefNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string BillingAddress { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"{this.OrderRefNumber}, {this.OrderDate.ToString()}, {this.CustomerId}, {this.BillingAddress}, " +
                $"{this.ProductId}, {this.Units}, {this.Amount}, {this.Remarks}";
        }
    }
}
