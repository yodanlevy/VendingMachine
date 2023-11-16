using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    public class DataInitializer
    {
        public Dictionary<string, Drink> InitializeDrink()
        {
            Drink CocaCola= new Drink("Coca-Cola", 5);
            Drink CocaColaZero = new Drink("Coca-Cola Zero", 5);
            Drink Sprite = new Drink("Sprite", 5);
            Drink SpriteZero = new Drink("Sprite Zero",5);
            Drink OrangeJuice = new Drink("Orange Juice",6);
            Drink GrapeJuice = new Drink("Grape Juice",6);
            Drink Water = new Drink("Water", 4);

            Dictionary<string, Drink> drinkMenu = new Dictionary<string, Drink>();
            drinkMenu.Add("A1", cocaCola);
            drinkMenu.Add("A2", cocaColaZero);
            drinkMenu.Add("A3", sprite);
            drinkMenu.Add("B1", spriteZero);
            drinkMenu.Add("B2", orangeJuice);
            drinkMenu.Add("B3", grapeJuice);
            drinkMenu.Add("C1", water);

            return drinkMenu;
        }

        public List<CreditCard> InitializeCreditCard()
        {
            CreditCard creditCard1 = new CreditCard("1234");
            CreditCard creditCard2 = new CreditCard("12345");
            CreditCard creditCard3 = new CreditCard("123456");

            List<CreditCard> validCreditCards = new List<CreditCard>();
            validCreditCards.Add(creditCard1);
            validCreditCards.Add(creditCard2);
            validCreditCards.Add(creditCard3);

            return validCreditCards;
        }
    }
}