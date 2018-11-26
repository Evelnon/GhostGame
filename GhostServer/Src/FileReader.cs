using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GhostGame.Src
{
    public class FileReader : IReader
    {
        private string[] words;

        public FileReader()
        {
           ReadFile();
        }

        public string[] GetWordList()
        {
            return words;
        }

        public int NumberOfAvailableWords()
        {
            return words.Count();
        }

        public void ReadFile()
        {
            words = System.IO.File.ReadAllLines(@"File\gosthGameDict.txt");                  
        }
    }
}