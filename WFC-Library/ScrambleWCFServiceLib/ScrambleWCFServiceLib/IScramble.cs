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
