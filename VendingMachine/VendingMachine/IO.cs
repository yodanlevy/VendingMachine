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
            Console.WriteLine("Please enter your credit card number:");
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
                    Console.WriteLine($"Enjoy your drink! {userDrinkChoice.DrinkName}");
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
            foreach (var variable in Drinks)
            {
                if (variable.Key == serialNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public Drink IdentifyDrink(string serialNumber)
        {

            foreach (var VARIABLE in DrinkList)
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