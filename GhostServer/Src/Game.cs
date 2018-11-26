

namespace GhostGame.Src
{
    public class Game
    {
        private static IReader WordsSource;
        private static IRuleset ruleSet;
        private static ITurn turn;
        private static string currentWord;

        public Game()
        {
            var human = new Player();
            var cpu = new Player();
            ruleSet = new Ghost();
            WordsSource = new FileReader();

            turn = human;
            currentWord = WordsSource.GetWordList().;
        }
       
    }
}