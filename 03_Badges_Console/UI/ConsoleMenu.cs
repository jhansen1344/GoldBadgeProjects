using _03_KBadges_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console.UI
{
    class AddABadge : IMenu
    {
        public string Description => "Add A Badge";
        public void RunMethod(BadgeRepository _repo)
        {
            string userInput = "";
            int badgeNumber;
            List<string> doorList = new List<string>();
            bool areMoreDoors = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number on the badge");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out badgeNumber));

            do
            {
                Console.WriteLine("Enter the door that it needs access to");
                doorList.Add(Console.ReadLine().ToUpper());
                Console.WriteLine("Enter 'y' to enter additional doors.  Enter 'n' to continue.");
                userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "y":
                        areMoreDoors = true;
                        break;
                    default:
                        areMoreDoors = false;
                        break;
                }
            }
            while (areMoreDoors);

            if (_repo.AddBadge(badgeNumber, doorList))
            {
                Console.WriteLine("Badge successfully added.\n" +
                    "Press any key to return to the Main Menu.");
                Console.ReadKey();
            }
        }
    }

    class UpdateBadge : IMenu
    {
        public string Description => "Update A Badge";
        public void RunMethod(BadgeRepository _repo)
        {
            string userInput = "";
            int badgeNumber;
            List<string> doorList = new List<string>();
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the badge number to update");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out badgeNumber)||badgeNumber<0);
            doorList = _repo.GetDoorAccess(badgeNumber);
            if (doorList == null)
            {
                Console.WriteLine($"Badge Number: {badgeNumber} is not set up.");
            }
            else if (doorList.Count == 0)
            {
                Console.WriteLine($"Badge Number: {badgeNumber} does not have any door access.");
            }
            else
            {
                string doorString = string.Join<string>(",", doorList);
               
                Console.WriteLine($"Badge Number: {badgeNumber} can access the following doors: {doorString}\n" +
                    $"Enter a door to add/remove access.");
                userInput = Console.ReadLine();
                List<string> updatedList = _repo.UpdateDoorAccess(badgeNumber, userInput);
                string updatedDoor = string.Join<string>(",", updatedList); ;
                
                Console.WriteLine($"Badge Number: {badgeNumber} can access the following doors: {updatedDoor}\n");
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }
    }

    class RemoveAllDoorAccess : IMenu
    {
        public string Description => "Remove All Door Access for Badge";
        public void RunMethod(BadgeRepository _repo)
        {
            string userInput = "";
            int badgeNumber;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the badge number to remove all door access");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out badgeNumber)||badgeNumber<0);

            List<string> doorList = _repo.GetDoorAccess(badgeNumber);
            if (doorList == null)
            {
                Console.WriteLine($"Badge Number: {badgeNumber} is not set up.");
            }
            else
            {
                string doorString = string.Join<string>(",", doorList);
                
                Console.WriteLine($"WARNING: ACCESS WILL BE REMOVED FOR BADGE NUMBER: {badgeNumber} ON THE ALL OF THE DOORS LISTED: {doorString}\n" +
                    $"Press 'y' to confirm");
                userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "y":
                        _repo.RemoveAllDoorAccess(badgeNumber);
                        Console.WriteLine($"All door access removed for badge number: {badgeNumber}");
                        break;
                    default:
                        Console.WriteLine($"No changes made to badge number: {badgeNumber}");
                        break;
                }
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }
    }

    class ViewAllBadges : IMenu
    {
        public string Description => "View All Badge Numbers and Door Access";
        public void RunMethod(BadgeRepository _repo)
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadges = _repo.GetAllBadges();
            Console.WriteLine("{0,-10} {1}", "Badge #", "Doors Access");
            foreach (var item in allBadges)
            {
                Console.WriteLine($"{item.Key,-10} { string.Join<string>(",",item.Value)}");
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }
    }

    class Exit : IMenu
    {
        public string Description => "Exit";
        public void RunMethod(BadgeRepository _repo)
        {
            Environment.Exit(0);
        }
    }
}
