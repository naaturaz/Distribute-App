/**
 *  File Name: Program.cs
 *  Class the hold the Interface of the service  
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
    [ServiceContract]
    public interface IWordScrambleGame
	{
		// Returns true if the game is already being hosted or false otherwise 
		[OperationContract]
		bool isGameBeingHosted();

		// User ‘userName’ tries to host the game with word ‘wordToScramble’
		// The function returns the name of the person hosting the game 
		// Exception: game is already being hosted by someone else
		[OperationContract]
		//string hostGame(String userName, String wordToScramble);
        string hostGame(String playerName, string hostAddress, String wordToScramble);

		// Player ‘playerName’ tries to join the game
		// The function returns a Word object containing the host’s (un)scrambled words
		// Exception: maximum number of players reached
		// Exception: host cannot join the game
		// Exception: nobody is hosting the game
        [FaultContract(typeof(GameIsNotBeingHostedFault))]
		[OperationContract]
		Word join(string playerName);

		// Player ‘playerName’ guesses word ‘guessedWord’ compared with word ‘unscrambledWord’
		// Returns true if ‘guessedWord’ is identical to ‘unscrambledWord’ or false otherwise
		// The function returns the name of the person hosting the game 
		// Exception: user is not playing the game 
		[OperationContract]
		bool guessWord(string playerName, string guessedWord, string unscrambledWord);
	}

	[DataContract]
	public class Word
	{
		[DataMember]
		public string unscrambledWord; // word typed by the game’s host
		[DataMember]
		public string scrambledWord;
	}
}
