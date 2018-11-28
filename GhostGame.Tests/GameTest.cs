using System;
using GhostGame.Src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GhostGame.Tests
{
    [TestClass]
    public class GameTest
    {
        
        protected IRuleset ruleSet;
        protected IPlayer turn;
        protected WordManager wordManager;
        public Player human = new Player(new Score());
        public Player cpu = new Player(new Score());


        [TestMethod]
        public void When_GameStarts_PlayerSendS_Success_Test()
        {
            ruleSet = new Ghost();            
            string[] arrayList = { "hola", "holas", "holaaas" };
            Mock<IReader> files = new Mock<IReader>();
            files.Setup(x => x.GetWordList()).Returns(() => arrayList);
            wordManager = new WordManager(files.Object, ruleSet);
            wordManager.GetStartingWord();

        }
    }
}
