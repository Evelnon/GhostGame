
namespace GhostGame.Src
{
    public abstract class EntityScoring : IFailDecorator
    {
        //private int numberOfFails = 0;
        private IFailDecorator fail;
        

        protected EntityScoring(IFailDecorator fail)
        {
            this.fail = fail;
        }

        public int GetNumberOfErrors()
        {
            return fail.GetNumberOfErrors() + 1;
        }
    }
}