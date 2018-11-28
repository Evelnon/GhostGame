using GhostGame.Src.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace GhostGame.Tests
{
    [TestClass]
    public class FileReaderTest
    {
        private Mock<IReader> files = new Mock<IReader>();
        [SetUp]
        private void FileReader()
        {
            string[] arrayList = { "hola", "holas", "holaaas", "holgazan" };            
            files.Setup(x => x.GetWordList()).Returns(() => arrayList);
        }

        [TestMethod]
        public void When_Reading_WordList_From_File_Source_Test()
        {
            NUnit.Framework.Assert.IsNotNull(files.Object.GetWordList());
        }

      
    }
}
