using System;
using System.Collections.Generic;
using _01_KCafe_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KCafe_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateMenuItem_ShouldReturnTrue()
        {
          MenuRepository _menu = new MenuRepository();
           string name = "royal with cheese";
           int number = 1;
          List<string> ingredientList = new List<string>() { "1/4 lb. burger with cheese", "fries", "coke" };
          decimal price = 4.95m;

            Assert.IsTrue(_menu.CreateMenuItem(name, number, ingredientList, price));
        }

        public void TestMenuDescription_ShouldReturnConcatenatedMenuCombo()
        {
            string name = "royal with cheese";
            int number = 1;
            List<string> ingredientList = new List<string>() { "1/4 lb. burger with cheese", "fries", "coke" };
            decimal price = 4.95m;
            Menu newItem = new Menu(name,number,ingredientList,price);
            Assert.AreEqual("1/4 lb. burger with cheese, fries, coke", newItem.Description);

        }

        [TestMethod]
        public void ReturnMenu_ShouldReturnContent()
        {
            MenuRepository _menu = new MenuRepository();
            string name = "royal with cheese";
            int number = 1;
            List<string> ingredientList = new List<string>() { "1/4 lb. burger with cheese", "fries", "coke" };
            decimal price = 4.95m;

           _menu.CreateMenuItem(name, number, ingredientList, price);
            List<Menu> returnedList = new List<Menu>();
            returnedList = _menu.GetMenuItems();
            Assert.AreEqual(1, returnedList.Count);
        }

        [TestMethod]
        public void TestDeleteMethod_ShouldReturnTrue()
        {
            MenuRepository _menu = new MenuRepository();
            string name = "royal with cheese";
            int number = 1;
            List<string> ingredientList = new List<string>() { "1/4 lb. burger with cheese", "fries", "coke" };
            decimal price = 4.95m;

            _menu.CreateMenuItem(name, number, ingredientList, price);
            Assert.IsTrue(_menu.DeleteByNumber(1));

            List<Menu> returnedList = new List<Menu>();
            returnedList = _menu.GetMenuItems();
            Assert.AreEqual(0, returnedList.Count);

        }
    }
}
