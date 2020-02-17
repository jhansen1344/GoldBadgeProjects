using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe_Class
{
    public class MenuRepository
    {
        private List<Menu> _menuItems = new List<Menu>();

        //Create
        public bool CreateMenuItem(string name, int number, List<string> ingredientList, decimal price)
        {
            Menu newItem = new Menu(name, number, ingredientList, price);
            _menuItems.Add(newItem);
            return true;
        }

        //Return
        public List<Menu> GetMenuItems()
        {
            return _menuItems;
        }

        //ReturnMealByNumber
        public Menu ReturnMeal(int number)
        {
            foreach (var item in _menuItems)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }

        //DeleteByMealNumber
        public bool DeleteByNumber(int number)
        {
            foreach (var item in _menuItems)
            {
                if (item.Number == number)
                {
                    _menuItems.Remove(item);
                    return true;
                }
            }
            return false;
        }


    }
}
