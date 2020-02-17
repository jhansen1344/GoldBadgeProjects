using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe_Class
{
    public class Menu
    {
        public Menu() { }
        public Menu(string name, int number, List<string> ingredientList, decimal price)
        {
            Name = name;
            Number = number;
            IngredientList = ingredientList;
            Price = price;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public List<string> IngredientList { get; set; } = new List<string>();
        public decimal Price { get; set; }

        public string Description {
            get
            {
                string description = "";
                foreach (var item in IngredientList)
                {
                    description += item + ", ";
                }
                return description;
            }  
            }
    }
}
