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
        [FaultContract(typeof(GameBeingHostedFault))]
		[OperationContract]
		//string hostGame(String userName, String wordToScramble);
        string hostGame(String playerName, string hostAddress, String wordToScramble);

		// Player ‘playerName’ tries to join the game
		// The function returns a Word object containing the host’s (un)scrambled words
		// Exception: maximum number of players reached
        [FaultContract(typeof(MaxPlayersReachedFault))]
		// Exception: host cannot join the game
        [FaultContract(typeof(HostCantJoinGameFault))]
		// Exception: nobody is hosting the game
        [FaultContract(typeof(GameIsNotBeingHostedFault))]
		[OperationContract]
		Word join(string playerName);

		// Player ‘playerName’ guesses word ‘guessedWord’ compared with word ‘unscrambledWord’
		// Returns true if ‘guessedWord’ is identical to ‘unscrambledWord’ or false otherwise
		// The function returns the name of the person hosting the game 
		// Exception: user is not playing the game 
        [FaultContract(typeof(PlayerNotPlayingTheGameFault))]
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


    [DataContract]
    public class MaxPlayersReachedFault
    {
        [DataMember]
        public string Reason = "Maximum players reached";
    }

    [DataContract]
    public class HostCantJoinGameFault
    {
        [DataMember]
        public string Reason = "Host can't join the game";
    }

    [DataContract]
    public class GameIsNotBeingHostedFault
    {
        [DataMember]
        public string Reason = "Game is not being hosted";
    }

    [DataContract]
    public class GameBeingHostedFault  
    {
        [DataMember]
        public string Reason = "Game is being hosted already";
    }

    [DataContract]
    public class PlayerNotPlayingTheGameFault
    {
        [DataMember]
        public string Reason = "Player not playing the game";
    }
}
