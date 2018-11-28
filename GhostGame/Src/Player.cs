
using System;
using System.Collections.Generic;
using System.Linq;

namespace GhostGame.Src
{
    public class Player : IPlayer
    {
        IFailDecorator score;
        Random rnd = new Random();
        string answer;

        public Player(IFailDecorator currentScore)
        {
            score = currentScore;
        }

        public int GetCurrentScore()
        {
            return score.GetNumberOfErrors();
        }
        public void Fail()
        {
            score = new Error(score);
        }

        public string GetAnswer()
        {
            return answer;
        }
        public void EvaluateAnswer(List<string> wordList, string currentWord)
        {
            //retrieve list of possible answers
            var longestWord = wordList.FindAll(x => x.StartsWith(currentWord))
                .OrderBy(x => x.Length).Last();

            //filter by the max amount of letters
            var list = wordList.FindAll(x => x.Length == longestWord.Length);
            //answer = wordList()
            if (list.Count > 1)
                answer = list[rnd.Next(0, list.Count())].Substring(currentWord.Length, 1);
            else
                answer = list.First().Substring(currentWord.Length, 1);
        }
            
    }
}