using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    public class DataInitializer
    {
        public List<Drink> InitializeDrink()
        {
            Drink CocaCola= new Drink("Coca-Cola", 5);
            Drink CocaColaZero = new Drink("Coca-Cola Zero", 5);
            Drink Sprite = new Drink("Sprite", 5);
            Drink SpriteZero = new Drink("Sprite Zero",5);
            Drink OrangeJuice = new Drink("Orange Juice",6);
            Drink GrapeJuice = new Drink("Grape Juice",6);
            Drink Water = new Drink("Water", 4);

            List<Drink> drinkMenu = new List<Drink>();
            drinkMenu.Add(CocaCola);
            drinkMenu.Add(CocaColaZero);
            drinkMenu.Add(Sprite);
            drinkMenu.Add(SpriteZero);
            drinkMenu.Add(OrangeJuice);
            drinkMenu.Add(GrapeJuice);
            drinkMenu.Add(Water);

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