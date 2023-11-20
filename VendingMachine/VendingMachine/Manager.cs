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
            
            string paymentMethod = io.ChoosePaymentMethod();

            if (paymentMethod == "1")
            {
                Console.WriteLine("\nInsert coins");
                string userCoins = Console.ReadLine();

                Total = io.PayInCash(userCoins, Total);

                Drink userDrinkChoice = io.ChooseDrink();

                while (!io.CheckTotal(Total, userDrinkChoice))
                {
                    userCoins = Console.ReadLine();
                    Total = io.PayInCash(userCoins, Total);
                }
            }
            else
            {
                Drink userDrinkChoice = io.ChooseDrink();
                io.PayWithCreditCard(userDrinkChoice);
            }
        }
    }
}
