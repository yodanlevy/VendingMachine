namespace VendingMachine
{
    public class Drink
    {
        public string DrinkName;
        public string SerialNumber;
        public double Price;

        public Drink(string drinkName, string sreialNumber, double price)
        {
            this.DrinkName = drinkName;
            this.SerialNumber = sreialNumber;
            this.Price = price;
        }


    }
}