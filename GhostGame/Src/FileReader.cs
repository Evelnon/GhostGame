using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"File\ghostGameDict.txt");
            if (File.Exists(path))
            { words = File.ReadAllLines(path); }


        }
    }
}