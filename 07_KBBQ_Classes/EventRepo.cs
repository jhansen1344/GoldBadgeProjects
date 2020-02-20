using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KBBQ_Classes
{
    public class EventRepo
    {
        private List<Food> _foodList = new List<Food>();
        private List<Booth> _boothList = new List<Booth>();
        private List<EventFood> _eventFood = new List<EventFood>();
        private List<EventBooth> _eventBooth = new List<EventBooth>();
        private List<Event> _pastEvents = new List<Event>();
        //Add Food
        public Food AddFood(string itemName, Dictionary<string, double> ingredientAndPrice)
        {
            Food newFood = new Food(itemName, ingredientAndPrice);
            _foodList.Add(newFood);
            return newFood;
        }

        //Add Event Food (Food+Tickets)
        public EventFood AddEventFood(Food eventFood, int ticketsTaken)
        {
            EventFood newEventFood = new EventFood(eventFood, ticketsTaken);
            _eventFood.Add(newEventFood);
            return newEventFood;
        }

        public Booth AddBooth(string boothName)
        {
            Booth newBooth = new Booth(boothName);
            _boothList.Add(newBooth);
            return newBooth;
        }
        //Add Event Booth
        public bool AddEventBooth(string boothName, List<EventFood> boothFood, double lumpSum)
        {
            EventBooth newEventBooth = new EventBooth(boothName, boothFood, lumpSum);
            _eventBooth.Add(newEventBooth);
            return true;
        }
        //Add Event
        public bool AddEvent(string eventName, List<EventBooth> eventBoothList, DateTime eventDate)
        {
            Event newEvent = new Event(eventName, eventBoothList, eventDate);
            _pastEvents.Add(newEvent);
            return true;
        }
        //Return FoodList
        public List<Food> GetFoods()
        {
            return _foodList;
        }
        //Return Booths
        public List<Booth> GetBooths()
        {
            return _boothList;
        }
        //Return EventFoods
        public List<EventFood> GetEventFoods()
        {
            return _eventFood;
        }
        //Return EventBooths
        public List<EventBooth> GetEventBooths()
        {
            return _eventBooth;
        }
        //Return Events
        public List<Event> GetPastEvents()
        {
            return _pastEvents;
        }
        //Get EventByName
        public Event GetEventByName(string eventName)
        {
            foreach (var item in _pastEvents)
            {
                if (item.EventName == eventName)
                {
                    return item;
                }
            }
            return null;
        }
        public Food GetFoodByName(string foodName)
        {
            List<Food> allFoods = GetFoods();
            foreach (var item in allFoods)
            {
                if (item.ItemName == foodName)
                {
                    return item;
                }
            }
            return null;
        }
        //GetEventTotalTickets
        public int GetTotalTickets(string eventName)
        {
            Event getEvent = GetEventByName(eventName);
            if (getEvent != null)
            {
                return getEvent.TotalTicketsTaken;
            }
            return 0;
        }
        //GetEventCost
        public double GetEventCost(string eventName)
        {
            Event getEvent = GetEventByName(eventName);
            if (getEvent != null)
            {
                return getEvent.TotalEventCost;
            }
            return 0;
        }
        public bool UpdateIngredientPrices(string foodName, Dictionary<string, double> updatedPrices)
        {
            Food foodToUpdate = GetFoodByName(foodName);
            if (foodToUpdate != null)
            {
                foodToUpdate.IngredientAndPrice = updatedPrices;
                return true;
            }
            return false;
        }
        //Remove Event
        public bool RemoveEventByName(string eventName)
        {
            Event removedEvent = GetEventByName(eventName);
            if (removedEvent != null)
            {
                _pastEvents.Remove(removedEvent);
                return true;
            }
            return false;
        }
        //Remove Food from list
        public bool RemoveFood(string foodName)
        {
            foreach (var item in _foodList)
            {
                if (item.ItemName == foodName)
                {
                    _foodList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
