
namespace GhostGame.Src
{
    public class Player : ITurn
    {
        IFailDecorator score;
        public void Fail()
        {
            score = new Error(score);
        }

        protected int GetCurrentScore()
        {
            return score.GetNumberOfErrors();
        }
    }
}