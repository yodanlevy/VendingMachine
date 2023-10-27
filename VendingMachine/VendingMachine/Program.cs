using System;

namespace VendingMachine
{
    class Program
    {
        public class Validator
        {
            public static bool isValid(String str)
            {
                if (double.Parse(str) == 0.1 ||
                    double.Parse(str) == 0.5 ||
                    int.Parse(str) == 1 ||
                    int.Parse(str) == 2 ||
                    int.Parse(str) == 5 ||
                    int.Parse(str) == 10)
                {
                    return true;
                }

                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Insert coins");
            var total = 0.0;
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                if (Validator.isValid(input))
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
