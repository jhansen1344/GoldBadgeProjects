using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KBBQ_Classes
{

    public class Food
    {
        public Food() { }
        public Food(string itemName, Dictionary<string, double> ingredientAndPrice)
        {
            ItemName = itemName;
            IngredientAndPrice = ingredientAndPrice;
        }
        public string ItemName { get; set; }
        public Dictionary<string, double> IngredientAndPrice = new Dictionary<string, double>();
        public double ItemPrice
        {
            get
            {
                double _itemPrice = 0;
                foreach (var item in IngredientAndPrice)
                {
                    _itemPrice += item.Value;
                }
                return _itemPrice;
            }
        }
    }

    public class EventFood
    {
        public EventFood() { }
        public EventFood(Food foodAtEvent, int ticketsTaken)
        {
            FoodAtEvent = foodAtEvent;
            TicketsTaken = ticketsTaken;
        }
        public Food FoodAtEvent { get; set; }
        public int TicketsTaken { get; set; }
        public double EventItemCost
        {
            get
            {
                return TicketsTaken * FoodAtEvent.ItemPrice;
            }
        }
    }

    public class Booth
    {
        public Booth() { }
        public Booth(string boothName)
        {
            BoothName = boothName;
        }
        public string BoothName { get; set; }
    }

    public class EventBooth : Booth
    {
        public EventBooth() { }
        public EventBooth(string boothName, List<EventFood> boothEventFood, double lumpSum)
        : base(boothName)
        {
        
            BoothEventFood = boothEventFood;
            LumpSum = lumpSum;
        }
        public List<EventFood> BoothEventFood { get; set; } = new List<EventFood>();
        public int TotalTickets {
            get
            {
                int _totalTickets=0;
                    foreach (var item in BoothEventFood)
                {
                    _totalTickets += item.TicketsTaken;
                }
                return _totalTickets;
            }
                
        }
        public double TotalBoothCost {
            get 
            {
                double _totalBoothCost = LumpSum;
                foreach (var item in BoothEventFood)
                {
                    _totalBoothCost += item.EventItemCost;
                }
                return _totalBoothCost;
            }
        }
        public double LumpSum { get; set; }
    }

    public class Event
    {
        public Event() { }
        public Event(string eventName, List<EventBooth> eventBoothList, DateTime eventDate)
        {
            EventName = eventName;
            EventBoothList = eventBoothList;
            EventDate = eventDate;
        }
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }
        public List<EventBooth> EventBoothList { get; set; } = new List<EventBooth>();
        public double TotalEventCost
        {
            get
            {
                double _totalCost=0;
                foreach (var item in EventBoothList)
                {
                    _totalCost += item.TotalBoothCost;
                }
                return _totalCost;
            }
        }
        public int TotalTicketsTaken { 
            get
            {
                int _totalTickets = 0;
                foreach (var item in EventBoothList)
                {
                    _totalTickets += item.TotalTickets;
                }
                return _totalTickets;
            }
        }

    }
}
