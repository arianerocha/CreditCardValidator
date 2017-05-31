using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Networks
{
    public class MasterCard : CardNetwork
    {
        const string mastercard = "MasterCard";
        public MasterCard() : base(mastercard) { }

        public override bool IdentifiedValidator(long cardNumber)
        {

            string digits = cardNumber.ToString();
            int length = digits.Length;
            int initialDigits = int.Parse(digits.Substring(0, 2));

            return length == 16 && (initialDigits >= 51 && initialDigits <= 55);
        }
    }
}
