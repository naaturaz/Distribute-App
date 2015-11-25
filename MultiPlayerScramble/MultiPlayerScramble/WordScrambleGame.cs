/**
 *  File Name: WordScrambleGame.cs
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
    /// <summary>
    /// WordScrambleGame class
    /// </summary>
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

        // Returns true if the game is already being hosted or false otherwise 
        [OperationBehavior]
        public bool isGameBeingHosted()
        {
            return userHostingTheGame != null;
        }

        // User ‘userName’ tries to host the game with word ‘wordToScramble’
        // The function returns the scrambled word 
        [OperationBehavior]
        public string hostGame(String playerName, string hostAddress, String wordToScramble)
        {
            //if the userHostingTheGame is not null and is not empty then a Fault can be thrown
            if (userHostingTheGame != null && userHostingTheGame != "")
            {
                throw new FaultException<GameBeingHostedFault>(new GameBeingHostedFault());
            }

            userHostingTheGame = playerName;
            gameWords = new Word();
            gameWords.unscrambledWord = wordToScramble;
            gameWords.scrambledWord = scrambleWord(wordToScramble);

            return gameWords.scrambledWord;
        }

        // Player ‘playerName’ tries to join the game
        // The function returns a Word object containing the host’s (un)scrambled words
        [OperationBehavior]
        public Word join(string playerName)
        {
            //if game is not being hosted then a Fault can be thrown
            if (!isGameBeingHosted())
            {
                throw new FaultException<GameIsNotBeingHostedFault>(new GameIsNotBeingHostedFault());
            }
            //if host is trying to join a game then a Fault can be thrown
            if (playerName == userHostingTheGame)
            {
                throw new FaultException<HostCantJoinGameFault>(new HostCantJoinGameFault());
            }

            if (activePlayers.Count + 1 < MAX_PLAYERS)
            {
                activePlayers.Add(playerName);
            }
            //If have more than 5 players, then a Fault can be thrown
            else
            {
                throw new FaultException<MaxPlayersReachedFault>(new MaxPlayersReachedFault());
            }

            return gameWords;
        }

        // Player ‘playerName’ guesses word ‘guessedWord’ compared with word ‘unscrambledWord’
        // Returns true if ‘guessedWord’ is identical to ‘unscrambledWord’ or false otherwise
        [OperationBehavior]
        public bool guessWord(string playerName, string guessedWord, string unscrambledWord)
        {
            var isActive = isPlayerActive(playerName);

            //If the player is not active then a Fault can be thrown
            if (!isActive)
            {
                throw new FaultException<PlayerNotPlayingTheGameFault>(new PlayerNotPlayingTheGameFault());
            }

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

        /// <summary>
        /// Utily function that will return true if param 'aPlayer' is on the activePlayers list
        /// </summary>
        /// <param name="aPlayer"></param>
        /// <returns></returns>
        bool isPlayerActive(string aPlayer)
        {
            for (int i = 0; i < activePlayers.Count; i++)
            {
                if (activePlayers[i] == aPlayer)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
