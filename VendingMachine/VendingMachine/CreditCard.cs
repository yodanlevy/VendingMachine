using System.Runtime.InteropServices;

namespace VendingMachine
{
    public class CreditCard
    {
        public string Number { get; }

        public CreditCard(string number)
        {
            this.Number = number;
        }
    }
}