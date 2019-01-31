using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.CreditCards.Interfaces
{
    public interface ICreditCardValidator
    {
        bool Validate(CreditCardInfo creditCardInfo);
    }
}
