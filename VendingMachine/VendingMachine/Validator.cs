using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualBasic;

namespace VendingMachine
{
    public class Validator
    {
        public static bool IsCoinValid(String coinInput)
        {
            return (double.TryParse(coinInput, out double number) && Constants.Coins.Contains(number));
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