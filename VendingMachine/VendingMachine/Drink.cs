namespace VendingMachine
{
    public class Drink
    {
        public string DrinkName;
        public string SerialNumber;
        public double Price;

        public Drink(string drinkName, string serialNumber, double price)
        {
            this.DrinkName = drinkName;
            this.SerialNumber = serialNumber;
            this.Price = price;
        }


    }
}