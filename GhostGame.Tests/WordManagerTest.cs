using System;
using System.Linq;
using GhostGame.Src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GhostGame.Tests
{
    [TestClass]
    public class WordManagerTest
    {
        protected IRuleset ruleSet;
        public WordManager wordManager;

        public WordManagerTest()
        {
            ruleSet = new Ghost();
            string[] arrayList = { "hola", "holas", "holaaas","holgazan" };
            Mock<IReader> files = new Mock<IReader>();
            files.Setup(x => x.GetWordList()).Returns(() => arrayList);
            wordManager = new WordManager(files.Object, ruleSet);
            wordManager.GetStartingWord();
        }

        [TestMethod]
        public void When_WordManagerInitialized_CheckList_Test()
        {          
           
            Assert.IsTrue(wordManager.GetCurrentWord.Contains("hol"));
        }

        [TestMethod]
        public void When_LetterSend_CompletedWord_Test()
        {
           
            Assert.IsFalse(wordManager.CheckValidWord("a"));
        }
        [TestMethod]
        public void When_LetterSend_NoWordFound_Test()
        {
            
            Assert.IsFalse(wordManager.CheckValidWord("j"));
        }
        [TestMethod]
        public void When_LetterSend_GoodCombination_Test()
        {

            Assert.IsTrue(wordManager.CheckValidWord("g"));
        }
        [TestMethod]
        public void When_LetterSet_ReturnsListOfPossibilites_Test()
        {
            When_LetterSend_GoodCombination_Test();
            Assert.IsTrue(wordManager.GetPotentialListOfWords().Any());
        }
    }
}
