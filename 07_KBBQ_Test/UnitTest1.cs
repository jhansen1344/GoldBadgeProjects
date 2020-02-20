using System;
using System.Collections.Generic;
using _07_KBBQ_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_KBBQ_Test
{
    [TestClass]
    public class UnitTest1
    {
        private EventRepo _repo = new EventRepo();
        [TestMethod]
        public void TestAddFood_ShouldReturnTrue()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            Food newFood = _repo.AddFood(itemName, ingredientandPrices);
            Assert.IsTrue(newFood.IngredientAndPrice.ContainsKey("Bun"));
        }

        [TestMethod]
        public void TestGetFoods_ShouldReturnFoods()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            Assert.AreEqual(1.50, foodList[0].ItemPrice);
        }

        [TestMethod]
        public void TestAddEventFood_ShouldReturnTrue()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            EventFood testFood = _repo.AddEventFood(foodList[0], ticketsTaken);
            Assert.AreEqual(400, testFood.TicketsTaken);
        }

        [TestMethod]
        public void TestGetEventFood_ShouldReturnEventFood()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            Assert.AreEqual(600, eventFoods[0].EventItemCost);
        }

        [TestMethod]
        public void TestAddEventBooth_ShouldReturnTrue()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            Assert.IsTrue(_repo.AddEventBooth(boothName, eventFoods, lumpSum));
        }

        [TestMethod]
        public void TestGetEventBooth_ShouldReturnEventBooth()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            _repo.AddEventBooth(boothName, eventFoods, lumpSum);
            List<EventBooth> eventBooths = _repo.GetEventBooths();
            Assert.AreEqual(1525, eventBooths[0].TotalBoothCost);
        }

        [TestMethod]
        public void TestAddEvent_ShouldReturnTrue()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            _repo.AddEventBooth(boothName, eventFoods, lumpSum);
            List<EventBooth> eventBooths = _repo.GetEventBooths();
            string eventName = "AnnualBBQ";
            DateTime eventDate = DateTime.Now;
            Assert.IsTrue(_repo.AddEvent(eventName, eventBooths, eventDate));
        }
        [TestMethod]
        public void TestGetEvent_ShouldReturn()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientandPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientandPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            _repo.AddEventBooth(boothName, eventFoods, lumpSum);
            List<EventBooth> eventBooths = _repo.GetEventBooths();
            string eventName = "2020AnnualBBQ";
            DateTime eventDate = DateTime.Now;
            _repo.AddEvent(eventName, eventBooths, eventDate);
            List<Event> pastEvents = _repo.GetPastEvents();
            Assert.AreEqual(3050, pastEvents[0].TotalEventCost);
        }
        [TestInitialize]
        public void Arrange()
        {
            string itemName = "Burger";
            Dictionary<string, double> ingredientAndPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", .75 },
                {"Cheese", .30 }
            };
            _repo.AddFood(itemName, ingredientAndPrices);
            itemName = "VeggieBurger";
            ingredientAndPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Veggie Pattie",1.05 }
            };
            _repo.AddFood(itemName, ingredientAndPrices);
            List<Food> foodList = _repo.GetFoods();
            int ticketsTaken = 400;
            _repo.AddEventFood(foodList[0], ticketsTaken);
            ticketsTaken = 150;
            _repo.AddEventFood(foodList[1], 150);
            List<EventFood> eventFoods = _repo.GetEventFoods();
            string boothName = "Burger Booth";
            double lumpSum = 100;
            _repo.AddEventBooth(boothName, eventFoods, lumpSum);
            List<EventBooth> eventBooths = _repo.GetEventBooths();
            string eventName = "2020AnnualBBQ";
            DateTime eventDate = DateTime.Now;
            _repo.AddEvent(eventName, eventBooths, eventDate);
        }

        [TestMethod]
        public void TestRemoveEvent_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.RemoveEventByName("2020AnnualBBQ"));
            List<Event> pastEvents = _repo.GetPastEvents();
            Assert.AreEqual(0, pastEvents.Count);
        }

        [TestMethod]
        public void TestRemoveFood_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.RemoveFood("Burger"));
            Assert.AreEqual(1, _repo.GetFoods().Count);
        }

        [TestMethod]
        public void TestGetTickets_ShouldReturnTickets()
        {
            int eventTickets = _repo.GetTotalTickets("2020AnnualBBQ");
            Assert.AreEqual(550, eventTickets);
        }

        [TestMethod]
        public void TestGetEventCost_ShouldReturnCost()
        {
            double eventCost = _repo.GetEventCost("2020AnnualBBQ");
            Assert.AreEqual(925, eventCost);
        }

        [TestMethod]
        public void TestGetFoodByName_ShouldReturnFood()
        {
            Food testFood = _repo.GetFoodByName("Burger");
            Assert.IsTrue(testFood.IngredientAndPrice.ContainsKey("Patty"));
        }

        [TestMethod]
        public void TestUpdateIngredientPrices_ShouldIncreaseBy1()
        {
            double oldPrice = _repo.GetFoodByName("Burger").ItemPrice;
            
            Dictionary<string, double> newIngredientAndPrices = new Dictionary<string, double>()
            {
                {"Bun", .45 },
                {"Patty", 1.75 },
                {"Cheese", .30 }
            };
            _repo.UpdateIngredientPrices("Burger", newIngredientAndPrices);
            Assert.AreEqual(oldPrice + 1, _repo.GetFoodByName("Burger").ItemPrice);
        }
    }
}