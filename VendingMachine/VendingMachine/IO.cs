using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class IO
    {
        public static DataInitializer dI = new DataInitializer();
        public List<Drink> _drinkList = dI.InitializeDrink();
        public List<CreditCard> ValidCards = dI.InitializeCreditCard();

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
            while (!string.IsNullOrWhiteSpace(coins))
            {
                if (Validator.IsValid(coins))
                {
                    total += double.Parse(coins);
                    coins = Console.ReadLine();
                }

                else
                {
                    Console.WriteLine("Invalid coin");
                    coins = Console.ReadLine();
                }
            }

            Console.WriteLine("Total: " + total);
            return total;
        }

        public Drink ChooseDrink()
        {
            Console.WriteLine("Choose a drink");
            string userDrinkChoice = Console.ReadLine();
            
            while (SerialNumberValidator(userDrinkChoice) == false)
            {
                Console.WriteLine("This drink serial number is not valid");
                userDrinkChoice = Console.ReadLine();
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
                Console.WriteLine("You're missing " + (usersDrinkChoice.Price - total) + " NIS");
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