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
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            List<IMenu> menuOptions = new List<IMenu>()
            {
                new HandleNextClaim(),
                new ViewAllClaims(),
                new AddClaim(),
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
        private void SeedContent()
        {
            _repo.AddClaim(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _repo.AddClaim(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            _repo.AddClaim(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

        }
    }
}
