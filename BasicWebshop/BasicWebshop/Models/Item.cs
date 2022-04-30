using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebshop.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Desctription { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, string desctription, int price, int quantity)
        {
            Name = name;
            Desctription = desctription;
            Price = price;
            Quantity = quantity;
        }
    }
}
