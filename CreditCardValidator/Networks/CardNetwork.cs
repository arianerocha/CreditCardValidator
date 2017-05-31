using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Networks.Interfaces;

namespace CreditCardValidator.Networks
{
    public abstract class CardNetwork : ICardValidator
    {
        private readonly string _name;
        public virtual bool IdentifiedValidator(long cardNumber)
        {
            throw new NotImplementedException("Implement an identifier");
        }

        protected CardNetwork(string cardNetworkName)
        {
            _name = cardNetworkName;
        }

        string ICardValidator.Name
        {
            get { return _name; }
        }

        private static bool toDouble(int number)
        {
            return number % 2 == 0;
        }

        private static IEnumerable<int> DoubleValue(IReadOnlyList<int> numbers)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];

                if (toDouble(i + 1))
                {
                    number = number * 2;
                    number = number > 9 ? number - 9 : number;
                }
                yield return number;
            }
        }

        public bool IsValid(long cardNumber)
        {
            var reversedNumbers = cardNumber.ToString().Reverse().Select(num => int.Parse(num.ToString())).ToArray();
            var values = DoubleValue(reversedNumbers);

            var total = values.Aggregate((va1, va2) => va1 + va2);

            return total % 10 == 0;
        }

    }
}
