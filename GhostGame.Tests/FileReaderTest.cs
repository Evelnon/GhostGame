using System;
using System.Collections.Generic;
using GhostGame.Src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GhostGame.Tests
{
    [TestClass]
    public class FileReaderTest
    {
        private Mock<IReader> files = new Mock<IReader>();
        public FileReaderTest()
        {
            string[] arrayList = { "hola", "holas", "holaaas", "holgazan" };
            
            files.Setup(x => x.GetWordList()).Returns(() => arrayList);
        }

        [TestMethod]
        public void When_Reading_WordList_From_File_Source_Test()
        {
            Assert.IsNotNull(files.Object.GetWordList());
        }

      
    }
}
