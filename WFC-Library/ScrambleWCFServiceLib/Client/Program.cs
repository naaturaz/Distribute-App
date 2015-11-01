using System;
using ScrambleWCFServiceLib;

namespace Client
{
    class Program
    {
        /// <summary>
        /// Main Call of Console App
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            ScrambleCall();
        }

        /// <summary>
        /// Scramble Call Method 
        /// </summary>
        static void ScrambleCall()
        {
            ScrambleService.ScrambleClient proxy = new ScrambleService.ScrambleClient();
            Word scrambledWord = proxy.ScrambledWord();

            Console.WriteLine("Can you unscramble this word?");
            Console.WriteLine("=> " + scrambledWord.scrambledWord);
            string guessedWord = Console.ReadLine();

            if (proxy.WasCorrect(guessedWord, scrambledWord.unscrambledWord))
            {
                Console.WriteLine("Wow, You Won! ;-)");
            }
            else
            {
                Console.WriteLine("Sorry, You Loose :-(");
            }
            Console.ReadKey();

            //ASK ASK
            //Will call this method again so it can keep playing the game 
            ScrambleCall();
        }
    }
}
