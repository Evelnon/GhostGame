using System;
using GhostGame.Src;
using GhostGame.Src.AI;
using GhostGame.Src.Rulesets;
using GhostGame.Src.Scoring;
using GhostGame.Src.Sources;
using GhostGame.Src.WordManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace GhostGame.Tests
{
    [TestClass]
    public class GameTest
    {

        protected IRuleset ruleSet;
        protected IPlayer turn;
        protected WordManager wordManager;
        public Player human = new Player(new Score());
        public Player cpu = new Player(new Score(), new RandomAI());


        [SetUp]
        private void SetTest(string[] arrayList)
        {
            ruleSet = new Ghost();
            Mock<IReader> files = new Mock<IReader>();
            files.Setup(x => x.GetWordList()).Returns(() => arrayList);
            wordManager = new WordManager(files.Object, ruleSet);
            wordManager.SetStartingWord();
        }


        [TestMethod]
        public void When_CPUisLosing_ReturnExpectedWord_Test()
        {           
            string[] arrayList = { "hola", "holzzzzzz" };          
            SetTest(arrayList);

            cpu.EvaluateAnswer(wordManager.GetPotentialListOfWords(), wordManager.GetCurrentWord);
            NUnit.Framework.Assert.IsTrue("z" == cpu.GetAnswer() );
        }
        [TestMethod]
        public void When_CPULose_returnsValidWordFalse_Test()
        {
            string[] arrayList = { "hola" };
            SetTest(arrayList);

            cpu.EvaluateAnswer(wordManager.GetPotentialListOfWords(), wordManager.GetCurrentWord);
            NUnit.Framework.Assert.IsFalse(wordManager.CheckValidWord(cpu.GetAnswer()));
        }
        [TestMethod]
        public void When_CPULose_increaseErrorCounter_Test()
        {
            string[] arrayList = { "hola" };
            SetTest(arrayList);

            Game.CpuInput(cpu, wordManager);
            NUnit.Framework.Assert.IsTrue(cpu.GetCurrentScore() > 0);
        }

       
        
    }
}