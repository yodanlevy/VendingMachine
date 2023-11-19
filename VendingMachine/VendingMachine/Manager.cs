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
            
            int paymentMethod = io.ChoosePaymentMethod();

            if (paymentMethod == 1)
            {
                Console.WriteLine("\nInsert coins");
                string userCoins = Console.ReadLine();

                Total = io.InsertCoins(userCoins, Total);

                Drink userDrinkChoice = io.ChooseDrink();

                io.CheckTotal(Total, userDrinkChoice);
            }
            else
            {
                Drink userDrinkChoice = io.ChooseDrink();
                io.PayWithCreditCard(userDrinkChoice);
            }
        }
    }
}
