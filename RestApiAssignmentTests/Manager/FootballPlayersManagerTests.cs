using Football;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApiAssignment.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiAssignment.Manager.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        FootballPlayersManager playerManager = new FootballPlayersManager();

        [TestMethod()]
        public void GetAllTest()
        {
            List<FootballPlayer> testList = playerManager.GetAll(null);

            Assert.AreEqual(5, testList.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            var newPlayer = new FootballPlayer() { Age = 25, Name = "Rudo", ShirtNumber = 25 };

            var createdPlayer = playerManager.Add(newPlayer);

            Assert.AreEqual(5, createdPlayer.Id);
            Assert.AreEqual(5, playerManager.GetAll(null).Count);
        }
    }
}