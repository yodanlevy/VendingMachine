using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class IO
    {
        public static DataInitializer DataInitializer = new DataInitializer();
        public Dictionary<string, Drink> Drinks = DataInitializer.InitializeDrinks();
        public List<CreditCard> ValidCards = DataInitializer.InitializeCreditCards();
        
        public void PrintDrinks()
        {
            Console.WriteLine("Please choose a drink:");
            foreach (var drink in Drinks)
            {
                Console.WriteLine($"{drink.Key}. {drink.Value.DrinkName} = {drink.Value.Price} NIS \n");
            }
        }

        public string ChoosePaymentMethod()
        {
            Console.WriteLine("For payment in cash please press 1 \n" +
                              "For payment with credit card please press 2");
            string userPaymentMethod = Console.ReadLine();

            while (!Validator.IsPaymentMethodValid(userPaymentMethod))
            {    
                Console.WriteLine("Payment method is not valid \n" +
                                    "Please try again");
                userPaymentMethod = Console.ReadLine();
            }

            return userPaymentMethod;
        }

        public void PayWithCreditCard(Drink userDrinkChoice)
        {
            Console.WriteLine("\nPlease enter your credit card number:");
            string userCreditCard = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(userCreditCard))
            {
                if (!Validator.IsCreditCardValid(userCreditCard, ValidCards))
                {
                    Console.WriteLine("\nYour credit card number is not valid.\n" +
                                      "Please try again!");
                    userCreditCard = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"\nEnjoy your drink! {userDrinkChoice.DrinkName}");
                    break;
                }
            }
        }

        public double GetCoins(string coins)
        {
            double totalCoins = 0;
            while (!string.IsNullOrWhiteSpace(coins))
            {
                if (Validator.IsCoinValid(coins))
                {
                    totalCoins += double.Parse(coins);
                    coins = Console.ReadLine();
                }

                else
                {
                    Console.WriteLine("\nInvalid coin");
                    coins = Console.ReadLine();
                }
            }

            Console.WriteLine("\nTotal: " + totalCoins);
            return totalCoins;
        }

        public Drink ChooseDrink()
        {
            Console.WriteLine("\nChoose a drink");
            string userSerialNumberChoice = Console.ReadLine();
            
            while (ValidateSerialNumber(userSerialNumberChoice) == false)
            {
                Console.WriteLine("\nThis drink serial number is not valid");
                userSerialNumberChoice = Console.ReadLine();
            }

            return IdentifyDrink(userSerialNumberChoice);
        }

        public bool CheckIfCanBuy(double payment, Drink drink)
        {
            if (payment >= drink.Price)
            {
                payment -= drink.Price;
                Console.WriteLine($"\nEnjoy your {drink.DrinkName}!");
                Console.WriteLine("Change: " + payment);
                return true;
            }
            else
            {
                Console.WriteLine("\nYou're missing " + (drink.Price - payment) + " NIS");
                return false;
            }
        }

        public bool ValidateSerialNumber(string serialNumber)
        {
            return Drinks.ContainsKey(serialNumber);
        }

        public Drink IdentifyDrink(string serialNumber)
        {
            foreach (var variable in Drinks)
            {
                if (serialNumber == variable.Key)
                {
                    return variable.Value;
                }
            }

            return null;
        }
    }
}