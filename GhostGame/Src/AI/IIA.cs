using System.Collections.Generic;

namespace GhostGame.Src.AI
{
    public interface IIA
    {
        string EvaluateAnswer(List<string> wordList, string currentWord);
    }
}
