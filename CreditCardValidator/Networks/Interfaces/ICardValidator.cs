using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Networks.Interfaces
{
    public interface ICardValidator
    {
        string Name { get; }
        bool IdentifiedValidator(long cardNumber);
        bool IsValid(long cardNumber);
    }
}
