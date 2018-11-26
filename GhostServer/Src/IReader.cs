

namespace GhostGame.Src
{
    public interface IReader
    {
        void ReadFile();

        int NumberOfAvailableWords();

        string[] GetWordList();
    }
}