using System;
using System.Collections.Generic;

namespace kursova_lib
{
    interface IOrder
    {
        public decimal GetPriceOfDishes();

        public void AddDishToOrder(Dish new_dish, uint number = 1);

        public void RemoveDish(Dish removed_dish, uint number = 1);
        
        public string GetReceipt();
    }
    
    public class Order : IOrder
    {
         public uint TableNumber { get; set; }
         public string Address { get; set; }
         public string PhoneNumber { get; set; }
         public string ClientName { get; set; }
         protected decimal DeliveryPrice { get; set; } = 0;
         
         protected List<Dish> Dishes = new List<Dish>();
         protected List<uint> NumberOfDishes = new List<uint>();
         
         public decimal GetPriceOfDishes()
         {   decimal result = 0;
             for (int i = 0; i < Dishes.Count; i++)
             {
                 result += Dishes[i].GetPriceOfDish() * NumberOfDishes[i];
             }
             return result;
         }
         
         public void AddDishToOrder(Dish new_dish, uint number = 1)
         {
             if (Dishes.IndexOf(new_dish) >= 0)
             {
                 NumberOfDishes[Dishes.IndexOf(new_dish)] += number;
             }
             else
             {
                 Dishes.Add(new_dish);
                 NumberOfDishes.Add(number);
             }
         }
         public void RemoveDish(Dish removed_dish, uint number = 1)
         {
             int index = Dishes.IndexOf(removed_dish);
             NumberOfDishes[index] -= number;
             if (NumberOfDishes[index] <= 0)
             {
                 Dishes.RemoveAt(index);
                 NumberOfDishes.RemoveAt(index);
             }
         }
         
         public virtual string GetReceipt()
         {
             return "";
         }
    }

    public class DeliveryOrder: Order 
    {
        public override string GetReceipt()
        {
            string txt = "==================================\n";
            txt += $"Type: Delivery\n\nName of client: {ClientName}\n";
            txt += $"Phone number of client: {PhoneNumber}\n";
            txt += $"Address of client: {Address}\n\n";
            
            for (int i = 0; i < Dishes.Count; i++)
            {
                txt += $"{Dishes[i].Name} {Dishes[i].GetPriceOfDish():f2} hrn\t(x{NumberOfDishes[i]})\n";
            }
            
            txt += $"\nPrice for dishes: {GetPriceOfDishes():f2} hrn\n";
            txt += $"Price for delivery: {DeliveryPrice:f2} hrn\n";
            txt += $"\nTotal price: {DeliveryPrice + GetPriceOfDishes():f2} hrn";
            txt += "\n==================================\n";
             
            return txt;
        }
    }
    
    public class AtPlaceOrder: Order
    {
        public override string GetReceipt()
        {
            string txt = "==================================\n";
            txt += $"Type: At place\n\nNumber of table: {TableNumber}\n\n";
            
            for (int i = 0; i < Dishes.Count; i++)
            {
                txt += $"{Dishes[i].Name} {Dishes[i].GetPriceOfDish():f2} hrn\t(x{NumberOfDishes[i]})\n";
            }
            
            txt += $"\nTotal price: {GetPriceOfDishes():f} hrn";
            txt += "\n==================================\n";
             
            return txt;
        }
    }
}