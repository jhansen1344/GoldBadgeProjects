using _03_KBadges_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console.UI
{

    class ProgramUI
    {
        private readonly BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        { 
            bool continueToRun = true;
            List<IMenu> menuOptions = new List<IMenu>()
            {
                new AddABadge(),
                new UpdateBadge(),
                new RemoveAllDoorAccess(),
                new ViewAllBadges(),
                new Exit(),
            };
            while(continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}  {menuOptions[i].Description}");
                }

                string userInput = "";
                int optionIndex;
                do
                {
                    Console.WriteLine("\n Please enter an option from the menu above.");
                    userInput = Console.ReadLine();
                }
                while (!int.TryParse(userInput, out optionIndex) || optionIndex > menuOptions.Count);

                menuOptions[optionIndex - 1].RunMethod(_repo);
            }
        }
    }
}
