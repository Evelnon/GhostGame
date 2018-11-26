﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GhostGame.Src
{
    public class WordManager
    {       
        List<string> words;
        Random rnd = new Random();
        IRuleset rule;
        string currentWord;
        public string GetCurrentWord => currentWord;
        public WordManager(IReader words, IRuleset rule)
        {            
            this.words =  new List<string>(words.GetWordList());
            this.rule = rule;
        }

        public string GetStartingWord()
        {
            var result = string.Empty;
            int index = rnd.Next(0, words.Count - 1);
            result = words[index];
            result = result.Substring(0, rule.GetStartingNumberOfLetters());
            return result;
        }

        public bool CheckValidWord(string candidate)
        {
            var potentialWord = currentWord + candidate;

            if (words.Any(x => x == potentialWord) || 
                words.FindAll(x => x.StartsWith(potentialWord)).Count == 0)
                return false;

            currentWord = potentialWord;
            return true;
        }

        public List<string> GetPotentialListOfWords()
        {
           return words.FindAll(x => x.StartsWith(currentWord));
        }
    }
}