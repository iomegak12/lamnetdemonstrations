using Lam.Libraries.CreditCards.Interfaces;
using Lam.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lam.Libraries.CreditCards.Impl
{
    public class VisaCreditCardValidator : ICreditCardValidator
    {
        private const string CREDIT_CARD_PREFIX = "VISA";
        private const int NO_OF_CHARS = 19;

        public bool Validate(CreditCardInfo creditCardInfo)
        {
            var validation = creditCardInfo != default(CreditCardInfo) &&
                !string.IsNullOrEmpty(creditCardInfo.CreditCardNumber) &&
                creditCardInfo.CreditCardNumber.StartsWith(CREDIT_CARD_PREFIX) &&
                creditCardInfo.CreditCardNumber.Length == NO_OF_CHARS &&
                !string.IsNullOrEmpty(creditCardInfo.CustomerName) &&
                creditCardInfo.ExpiryDate >= DateTime.Now;

            return validation;
        }
    }
}
