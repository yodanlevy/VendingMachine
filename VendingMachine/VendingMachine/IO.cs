using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class IO
    {
        public static DataInitializer dI = new DataInitializer();
        public List<Drink> _drinkList = dI.InitializeDrink();

        public void PrintDrinks()
        {
            Console.WriteLine("Please choose a drink:");
            foreach (var VARIABLE in _drinkList)
            {
                Console.WriteLine(VARIABLE.SerialNumber + ". " + VARIABLE.DrinkName + " = " + VARIABLE.Price + " NIS" + "\n");
            }
        }

        public double InsertCoins(string coins, double total)
        {
            if (Validator.IsValid(coins) == false)
            {
                Console.WriteLine("Invalid coin");
                var userCoins = Console.ReadLine();
                InsertCoins(userCoins, total);
            }

            total += double.Parse(coins);
            return total;
        }
        public bool SerialNumberValidator(string serialNumber)
        {
            foreach (var VARIABLE in _drinkList)
            {
                if (VARIABLE.SerialNumber == serialNumber)
                {
                    return true;
                }
            }
            
            return false;
        }
        
    }
}