using System;
using System.Collections.Generic;

namespace kursova_lib
{
    interface IDish
    {
        public void AddIngredient(Ingredient new_ingredient, decimal weight);

        public decimal GetPriceOfDish();
        //decomposit
        public string GetInfo();
    }
    
    public class Dish : IDish
    {
        public string Name { get; set; }
        public string TypeOfDish { get; set; }
        private decimal Benefit { get; set; }
        private List<Ingredient> Ingredients = new List<Ingredient>();
        private List<decimal> WeightsOfIngredients = new List<decimal>();

        public Dish(string name, string type_of_dish, decimal benefit)
        {
            Name = name;
            TypeOfDish = type_of_dish;
            Benefit = benefit;
        }
        public void AddIngredient(Ingredient new_ingredient, decimal weight)
        {
            Ingredients.Add(new_ingredient);
            WeightsOfIngredients.Add(weight);
        }
        public decimal GetPriceOfDish()
        {
            decimal result = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                result += Ingredients[i].PricePerKg * WeightsOfIngredients[i] * (decimal)0.001;
            }
            result += Benefit;
            return result;
        }
        
        public string GetInfo()
        {
            string txt = "";
            txt += $"{Name} {GetPriceOfDish():f2} hrn\nComposition: ";
            for (int i = 0; i < Ingredients.Count; i++)
            {
                txt += $"{Ingredients[i].Name} ({WeightsOfIngredients[i]:f1}g) ";
            }
            txt += "\n\n";

            return txt;
        }
    }
}
