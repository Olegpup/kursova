using System;

namespace kursova_lib
{
    public class Ingredient
    {
        public string Name { get; set; }
        public decimal PricePerKg { get; set; }
        public Ingredient(string name, decimal price_per_kg)
        {
            Name = name;
            PricePerKg = price_per_kg;
        }
    }
}
