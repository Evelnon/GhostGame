

namespace GhostGame.Src
{
    public class Game
    {
        private static IReader WordsSource;
        private static IRuleset ruleSet;
        private static ITurn turn;       
        private static WordManager wordManager;
        Player human = new Player();
        Player cpu = new Player();

        public Game()
        {
            
            ruleSet = new Ghost();
            WordsSource = new FileReader();
            wordManager = new WordManager(WordsSource, ruleSet);
            wordManager.GetStartingWord();
            turn = human;
            
        }
       
        public void PlayerInput(string letter)
        {
            if (wordManager.CheckValidWord(letter) == false)
            {
                turn.Fail();
                
            }
            else
            {
                CpuInput();
                
            }

            if (turn.GetCurrentScore() == 5)
            {
                //Game Over
            }
            else
            {
                turn = human;
            }
        }

        public void CpuInput()
        {
            turn = cpu;
            turn.EvaluateAnswer(wordManager.GetPotentialListOfWords(), wordManager.GetCurrentWord);
            wordManager.CheckValidWord(turn.GetAnswer());
        }
        
    }
}