

namespace GhostGame.Src
{
    public class SuperGhost : IRuleset
    {
        public int GetStartingNumberOfLetters()
        {
            return 4;
        }

        public bool SetLettersInBothSides()
        {
            return true;
        }
    }
}