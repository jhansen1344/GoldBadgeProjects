using _07_KBBQ_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KBBQ_Console._07_ProgramUI
{
    class ProgramUI
    {
        private readonly EventRepo _eventRepo = new EventRepo();
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

                new AddEvent(),
                new ViewEventInfo(),
                new RemoveEvent(),
                new Exit(),
                
                //new AddEvent(),
               // new TicketsAndCostViewPastEvents(),
               // new RemoveEvent(),
               //new Exit(),
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

                menuOptions[optionIndex - 1].RunMethod(_eventRepo);
            }

        }
        private void SeedContent()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientAndPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _eventRepo.AddFood(itemName, ingredientAndPrices);
            itemName = "VeggieBurger";
            ingredientAndPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Veggie Pattie",1.05 }
            };
            _eventRepo.AddFood(itemName, ingredientAndPrices);
            _eventRepo.AddBooth("Burger Booth");
            _eventRepo.AddBooth("Ice cream Booth");
            List<Food> foodList = _eventRepo.GetFoods();
            int ticketsTaken = 400;
            _eventRepo.AddEventFood(foodList[0], ticketsTaken);
            ticketsTaken = 150;
            _eventRepo.AddEventFood(foodList[1], 150);
            List<EventFood> eventFoods = _eventRepo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            _eventRepo.AddEventBooth(boothName, eventFoods, lumpSum);
            List<EventBooth> eventBooths = _eventRepo.GetEventBooths();
            string eventName = "2020AnnualBBQ";
            DateTime eventDate = DateTime.Now;
            _eventRepo.AddEvent(eventName, eventBooths, eventDate);
        }
    }

}
