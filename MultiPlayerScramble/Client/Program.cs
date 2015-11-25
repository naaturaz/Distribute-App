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

//IIS http://localhost/MultiPlayerScramble.WordScrambleGame.svc/mex

namespace Client
{
    /// <summary>
    /// Client main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Input();
            Console.ReadLine();
        }

        /// <summary>
        /// Input Method 
        /// </summary>
        static void Input()
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

                    try
                    {
                        string scrambledWord = proxy.hostGame(playerName, "", inputWord);
                        canPlayGame = false;

                        Console.WriteLine("You're hosting the game with word '" + inputWord + "' scrambled as '" + scrambledWord + "'");
                        Console.ReadKey();
                    }
                    catch (FaultException<GameBeingHostedFault> fault)
                    {
                        Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Detail.Reason);
                        return;
                    }
                }
            }
            if (canPlayGame)
            {
                Console.WriteLine("Do you want to play the game?");
                if (Console.ReadLine().CompareTo("yes") == 0)
                {
                    Word gameWords;

                    try
                    {
                        gameWords = proxy.join(playerName);
                    }
                    catch (FaultException<MaxPlayersReachedFault> fault)
                    {
                        Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Detail.Reason);
                        return;
                    }
                    catch (FaultException<HostCantJoinGameFault> fault)
                    {
                        Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Detail.Reason);
                        return;
                    }
                    catch (FaultException<GameIsNotBeingHostedFault> fault)
                    {
                        Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Detail.Reason);
                        return;
                    }

                    Console.WriteLine("Can you unscramble this word? => " + gameWords.scrambledWord);
                    String guessedWord;
                    bool gameOver = false;
                    while (!gameOver)
                    {
                        guessedWord = Console.ReadLine();

                        try
                        {
                            gameOver = proxy.guessWord(playerName, guessedWord, gameWords.unscrambledWord);
                        }
                        catch (FaultException<PlayerNotPlayingTheGameFault> fault)
                        {
                            Console.WriteLine("{0}:{1}", fault.Code.Name, fault.Detail.Reason);
                            return;
                        }

                        if (!gameOver)
                        {
                            Console.WriteLine("Nope, try again...");
                        }
                    }
                    Console.WriteLine("You WON!!!");
                }
            }
        }
    }
}
