
using System;
using System.Collections.Generic;

namespace GhostGame.Src
{
    public class Player : ITurn
    {
        IFailDecorator score;
        Random rnd = new Random();
        string answer;

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
            //answer = wordList()
        }
            
    }
}