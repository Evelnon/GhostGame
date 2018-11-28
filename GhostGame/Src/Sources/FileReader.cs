using GhostGame.Src.ErrorHandling;
using System;
using System.IO;
using System.Linq;

namespace GhostGame.Src.Sources
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
            {
                words = File.ReadAllLines(path);
                if(words.Length == 0)
                    throw new FileEmptyException();
            }
            else
                throw new FileNotFoundException();


        }
    }
}