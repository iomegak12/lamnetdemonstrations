using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.Models
{
    public class CreditCardInfo
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CustomerName { get; set; }
        public string CVVCode { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}",
                this.CreditCardNumber, this.ExpiryDate.ToString(), this.CustomerName, this.CVVCode);
        }
    }
}
