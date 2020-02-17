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
        public void RunMethod (ClaimRepository _repo)
        {
            string userInput = "";
            int claimID;
            int claimTypeInt;
            //Enter claim id int

            do
            {
                Console.Clear();
                Console.WriteLine("Enter the claim ID");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out claimID));
            //Enter type of claim enum
            ClaimType[] claimTypeCount = (ClaimType[])Enum.GetValues(typeof(ClaimType));
            foreach (var item in claimTypeCount)
            {
                int i = 1;
                Console.WriteLine($"{i} {item}");
                i++;
            }
            do
            { 
                Console.WriteLine("Enter the number corresponding to the claim type");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out claimTypeInt) || claimTypeInt > claimTypeCount.Length);

            
            
        
        //Enter claim description string
            Console.WriteLine("Enter Claim Description");
            string description = Console.ReadLine();

            //enter claim amount decimal

            //enter incident date date time

            //enter claim date date time
            _repo.AddClaim(id, typeOfClaim, description, claimAmount, incidentDate, claimDate);

        }
    }
    
    
    class ViewAllClaims : IMenu
    {
        public string Description => "View All Claims";
        public void RunMethod(ClaimRepository _repo)
        {
            Console.Clear();
            Queue<Claim> allClaims = _repo.GetClaims();
            Console.WriteLine("{0,-5} {1,-5}{2,-5}{3,-5}{4,-5}{5,-5}{6-5}", "Claim ID", "Type","Description","Amount","Accident Date", "Claim Date", "Claim Valid?");
            foreach (var item in allClaims)
            {
                Console.WriteLine($"{item.ID, -5} {item.TypeOfClaim, -5}{item.Description,-5}{item.ClaimAmount,-5}{item.IncidentDate,-5}{item.ClaimDate,-5}{item.IsValid,-5}");
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
