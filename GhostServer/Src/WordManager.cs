using System;
namespace GhostGame.Src
{
    public class WordManager
    {
        string[] words;
        Random rnd = new Random();
        IRuleset rule;
        public WordManager(string[] words, IRuleset rule)
        {
            this.words = words;
            this.rule = rule;
        }

        public string GetStartingWord()
        {
            var result = string.Empty;
            int index = rnd.Next(0, words.Length - 1);
            result = words[index];
            result = result.Substring(0, rule.GetStartingNumberOfLetters());
            return result;
        }

        public bool CheckValidWord(string candidate)
        {
            return false;
        }
    }
}