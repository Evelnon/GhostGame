using System.Collections.Generic;

namespace GhostGame.Src
{
    public interface ITurn
    {
        int GetCurrentScore();
        void Fail();
        void EvaluateAnswer(List<string> list, string currentWord);
        string GetAnswer();
    }
}