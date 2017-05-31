using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Networks
{
   public class Discover : CardNetwork
    {
        const string discover = "Discover";

        public Discover() : base(discover) { }

        public override bool IdentifiedValidator(long cardNumber)
        {

            string digits = cardNumber.ToString();
            int length = digits.Length;
            int initialDigits = int.Parse(digits.Substring(0, 4));

            return length == 16 && initialDigits == 6011;
        }
    }
}
