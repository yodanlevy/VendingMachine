using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;

namespace VendingMachine
{
    public class Validator
    {
        static double[] _coins = { 0.1, 0.5, 1, 2, 5, 10 };

        public static bool IsCoinValid(String str)
        {
            return (double.TryParse(str, out var number));
        }

        public static bool IsPaymentMethodValid(string userPaymentMethod)
        {
            return (userPaymentMethod == "1" || userPaymentMethod == "2");
        }

        public static bool IsCreditCardValid(string creditCardNumber, List<CreditCard> validCards)
        {
            return validCards.Any(card => card.Number == creditCardNumber);
        }
    }
}