

using System;

namespace GhostGame.Src
{
    public static class Game
    {
        static IReader WordsSource;
        static IRuleset ruleSet;
        static IPlayer turn;
        static WordManager wordManager;
        public static Player human;
        public static Player cpu;     

        public static void NewGame()
        {
            ruleSet = new Ghost();
            WordsSource = new FileReader();
            wordManager = new WordManager(WordsSource, ruleSet);
            human = new Player(new Score());
            cpu = new Player(new Score());
            turn = human;
            NewRound();
        }

        public static bool NewRound()
        {
            if (turn.GetCurrentScore() < 5)
            {
                wordManager.GetStartingWord();
                turn = human;                
            }
            else
                return false;
            return true;
                //Game Over
        }

        public static bool PlayerInput(string letter)
        {
            if (wordManager.CheckValidWord(letter) == false)
            {
                turn.Fail();
                return NewRound();
                
            }

            if (CpuInput() == false)
            {                
                return NewRound();
                
            } 
            turn = human;
            return true;
        }
        
        public static string GetCurrentWord()
        {
            return wordManager.GetCurrentWord;
        }

        public static bool CpuInput()
        {            
            turn.EvaluateAnswer(wordManager.GetPotentialListOfWords(), wordManager.GetCurrentWord);
            if (wordManager.CheckValidWord(turn.GetAnswer()) == false)
            {
                turn.Fail();
                return false;
            };
            return true;
        }

    }
}