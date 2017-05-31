using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Networks.Interfaces;
using CreditCardValidator.Networks;
using CreditCardValidator.Exceptions;

namespace CreditCardValidator.Services
{
    public class ValidatorService
    {
        private readonly List<ICardValidator> _networds;

        public ValidatorService()
        {
            _networds = new List<ICardValidator>
            {
                new Amex(),
                new Discover(),
                new MasterCard(),
                new Visa()
            };
        }

        public ICardValidator GetValidator(long cardNumber)
        {
            foreach (var validator in _networds)
            {
                if (validator.IdentifiedValidator(cardNumber))
                {
                    return validator;
                }
            }

            throw new ValidatorDoesNotExistException();
        }
    }
}
