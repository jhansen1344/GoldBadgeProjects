using _01_KCafe_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafeConsole
{

    class ProgramUI
    {
        private readonly MenuRepository _menu = new MenuRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number:\n" +
                    "1. Show Menu Combos\n" +
                    "2. Add Combos to Menu \n" +
                    "3. Delete Combo From Menu \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput.Trim())
                {
                    case "1":
                        ShowAllMenu();
                        break;
                    case "2":
                        AddComboToMenu();
                        break;
                    case "3":
                        RemoveComboFromMenu();
                        break;
                    case "4":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void ShowAllMenu()
        {
            Console.Clear();

            List<Menu> menuItems = _menu.GetMenuItems();

            if (menuItems.Count != 0)
            {
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"\nCombo Number: #{item.Number}\n" +
                        $"Combo Name: {item.Name}\n" +
                        $"Combo Price: {item.Price}\n" +
                        $"Combo Description: {item.Description}\n" +
                        $"Combo Ingredient List:\n");
                    foreach (var ing in item.IngredientList)
                    {
                        Console.WriteLine(ing);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Combos Set Up.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void AddComboToMenu()
        {
            Console.Clear();
            //Get number of combo
            int number;
            bool canConvert = false;
            do
            {
                Console.WriteLine("Please enter a number for the combo you'd like to add");
                canConvert = Int32.TryParse(Console.ReadLine(), out number);
            }
            while (!canConvert);
            //Get name of combo 
            Console.Clear();
            Console.WriteLine("Please enter the name for the combo you'd like to add");
            string name = Console.ReadLine();
            //Get combo price
            Console.Clear();
            decimal price;
            canConvert = false;
            do
            {
                Console.WriteLine("Please enter the price of the combo you'd like to add");
                canConvert = decimal.TryParse(Console.ReadLine(), out price);
            }
            while (!canConvert);
            //Get ingredient list
            Console.Clear();
            canConvert = false;
            int ingNum;
            List<string> ingredientList = new List<string>();
            do
            {
                Console.WriteLine("Please enter the number of items on the combo you'd like to add");
                canConvert = Int32.TryParse(Console.ReadLine(), out ingNum);
            }
            while (!canConvert);
            Console.Clear();
            for (int i = 1; i <= ingNum; i++)
            {
                Console.WriteLine($"Enter the name of item #{i} to add to the combo");
                ingredientList.Add(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine($"The following information will be added to the menu as a combo\n" +
                        $"Combo Number:{number}\n" +
                        $"Combo Name: {name}\n" +
                        $"Combo Price: {price}\n" +
                        $"Combo Ingredient List:\n");
            foreach (var item in ingredientList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n\n Please enter 'y' + enter to confirm or 'n' + enter to exit");
            string confirmAdd = Console.ReadLine();
            if (confirmAdd.ToLower() == "y")
            {
                _menu.CreateMenuItem(name, number, ingredientList, price);
                Console.Clear();
                Console.WriteLine("Combo added to menu.");
            };
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        private void RemoveComboFromMenu()
        {
            Console.Clear();
            int number;
            bool canConvert = false;
            List<Menu> menuItems = _menu.GetMenuItems();

            if (menuItems.Count != 0)
            {
                foreach (var item in menuItems)
                {
                    Console.WriteLine($"\nCombo Number: #{item.Number}\n" +
                        $"Combo Name: {item.Name}\n");
                }
            }
            else
            {
                Console.WriteLine("No Combos Set Up.");
            }

            do
            {
                Console.WriteLine("Please enter the number of the combo to be removed");
                canConvert = Int32.TryParse(Console.ReadLine(), out number);
            }
            while (!canConvert);
            if (_menu.ReturnMeal(number) != null)
            {
                Console.Clear();
                Console.WriteLine($"WARNING! You are about to delete Combo #{number}\n" +
                    "Please confirm by pressing 'y' + enter for yes or 'n' + enter for no.");
                string confirmDelete = Console.ReadLine();
                if (confirmDelete.ToLower() == "y")
                {
                    if (_menu.DeleteByNumber(number))
                    {
                        Console.WriteLine($"Combo #{number} succesfully removed.");
                    }
                }
                else
                {
                    Console.WriteLine("Thank you. This combo will stay on the menu.");
                }
            }
            else
            {
                Console.WriteLine($"There is no Combo #{number} on the menu.");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            _menu.CreateMenuItem("Royal with Cheese Combo", 1, new List<string>() { "1/4lb with cheese", "fries", "coke" },4.95m);
            _menu.CreateMenuItem("Grilled Chicken", 2, new List<string>() { "Grilled Chicken", "Salad", "Water" }, 3.85m);

        }
        
    }
}
