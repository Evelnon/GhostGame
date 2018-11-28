using System;
using GhostGame.Src;
using GhostGame.Src.Scoring;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GhostGame.Tests
{
    [TestClass]
    public class PlayerTest
    {
        IPlayer player = new Player(new Score());

        [TestMethod]
        public void When_PlayerStarts_ScoreIs0_Test()
        {
            Assert.IsTrue(player.GetCurrentScore() == 0);
        }

        [TestMethod]
        public void When_PlayerFails_IncreaseScore_Test()
        {
            player.Fail();
            Assert.IsTrue(player.GetCurrentScore() > 0);
        }
       
    }
}