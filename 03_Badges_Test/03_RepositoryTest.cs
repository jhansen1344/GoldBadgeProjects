using System;
using System.Collections.Generic;
using _03_KBadges_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Test
{

    [TestClass]
    public class RepositoryTest
    {
        private BadgeRepository _repo;
        [TestMethod]
        public void TestAddBadge_ShouldReturnTrue()
        {
            _repo = new BadgeRepository();
            int id = 12345;
            List<string> doorList = new List<string> { "A5", "A7" };
            Assert.IsTrue(_repo.AddBadge(id, doorList));
        }

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            int id = 12345;
            List<string> doorList = new List<string> { "A5", "A7" };
            _repo.AddBadge(id, doorList);
            id = 22345;
            doorList = new List<string> { "A1", "B4" };
            _repo.AddBadge(id, doorList);
        }

        [TestMethod]
        public void TestGetAllBadges_ShouldReturnDictionary()
        {
            Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();
            badgeDictionary = _repo.GetAllBadges();
            Assert.IsTrue(badgeDictionary.Count > 0);
        }

        [TestMethod]
        public void TestGetAllDoors_ShouldReturnListString()
        {
            List<string> doorAccess = new List<string>();
            doorAccess = _repo.GetDoorAccess(12345);
            Assert.IsTrue(doorAccess.Count > 0);
            Assert.AreEqual("A5", doorAccess[0]);
        }

        [TestMethod]
        public void TestAddDoorAccess_ShouldReturnTrue()
        {
            _repo.UpdateDoorAccess(22345, "B1");
            List<string> doorAccess = new List<string>();
            doorAccess = _repo.GetDoorAccess(22345);
            Assert.IsTrue(doorAccess.Contains("B1"));
        }

        [TestMethod]
        public void RemoveDoorAccess_ShouldReturnTrue()
        {
            _repo.UpdateDoorAccess(22345, "A1");
            List<string> doorAccess = new List<string>();
            doorAccess = _repo.GetDoorAccess(22345);
            Assert.IsFalse(doorAccess.Contains("A1"));
        }

        [TestMethod]
        public void RemoveAllDoorAccess_ShouldReturnTrue()
        {
            Assert.IsTrue(_repo.RemoveAllDoorAccess(12345));
            List<string> doorAccess = new List<string>();
            doorAccess = _repo.GetDoorAccess(12345);
            Assert.IsTrue(doorAccess.Count == 0);
        }
    }
}
