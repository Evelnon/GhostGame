

using GhostGame.Src.Rulesets;
using GhostGame.Src.Scoring;
using GhostGame.Src.Sources;
using GhostGame.Src.WordManagement;
using GhostGame.Src.AI;
using System;
using System.IO;

namespace GhostGame.Src
{
    public static class Game
    {

        /* Me he permitido ciertas licencias a la hora de desarrollar el juego
         * He implementado una serie de interfaces para proponer una extensibilidad del juego
         * la Interfaz IReader permite usar distintas fuentes para el listado de palabras
         * la interfaz IRuleset permite implementar las reglas del juego Ghost y la del Super Ghost como 
         * he leido en la Wikipedia en el enlace dado. Habria que hacer pequeñas modificaciones visuales en 
         * la parte cliente y en la parte de la composicion de palabras y se podria jugar con ambas
         * Una interfaz IPlayer con los metodos para jugadores tanto humanos como cpu 
         * con un patron decorador usado para el conteo de errores que contiene un interfaz y una clase abstracta
         * En la seccion de reporte de excepciones, he creado la clase File empty para capturar excepciones por ficheros vacios
         * y no retornar errores genericos
         * La interfaz IIA se encarga del modo que la cpu busca palabras, he implementado una random para jugar palabras random
         * como pide en los requerimientos y otra que busca la palabra mas larga directamente y la propone en el juego 
         * incrementando la dificultad considerablemente

         * La parte cliente la he implementado ocn Angularjs v1.7 y bootstrap, tratando de ser una capa de presentacion lo mas transparente posible
         * no implementando apenas logica en ella en los componentes usados y comunicandose con servicio web monolitico
         * 
         * Para los test unitarios he utilizado Nunit y MoQ para poder mockear por ejemplo la lista de palabras que devuelve la interfaz
         * IReader*/

        static IReader WordsSource;
        static IRuleset ruleSet;
        static IPlayer turn;
        static WordManager wordManager;
        public static Player human;
        public static Player cpu;     

        public static void NewGame()
        {
            try
            {
                ruleSet = new Ghost();
                WordsSource = new FileReader();
                wordManager = new WordManager(WordsSource, ruleSet);
                human = new Player(new Score());
                cpu = new Player(new Score(), new RandomAI());
                turn = human;
                wordManager.SetStartingWord();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
           
        }

        public static bool NewRound()
        {
            if (turn.GetCurrentScore() < 5)
            {
                turn = human;
                return false;
            }
            else
                return true; //Game Over


        }

        public static bool PlayerInput(string letter)
        {
            var gameFinished = true;
            if (wordManager.CheckValidWord(letter) == false)
            {
                turn.Fail();
                wordManager.SetStartingWord();
                gameFinished = NewRound();
                return gameFinished;
            }

            turn = cpu;
            CpuInput(turn, wordManager);
            gameFinished = NewRound();
            
            turn = human;
            return gameFinished;
        }

        public static string GetCurrentWord()
        {
            return wordManager.GetCurrentWord;
        }

        public static void CpuInput(IPlayer turn, WordManager wordManager)
        {
            turn.EvaluateAnswer(wordManager.GetPotentialListOfWords(), wordManager.GetCurrentWord);
            if (wordManager.CheckValidWord(turn.GetAnswer()) == false)
            {
                turn.Fail();
                wordManager.SetStartingWord();
            };
            
        }

    }
}