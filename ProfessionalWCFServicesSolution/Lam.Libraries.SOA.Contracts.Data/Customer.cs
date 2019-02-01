using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Contracts.Data
{
    [DataContract(
        Namespace = @"http://schemas.lamresearch.com/contracts/data")]
    public class Customer
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int CreditLimit { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool ActiveStatus { get; set; }
        [DataMember]
        public string Remarks { get; set; }

        public override string ToString() =>
            $"{this.CustomerId}, {this.CustomerName}, {this.Address}, {this.CreditLimit}, {this.Email}, {this.PhoneNumber}, {this.ActiveStatus}, {this.Remarks}";
    }
}
