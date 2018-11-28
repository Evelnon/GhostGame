
using GhostGame.Src.AI;
using System;
using System.Collections.Generic;

namespace GhostGame.Src.Scoring
{
    public class Player : IPlayer
    {
        IFailDecorator score;
        Random rnd = new Random();
        private IIA IA;
        string answer;

        public Player(IFailDecorator currentScore)
        {
            score = currentScore;
        }
        public Player(IFailDecorator currentScore, IIA difficulty)
        {
            score = currentScore;
            IA = difficulty;
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
            answer = IA.EvaluateAnswer(wordList, currentWord);
        }
            
    }
}