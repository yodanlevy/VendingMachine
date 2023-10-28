using System;
using System.Linq;

namespace VendingMachine
{
    public class Validator
    {
        static double[] _coins = { 0.1, 0.5, 1, 2, 5, 10 };

        public static bool isValid(String str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (_coins.Contains(double.Parse(str)))
                {
                    return true;
                }
            }

            return false;
        }


    }
}