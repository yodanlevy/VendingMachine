using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert coins");
            var total = 0.0;
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                if (Validator.IsValid(input))
                {
                    total += double.Parse(input);
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Coin is not valid");
                    input = Console.ReadLine();
                }
                
            }

            Console.WriteLine("Total: " + total);
        }
    }
}
