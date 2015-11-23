/**
 *  File Name: Program.cs
 *  Class the hold the thick client 
 *
 *  Revision History:
 *      4-Nov-2015: Wrote code
 *      5-Nov-2015: Fixed standards
 */

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

            ScrambleCall();
        }
    }
}
