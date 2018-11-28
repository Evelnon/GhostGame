using System;
using System.Collections.Generic;
using System.Linq;

namespace GhostGame.Src.AI
{
    public class RandomAI : IIA
    {
        Random rnd = new Random();
        public string EvaluateAnswer(List<string> wordList, string currentWord)
        {
            //retrieve list of possible answers
            var ListOfWords = wordList.FindAll(x => x.StartsWith(currentWord) && x.Length > currentWord.Length + 1)
                .OrderBy(x => x.Length);

            if (ListOfWords.Any())
            {
                var rngIndex = rnd.Next(0, ListOfWords.Count());
                return ListOfWords.ElementAt(rngIndex).Substring(currentWord.Length, 1);
            }

            return string.Empty;

        }

    }
}