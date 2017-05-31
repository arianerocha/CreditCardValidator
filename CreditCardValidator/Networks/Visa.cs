using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Networks
{
    public class Visa : CardNetwork
    {
        const string visa = "VISA";

        public Visa() : base(visa) { }

        public override bool IdentifiedValidator(long cardNumber)
        {

            string digits = cardNumber.ToString();
            int length = digits.Length;
            int initialDigit = int.Parse(digits.Substring(0, 1));

            return (length == 13 || length == 16) && initialDigit == 4;
        }
    }
}
