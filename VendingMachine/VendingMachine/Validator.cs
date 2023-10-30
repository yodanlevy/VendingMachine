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


    }
}