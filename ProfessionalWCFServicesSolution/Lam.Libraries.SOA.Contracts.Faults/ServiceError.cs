using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.SOA.Contracts.Faults
{
    [DataContract(
        Namespace = @"http://schemas.lamresearch.com/contracts/faults")]
    public class ServiceError
    {
        [DataMember]
        public int ErrorId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string StackTrace { get; set; }

        public override string ToString() => $"{this.ErrorId}, {this.Message}, {this.StackTrace}";
    }
}
