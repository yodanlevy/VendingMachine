using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    class DataInitializer
    {
        public List<object> InitializeDrink()
        {
            Drink CocaCola= new Drink("Coca-Cola", "A1", 5);
            Drink CocaColaZero = new Drink("Coca-Cola Zero", "A2", 5);
            Drink Sprite = new Drink("Sprite", "A3", 5);
            Drink SpriteZero = new Drink("Sprite Zero", "A4", 5);
            Drink OrangeJuice = new Drink("Orange Juice", "B1", 6);
            Drink GrapeJuice = new Drink("Grape Juice", "B2", 6);
            Drink Water = new Drink("Water", "B3", 4);

            List<object> drinkMenu = new List<object>();
            drinkMenu.Add(CocaCola);
            drinkMenu.Add(CocaColaZero);
            drinkMenu.Add(Sprite);
            drinkMenu.Add(SpriteZero);
            drinkMenu.Add(OrangeJuice);
            drinkMenu.Add(GrapeJuice);
            drinkMenu.Add(Water);

            return drinkMenu;
        }
    }
}