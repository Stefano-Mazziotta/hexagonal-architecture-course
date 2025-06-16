using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Bussiness
{
    public abstract class Drink
    {
        public int Quantity { get; set; }

        public Drink(int quantity)
        {
            Quantity = quantity;
        }

        public string GetQuantity()
        {
            return $"Quantity: {Quantity} ml";
        }

        public abstract string GetCategory();
    }
}
