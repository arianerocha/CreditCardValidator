using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Services;
using CreditCardValidator.Exceptions;

namespace CreditCardValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ValidatorService();

            Console.WriteLine("Digite sair para finalizar o programa");
            Console.WriteLine("\n\nInforme o número do seu cartão de crédito: ");

            bool stopProgram = false;
            long number;

            while (!stopProgram)
            {

                string input = Console.ReadLine();
                if (input == "sair") // Check string
                {
                    stopProgram = true;
                    break;
                }

                long.TryParse(input, out number);

                try
                {

                    var validator = service.GetValidator(number);
                    if (validator.IsValid(number))
                    {
                        Console.WriteLine($"{validator.Name}: {number} (válido)");
                    }
                    else
                    {
                        Console.WriteLine($"{validator.Name}: {number} (inválido)");
                    }

                }
                catch (ValidatorDoesNotExistException)
                {
                    Console.WriteLine($"Desconhecido: {number} (inválido)");
                }
                catch (Exception)
                {
                    Console.WriteLine("Digite apenas números");
                }
            }
        }
    }
}
