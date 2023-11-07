using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VendingMachine
{
    class Manager
    {
        public IO io = new IO();
        public double Total = 0.0;
        public void Start()
        {
            io.PrintDrinks();
           
            Console.WriteLine("Insert coins");
            var userCoins = Console.ReadLine();
            
            Total = io.InsertCoins(userCoins, Total);
            
            Drink userDrinkChoice = io.ChooseDrink();

            io.CheckTotal(Total, userDrinkChoice);











            /**while (!string.IsNullOrWhiteSpace(input))
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

            }*/

        }
    }
}
