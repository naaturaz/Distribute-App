/**
 *  File Name: Program.cs
 *  Class the hold the service functionalities 
 *
 *  Revision History:
 *      23-Nov-2015: Wrote code
 *      24-Nov-2015: Fixed standards
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MultiPlayerScramble
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior]
    public class WordScrambleGame : IWordScrambleGame
    {
        // the maximum number of players allowed playing simultaneously
        private const int MAX_PLAYERS = 5;
        // the user hosting the game. If it’s null nobody is hosting the game.
        private static String userHostingTheGame = null;
        // the Word object that contains the scrambled and unscrambled words
        private static Word gameWords;
        // the list of players playing the game
        private static List<String> activePlayers = new List<string>();

        [OperationBehavior]
        public bool isGameBeingHosted()
        {
            // TO BE COMPLETED BY YOU: Add exception and program logic
            return userHostingTheGame != null;
        }

        [OperationBehavior]
        public string hostGame(String playerName, string hostAddress, String wordToScramble)
        {
            if (userHostingTheGame != null && userHostingTheGame != "")
            {
                throw new FaultException<GameBeingHostedFault>(new GameBeingHostedFault());
            }

            // TO BE COMPLETED BY YOU: Add exception and program logic
            userHostingTheGame = playerName;
            gameWords = new Word();
            gameWords.unscrambledWord = wordToScramble;
            gameWords.scrambledWord = scrambleWord(wordToScramble);

            return gameWords.scrambledWord;
        }

        private Word test = null;

        [OperationBehavior]
        public Word join(string playerName)
        {
            if (!isGameBeingHosted())
            {
                throw new FaultException<GameIsNotBeingHostedFault>(new GameIsNotBeingHostedFault());
            }
            if (playerName == userHostingTheGame)
            {
                throw new FaultException<HostCantJoinGameFault>(new HostCantJoinGameFault());
            }

            // TO BE COMPLETED BY YOU: Add exception and program logic
            if (activePlayers.Count < MAX_PLAYERS)
            {
                activePlayers.Add(playerName);
            }
            //cant have more than 5 players
            else
            {
                throw new FaultException<MaxPlayersReachedFault>(new MaxPlayersReachedFault());
            }

            return gameWords;
        }

        [OperationBehavior]
        public bool guessWord(string playerName, string guessedWord, string unscrambledWord)
        {
            var play = activePlayers.Find(a=>a.Contains(playerName));

            if (play == null)
            {
                
            }

            // TO BE COMPLETED BY YOU: Add exception and program logic
            if (guessedWord == unscrambledWord)
            {
                return true;
            }

            return false;
        }

        // Utility function to scramble a word
        private string scrambleWord(string word)
        {
            char[] chars = word.ToArray();
            Random r = new Random(2011);
            for (int i = 0; i < chars.Length; i++)
            {
                int randomIndex = r.Next(0, chars.Length);
                char temp = chars[randomIndex];
                chars[randomIndex] = chars[i];
                chars[i] = temp;
            }
            return new string(chars);
        }
    }
}
