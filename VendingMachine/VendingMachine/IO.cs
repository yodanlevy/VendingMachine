using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class IO
    {
        public static DataInitializer dI = new DataInitializer();
        public Dictionary<string, Drink> Drinks = dI.InitializeDrink();
        public List<CreditCard> ValidCards = dI.InitializeCreditCard();

        public void PrintDrinks()
        {
            Console.WriteLine("Please choose a drink:");
            foreach (var variable in Drinks)
            {
                Console.WriteLine(variable.Key + ". " + variable.Value.DrinkName + " = " + variable.Value.Price + " NIS" + "\n");
            }
        }

        public int ChoosePaymentMethod()
        {
            Console.WriteLine("For payment in cash please press 1 \n" +
                              "For payment with credit card please press 2");

            int paymentMethod = 0;
            string userPaymentMethod = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(userPaymentMethod))
            {
                if (Validator.IsPaymentMethodValid(userPaymentMethod))
                {
                    paymentMethod = int.Parse(userPaymentMethod);
                    return paymentMethod;
                }

                Console.WriteLine("Payment method is not valid \n" +
                                  "Please try again");
                userPaymentMethod = Console.ReadLine();

            }

            return paymentMethod;
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
                    Console.WriteLine("\nInvalid coin");
                    coins = Console.ReadLine();
                }
            }

            Console.WriteLine("\nTotal: " + total);
            return total;
        }

        public Drink ChooseDrink()
        {
            Console.WriteLine("\nChoose a drink");
            string userDrinkChoice = Console.ReadLine();
            
            while (ValidateSerialNumber(userDrinkChoice) == false)
            {
                Console.WriteLine("\nThis drink serial number is not valid");
                userDrinkChoice = Console.ReadLine();
            }

            return IdentifyDrink(userDrinkChoice);
        }

        public bool CheckTotal(double total, Drink usersDrinkChoice)
        {
            if (total >= usersDrinkChoice.Price)
            {
                total -= usersDrinkChoice.Price;
                Console.WriteLine($"\nEnjoy your {usersDrinkChoice.DrinkName}!");
                Console.WriteLine("Change: " + total);
            }
            else
            {
                Console.WriteLine("\nYou're missing " + (usersDrinkChoice.Price - total) + " NIS");
                var userCoins = Console.ReadLine();
                InsertCoins(userCoins, total);
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