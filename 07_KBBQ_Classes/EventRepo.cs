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
        private List<EventFood> _eventFood = new List<EventFood>();
        private List<EventBooth> _eventBooth = new List<EventBooth>();
        private List<Event> _pastEvents = new List<Event>();
        //Add Food
        public bool AddFood(string itemName, Dictionary<string, double> ingredientAndPrice)
        {
            Food newFood = new Food(itemName, ingredientAndPrice);
            _foodList.Add(newFood);
            return true;
        }

        //Add Event Food (Food+Tickets)
        public bool AddEventFood(Food eventFood, int ticketsTaken)
        {
            EventFood newEventFood = new EventFood(eventFood, ticketsTaken);
            _eventFood.Add(newEventFood);
            return true;
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
        //Get EventBoothsByEventName

        public List<EventBooth> GetEventBoothsByName(string eventName)
        {
            Event getEvent = GetEventByName(eventName);
            if (getEvent != null)
            {
                return getEvent.EventBoothList;
            }
            return null;
        }
        //GetEventFoodsByEventName
        public List<EventFood> GetEventFoodsByName(string eventName)
        {
            List<EventBooth> getBooth = GetEventBoothsByName(eventName);
            List<EventFood> _getEventFood = new List<EventFood>();
            if (getBooth != null)
            {
                foreach (var item in getBooth)
                {
                    _getEventFood.AddRange(item.BoothEventFood);
                }
                return _getEventFood;
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
        //Remove Event
        public bool RemoveEventByName(string eventName)
        {
            Event removedEvent = GetEventByName(eventName);
            _pastEvents.Remove(removedEvent);
            return true;
        }
        //Remove Booth from event
        public bool RemoveBoothFromEvent(string eventName, string removeBooth)
        {
            List<EventBooth> eventBooths = GetEventBoothsByName(eventName);
            if (eventBooths != null)
            {
                foreach (var item in eventBooths)
                {
                    if (item.BoothName == removeBooth)
                    {
                        eventBooths.Remove(item);
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        //Remove EventFood from booth
        public bool RemoveEventFoodFromBooth(string eventName, string boothName, string removeFood)
        {
            List<EventBooth> eventBooths = GetEventBoothsByName(eventName);
            if (eventBooths != null)
            {
                foreach (var item in eventBooths)
                {
                    if (item.BoothName == boothName)
                    {
                        foreach (var item2 in item.BoothEventFood)
                        {
                            if (item2.FoodAtEvent.ItemName == removeFood)
                            {
                                item.BoothEventFood.Remove(item2);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }
        //Remove Food from list
        public bool RemoveFood(string foodName)
        {
            foreach (var item in _foodList)
            {
                if(item.ItemName==foodName)
                {
                    _foodList.Remove(item);
                    return true;
                }
            }
            return false;
        }

        //Update Food/ingredientList
        //Update TicketsTaken at Event
        //Update food at booths
        //update eventName
    }
}
