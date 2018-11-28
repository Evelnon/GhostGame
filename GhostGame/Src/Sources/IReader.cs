

namespace GhostGame.Src.Sources
{
    public interface IReader
    {
        void ReadFile();

        int NumberOfAvailableWords();

        string[] GetWordList();
    }
}