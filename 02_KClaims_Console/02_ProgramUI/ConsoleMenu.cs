using _02_KClaims_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims_Console._02_ProgramUI
{
    class AddClaim : IMenu
    {
        public string Description => "Add Claim";
        public void RunMethod(ClaimRepository _repo)
        {
            string userInput = "";
            int claimID;
            int claimTypeInt;
            decimal claimAmount;
            DateTime incidentDate = new DateTime();
            DateTime claimDate = new DateTime();
            //Enter claim id int
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the claim ID");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out claimID) || claimID < 0);

            //Enter type of claim enum
            ClaimType[] claimTypeCount = (ClaimType[])Enum.GetValues(typeof(ClaimType));
            int i = 1;
            foreach (var item in claimTypeCount)
            {
                Console.WriteLine($"{i} {item}");
                i++;
            }
            do
            {
                Console.WriteLine("Enter the number corresponding to the claim type");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out claimTypeInt) || claimTypeInt > claimTypeCount.Length || claimTypeInt < 1);
            claimTypeInt -= 1;
            ClaimType typeOfClaim = (ClaimType)claimTypeInt;

            //Enter claim description string
            Console.WriteLine("Enter Claim Description");
            string description = Console.ReadLine();

            //enter claim amount decimal
            do
            {
                Console.WriteLine("Enter Claim Amount");
                userInput = Console.ReadLine();
            }
            while (!Decimal.TryParse(userInput, out claimAmount) || claimAmount < 0);

            //enter incident date date time
            Console.WriteLine("\n ClaimType");
            do
            {
                Console.WriteLine("Enter the Incident Date in the following format: MM/DD/YYYY");
                userInput = Console.ReadLine();
                userInput.Trim('/');
            }
            while (!DateTime.TryParseExact(userInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                               System.Globalization.DateTimeStyles.AdjustToUniversal, out incidentDate));

            //enter claim date date time
            do
            {
                Console.WriteLine("Enter the Claim Date in the following format: MM/DD/YYYY");
                userInput = Console.ReadLine();
                userInput.Trim('/');
            }
            while (!DateTime.TryParseExact(userInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                              System.Globalization.DateTimeStyles.AdjustToUniversal, out claimDate));
            //Add claim to queue
            _repo.AddClaim(claimID, typeOfClaim, description, claimAmount, incidentDate, claimDate);
            Console.WriteLine("\n Claim succesfully added\n" +
                "Press any key to return to the Menu.");
            Console.ReadKey();
        }
    }

    class HandleNextClaim : IMenu
    {
        public string Description => "Handle Next Claim";
        public void RunMethod(ClaimRepository _repo)
        {
            Console.Clear();
            Claim nextClaim = _repo.PeekNextClaim();
            if (nextClaim != null)
            {

                Console.WriteLine($"Details on next claim in queue\n" +
                    $"{"ID",-10}{"Type",-10}{"Description",-30}{"Amount",-10}{"Incident Date",-20}{"Claim Date",-20}{"Claim Valid?"}\n" +
                    $"{nextClaim.ID,-10}{nextClaim.TypeOfClaim,-10}{nextClaim.Description,-30}{nextClaim.ClaimAmount,-10}{nextClaim.IncidentDate.ToShortDateString(),-20}{nextClaim.ClaimDate.ToShortDateString(),-20}{nextClaim.IsValid}\n");
                bool continueToRun = true;
                do
                {
                    Console.WriteLine($"\n Enter 'y' to handle next claim. Enter 'n' to return to Main Menu");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        continueToRun = false;
                        nextClaim = _repo.DairyQueenNextClaim();
                        Console.WriteLine("Claim removed from queue and entered for processing.\n" +
                            "Press any key to return to the Main Menu.");
                        Console.ReadKey();
                    }
                    else if (userInput == "n")
                        continueToRun = false;
                }
                while (continueToRun);
            }
            else
            {
                Console.WriteLine("There are no more claims in the queue\n" +
                    "Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
    }
    class ViewAllClaims : IMenu
    {
        public string Description => "View All Claims";
        public void RunMethod(ClaimRepository _repo)
        {
            Console.Clear();
            Queue<Claim> allClaims = _repo.GetClaims();
            Console.WriteLine($"{"ID",-10}{"Type",-10}{"Description",-30}{"Amount",-10}{"Incident Date",-20}{"Claim Date",-20}{"Claim Valid?"}");
            foreach (var item in allClaims)
            {
                Console.WriteLine($"{item.ID,-10}{item.TypeOfClaim,-10}{item.Description,-30}{item.ClaimAmount,-10}{item.IncidentDate.ToShortDateString(),-20}{item.ClaimDate.ToShortDateString(),-20}{item.IsValid}");
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }
    }
    class Exit : IMenu
    {
        public string Description => "Exit";
        public void RunMethod(ClaimRepository _repo)
        {
            Environment.Exit(0);
        }
    }
}
