/**
 *  File Name: IWordScrambleGame.cs
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
    /// <summary>
    /// IWordScrambleGame interface
    /// </summary>
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

    /// <summary>
    /// Word class data contract 
    /// </summary>
	[DataContract]
	public class Word
	{
		[DataMember]
		public string unscrambledWord; // word typed by the game’s host
		[DataMember]
		public string scrambledWord;
	}

    /// <summary>
    /// Max Players Reached Fault
    /// Raised if a 6th player tries to join the game 
    /// </summary>
    [DataContract]
    public class MaxPlayersReachedFault
    {
        [DataMember]
        public string Reason = "Maximum players reached";
    }

    /// <summary>
    /// Host cant join game fault
    /// The host of a game cannot play the game
    /// </summary>
    [DataContract]
    public class HostCantJoinGameFault
    {
        [DataMember]
        public string Reason = "Host can't join the game";
    }

    /// <summary>
    /// Game is not being hosted fault
    /// Raised if a player tries to join a game and no game was hosted before that 
    /// </summary>
    [DataContract]
    public class GameIsNotBeingHostedFault
    {
        [DataMember]
        public string Reason = "Game is not being hosted";
    }

    /// <summary>
    /// Game being hosted fault 
    /// Will be raised if two players are trying to host a game at the same time
    /// </summary>
    [DataContract]
    public class GameBeingHostedFault  
    {
        [DataMember]
        public string Reason = "Game is being hosted already";
    }

    /// <summary>
    /// Player not playing the game fault 
    /// Will be raised if service went down, then service gets restarted and player keeps playing
    /// </summary>
    [DataContract]
    public class PlayerNotPlayingTheGameFault
    {
        [DataMember]
        public string Reason = "Player not playing the game";
    }
}
