using System;
using System.Collections.Generic;

namespace kursova_lib
{
    public class Menu
    {
        public List<Dish> Salads = new List<Dish>();
        public List<Dish> MeatDishes = new List<Dish>();
        public List<Dish> Desserts = new List<Dish>();
        public List<Dish> DishesWithoutType = new List<Dish>();

        public void AddDishToMenu(Dish new_dish)
        {
            if (new_dish.TypeOfDish == "Salad")
            {
                Salads.Add(new_dish);
            }
            else if (new_dish.TypeOfDish == "Meat dish")
            {
                MeatDishes.Add(new_dish);
            }
            else if (new_dish.TypeOfDish == "Dessert")
            {
                Desserts.Add(new_dish);
            }
            else
            {
                DishesWithoutType.Add(new_dish);
            }
        }

        public string GetDishes(string type)
        {
            string txt = "";
            if (type == "Salad")
            {
                for (int i = 0; i < Salads.Count; i++)
                {
                    txt += $"[{i + 1}] {Salads[i].GetInfo()}";
                }
            }
            else if (type == "Meat dish")
            {
                for (int i = 0; i < MeatDishes.Count; i++)
                {
                    txt += $"[{i + 1}] {MeatDishes[i].GetInfo()}";
                }
            }
            else if (type == "Dessert")
            {
                for (int i = 0; i < Desserts.Count; i++)
                {
                    txt += $"[{i + 1}] {Desserts[i].GetInfo()}";
                }
            }
            else if (type == "Without type")
            {
                for (int i = 0; i < DishesWithoutType.Count; i++)
                {
                    txt += $"[{i + 1}] {DishesWithoutType[i].GetInfo()}";
                }
            }
            return txt;
        }
    }
}