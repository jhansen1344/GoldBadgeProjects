using _02_KClaims_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims_Console._02_ProgramUI
{
    class ProgramUI
    {
        private readonly ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            List<IMenu> menuOptions = new List<IMenu>()
            {
                //new AddABadge(),
               // new UpdateBadge(),
               // new RemoveAllDoorAccess(),
               // new ViewAllBadges(),
                new Exit(),
            };
            while (continueToRun)
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
