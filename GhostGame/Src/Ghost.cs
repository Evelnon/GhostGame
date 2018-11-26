

namespace GhostGame.Src
{
    public class Ghost : IRuleset
    {
        public int GetStartingNumberOfLetters()
        {
            return 3;
        }

        public bool SetLettersInBothSides()
        {
            return false;
        }
    }
}