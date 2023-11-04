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

        public Drink ChooseDrink(string userDrinkChoice)
        {
            while (SerialNumberValidator(userDrinkChoice) == false)
            {
                userDrinkChoice = Console.ReadLine();
                ChooseDrink(userDrinkChoice);
            }

            return IdentifyDrink(userDrinkChoice);
        }

        public void CheckTotal(double total, Drink usersDrinkChoice)
        {
            if (total >= usersDrinkChoice.Price)
            {
                total -= usersDrinkChoice.Price;
                Console.WriteLine($"Enjoy your {usersDrinkChoice.DrinkName}!");
                Console.WriteLine("Change: " + total);
            }
            else
            {
                Console.WriteLine("You're missing " + (total - usersDrinkChoice.Price) + " NIS");
                var userCoins = Console.ReadLine();
                InsertCoins(userCoins, total);
            }
        }

        public bool SerialNumberValidator(string serialNumber)
        {
            foreach (var variable in _drinkList)
            {
                if (variable.SerialNumber == serialNumber)
                {
                    return true;
                }
            }

            Console.WriteLine("This drink serial number is not valid");
            return false;
        }

        public Drink IdentifyDrink(string serialNumber)
        {

            foreach (var VARIABLE in _drinkList)
            {
                if (serialNumber == VARIABLE.SerialNumber)
                {
                    return VARIABLE;
                }
            }

            return null;
        }
        
    }
}