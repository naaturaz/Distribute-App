/**
 *  File Name: Program.cs
 *  Class the hold the thick client 
 *
 *  Revision History:
 *      23-Nov-2015: Wrote code
 *      24-Nov-2015: Fixed standards
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.GameService;
using MultiPlayerScramble;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gave();

            Join();

            Console.ReadLine();

        }

        private static void Join()
        {
            try
            {
                Word gameWords = proxy.join("lala");
            }
            catch (FaultException fault)
            {
                Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Reason);
            }
            proxy.Close();
        }

        static void Testing()
        {
            GameService.WordScrambleGameClient prox = new GameService.WordScrambleGameClient();

            Console.WriteLine(prox.hostGame("", "", ""));
            Console.ReadLine();
        }

        static WordScrambleGameClient proxy = new WordScrambleGameClient();

        static void Gave()
        {
            WordScrambleGameClient proxy = new WordScrambleGameClient();

            bool canPlayGame = true;

            Console.WriteLine("Player's name?");
            String playerName = Console.ReadLine();

            if (!proxy.isGameBeingHosted())
            {
                Console.WriteLine("Welcome " + playerName +
                           "! Do you want to host the game?");
                if (Console.ReadLine().CompareTo("yes") == 0)
                {
                    Console.WriteLine("Type the word to scramble.");
                    string inputWord = Console.ReadLine();
                    string scrambledWord = proxy.hostGame(playerName, "", inputWord);
                    canPlayGame = false;
                    Console.WriteLine("You're hosting the game with word '" + inputWord + "' scrambled as '" + scrambledWord + "'");
                    Console.ReadKey();
                }
            }
            if (canPlayGame)
            {
                Console.WriteLine("Do you want to play the game?");
                if (Console.ReadLine().CompareTo("yes") == 0)
                {
                    Word gameWords = proxy.join(playerName);
                    Console.WriteLine("Can you unscramble this word? => " + gameWords.scrambledWord);
                    String guessedWord;
                    bool gameOver = false;
                    while (!gameOver)
                    {
                        guessedWord = Console.ReadLine();
                        gameOver = proxy.guessWord(playerName, guessedWord, gameWords.unscrambledWord);
                        if (!gameOver)
                        {
                            Console.WriteLine("Nope, try again...");
                        }
                    }
                    Console.WriteLine("You WON!!!");
                }
            }

            //Gave();
        }
    }
}
