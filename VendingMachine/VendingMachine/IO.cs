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
                Console.WriteLine(VARIABLE.SerialNumber + ". " + VARIABLE.DrinkName + " = " + VARIABLE.Price + "NIS" + "\n");
            }
        }
    }
}