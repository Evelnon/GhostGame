using System.Collections.Generic;

namespace GhostGame.Src.Scoring
{
    public interface IPlayer
    {
        int GetCurrentScore();
        void Fail();
        void EvaluateAnswer(List<string> list, string currentWord);
        string GetAnswer();
    }
}