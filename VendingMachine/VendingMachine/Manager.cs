using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VendingMachine
{
    class Manager
    {
        public IO io = new IO();

        public void Start()
        {
            io.PrintDrinks();
            string paymentMethod = io.ChoosePaymentMethod();

            if (paymentMethod == "1")
            {
                PayInCash();
            }
            else
            {
                PayWithCreditCard();
            }
        }

        private void PayInCash()
        {
            double total = 0;
            Console.WriteLine("\nInsert coins");
            string userCoins = Console.ReadLine();

            total = io.PayInCash(userCoins, total);

            Drink userDrinkChoice = io.ChooseDrink();
            while (!io.CheckTotal(total, userDrinkChoice))
            {
                userCoins = Console.ReadLine();
                total = io.PayInCash(userCoins, total);
            }
        }

        private void PayWithCreditCard()
        {
            Drink userDrinkChoice = io.ChooseDrink();
            io.PayWithCreditCard(userDrinkChoice);
        }
    }
}
