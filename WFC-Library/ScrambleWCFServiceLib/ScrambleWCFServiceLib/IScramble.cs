/**
 *  File Name: IScramble.cs
 *  Interface of the Scramble Service
 *
 *  Revision History:
 *      4-Nov-2015: Wrote code
 *      5-Nov-2015: Fixed standards
 */

using System.ServiceModel;

namespace ScrambleWCFServiceLib
{
    /// <summary>
    /// IScramble Interface 
    /// </summary>
    [ServiceContract]
    public interface IScramble
    {
        [OperationContract]
        Word ScrambledWord();      
        
        [OperationContract]
        bool WasCorrect(string scrambledVal, string userAnswer);
    }
}
