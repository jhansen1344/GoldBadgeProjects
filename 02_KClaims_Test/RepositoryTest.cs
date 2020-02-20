using System;
using System.Collections.Generic;
using _02_KClaims_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KClaims_Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestAddClaimToQueue_ShouldReturnTrue()
        {
            ClaimRepository _claimQ = new ClaimRepository();
            int id = 1;
            ClaimType typeOfClaim = ClaimType.Car;
            string description = "Car accident on 465.";
            decimal claimAmount = 400.00m;
            DateTime incidentDate = new DateTime(2018, 04, 25);
            DateTime claimDate = new DateTime(2018, 04, 27);
            Assert.IsTrue(_claimQ.AddClaim(id, typeOfClaim, description, claimAmount, incidentDate, claimDate)); 
        }

        private ClaimRepository _claimQ ;
        [TestInitialize]
        public void Arrange()
        {
            _claimQ = new ClaimRepository();
            int id = 1;
            ClaimType typeOfClaim = ClaimType.Car;
            string description = "Car accident on 465.";
            decimal claimAmount = 400.00m;
            DateTime incidentDate = new DateTime(2018, 04, 25);
            DateTime claimDate = new DateTime(2018, 04, 27);
            _claimQ.AddClaim(id, typeOfClaim, description, claimAmount, incidentDate, claimDate);

            id = 2;
            typeOfClaim = ClaimType.Home;
            description = "House fire in kitchen";
            claimAmount = 4000.00m;
            incidentDate = new DateTime(2018, 04, 25);
            claimDate = new DateTime(2018, 04, 27);
            _claimQ.AddClaim(id, typeOfClaim, description, claimAmount, incidentDate, claimDate);

        }

        [TestMethod]
        public void TestReturnAllClaims_ShouldReturnClaims()
        {
            Queue<Claim> testQ = _claimQ.GetClaims();
            Assert.AreEqual(2, testQ.Count);
        }

        [TestMethod]
        public void TestGetNextClaim_ShouldReturnClaimAndDequeue()
        {
            Claim nextClaim = _claimQ.DairyQueenNextClaim();
            Queue<Claim> testQ = _claimQ.GetClaims();
            Assert.AreEqual(400.00m, nextClaim.ClaimAmount);
            Assert.AreEqual(1, testQ.Count);
            Assert.IsTrue(nextClaim.IsValid);
        }

        [TestMethod]
        public void TestPeekNextClaim_ShouldReturnClaimAndNotDequeue()
        {
            Claim peekClaim = _claimQ.PeekNextClaim();
            Queue<Claim> testQ = _claimQ.GetClaims();
            Assert.AreEqual(400.00m, peekClaim.ClaimAmount);
            Assert.AreEqual(2, testQ.Count);
        }
    }
}
