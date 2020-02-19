using _07_KBBQ_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KBBQ_Console._07_ProgramUI
{
    class AddEvent : IMenu
    {
        public string Description => "Add Event";

        public void RunMethod(EventRepo _eventRepo)
        {
            Console.Clear();
            Console.WriteLine("Enter an event name");
            string eventName = Console.ReadLine();
            string userInput;
            DateTime eventDate = new DateTime();
            do
            {
                Console.WriteLine("Enter the event date in the following format: MM/DD/YYYY");
                userInput = Console.ReadLine();
                userInput.Trim('/');
            }
            while (!DateTime.TryParseExact(userInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                                System.Globalization.DateTimeStyles.AdjustToUniversal, out eventDate));
            List<EventBooth> eventBooths = new List<EventBooth>();
            int numberBooths = 0;
            do
            {
                Console.WriteLine("Enter the number of booths at the event");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out numberBooths));

            List<Booth> booths = _eventRepo.GetBooths();
            int boothOption;
            for (int i = 0; i < numberBooths; i++)
            {
                Console.Clear();
                Console.WriteLine("Available Booths");
                foreach (var booth in booths)
                {
                    Console.WriteLine($"{ booths.IndexOf(booth) + 1} {booth.BoothName}");
                }
                do
                {
                    Console.WriteLine("Enter the number corresponding to the booth you want to add");
                    userInput = Console.ReadLine();
                }
                while (!int.TryParse(userInput, out boothOption) || boothOption > booths.Count);

                string boothName = booths[boothOption - 1].BoothName;
                double lumpSum;
                do
                {
                    Console.WriteLine($"Enter the sum for miscellaneous costs for the {boothName}");

                    userInput = Console.ReadLine();
                }
                while (!Double.TryParse(userInput, out lumpSum));

                int numberFood;
                do
                {
                    Console.WriteLine($"Enter the number of food items available at the {boothName}");
                    userInput = Console.ReadLine();
                }
                while (!int.TryParse(userInput, out numberFood));
                List<Food> foodOptions = _eventRepo.GetFoods();
                List<EventFood> eventFoods = new List<EventFood>();
                Food foodAtEvent = new Food();

                for (int j = 0; j < numberFood; j++)
                {
                    int foodChoice;
                    Console.Clear();
                    Console.WriteLine("Available Foods");
                    foreach (var food in foodOptions)
                    {
                        Console.WriteLine($"{foodOptions.IndexOf(food) + 1} {food.ItemName}");
                    }
                    do
                    {
                        Console.WriteLine($"Enter the number corresponding to the food item to add to the {boothName}");
                        userInput = Console.ReadLine();
                    }
                    while (!int.TryParse(userInput, out foodChoice) || foodChoice > foodOptions.Count);
                    foodAtEvent = foodOptions[foodChoice - 1];
                    int numberTicket;
                    do
                    {
                        Console.WriteLine($"Enter the number of tickets taken for {foodAtEvent.ItemName}");
                        userInput = Console.ReadLine();
                    }
                    while (!int.TryParse(userInput, out numberTicket));
                    EventFood eventFood = new EventFood(foodAtEvent, numberTicket);
                    eventFoods.Add(eventFood);

                }
                EventBooth eventBooth = new EventBooth(boothName, eventFoods, lumpSum);
                eventBooths.Add(eventBooth);
            }
            _eventRepo.AddEvent(eventName, eventBooths, eventDate);
            int totalTickets = _eventRepo.GetTotalTickets(eventName);
            double totalCost = _eventRepo.GetEventCost(eventName);
            Console.WriteLine($"{eventName} added.\n" +
                $"Total Cost: ${totalCost}\n" +
                $"Total Tickets Taken: {totalTickets}\n\n" +
                $"Press any key to return to the main menu.");
            Console.ReadKey();

        }
    }

    class RemoveEvent : IMenu
    {
        public string Description => "Remove Event";
        public void RunMethod(EventRepo _eventRepo)
        {
            Console.WriteLine("Enter the name of the event to be removed");
            string eventToRemove = Console.ReadLine();
            if (_eventRepo.RemoveEventByName(eventToRemove))
            {
                Console.WriteLine($"{eventToRemove} Removed.");
            }
            else 
            {
                Console.WriteLine($"There is no event listed with the name {eventToRemove}.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();

        }
    }

    class ViewEventInfo:IMenu
    {
        public string Description => "View Events, Total Tickets, and Total Cost";
        public void RunMethod(EventRepo _eventRepo)
        {
            Console.Clear();
            List<Event> allEvents = _eventRepo.GetPastEvents();
            Console.WriteLine($"{"Event Name",-30}{"Event Date",-30}{"Total Tickets",-30}{"Total Cost",-30}");
            foreach (var item in allEvents)
            {
                Console.WriteLine($"{item.EventName,-30}{item.EventDate.ToShortDateString(),-30}{item.TotalTicketsTaken,-30}{item.TotalEventCost,-30}");
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }
    }

    class Exit : IMenu
    {
        public string Description => "Exit";
        public void RunMethod(EventRepo _eventRepo)
        {
            Environment.Exit(0);
        }
    }
}
