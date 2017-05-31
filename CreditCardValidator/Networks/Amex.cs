using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Networks
{
    public class Amex : CardNetwork
    {
        const string amex = "AMEX";

        public Amex() : base(amex) { }

        public override bool IdentifiedValidator(long cardNumber)
        {

            string digits = cardNumber.ToString();
            int length = digits.Length;
            int initialDigits = int.Parse(digits.Substring(0, 2));

            return length == 15 && (initialDigits >= 34 || initialDigits <= 37);
        }
    }
}
