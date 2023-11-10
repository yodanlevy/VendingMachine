using System;
using System.Linq;

namespace VendingMachine
{
    public class Validator
    {
        static double[] _coins = { 0.1, 0.5, 1, 2, 5, 10 };

        public static bool IsValid(String str)
        {
            if (double.TryParse(str, out var number))
            {
                return _coins.Contains(number);
            }

            return false;
        }

        public static bool IsPaymentMethodValid(string userPaymentMethod)
        {
            if (int.TryParse(userPaymentMethod, out int number))
            {
                return true;
            }

            return false;
        }

        public static bool IsCreditCardValid(string creditCardNumber, List<CreditCard> validCards)
        {
            foreach (var VARIABLE in validCards)
            {
                if (VARIABLE.Number == creditCardNumber)
                {
                    return true;    
                }
            }

            return false;
        }
    }
}