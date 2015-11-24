﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.GameService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameService.IWordScrambleGame")]
    public interface IWordScrambleGame {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/isGameBeingHosted", ReplyAction="http://tempuri.org/IWordScrambleGame/isGameBeingHostedResponse")]
        bool isGameBeingHosted();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/isGameBeingHosted", ReplyAction="http://tempuri.org/IWordScrambleGame/isGameBeingHostedResponse")]
        System.Threading.Tasks.Task<bool> isGameBeingHostedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/hostGame", ReplyAction="http://tempuri.org/IWordScrambleGame/hostGameResponse")]
        string hostGame(string playerName, string hostAddress, string wordToScramble);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/hostGame", ReplyAction="http://tempuri.org/IWordScrambleGame/hostGameResponse")]
        System.Threading.Tasks.Task<string> hostGameAsync(string playerName, string hostAddress, string wordToScramble);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/join", ReplyAction="http://tempuri.org/IWordScrambleGame/joinResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MultiPlayerScramble.GameIsNotBeingHostedFault), Action="http://tempuri.org/IWordScrambleGame/joinGameIsNotBeingHostedFaultFault", Name="GameIsNotBeingHostedFault", Namespace="http://schemas.datacontract.org/2004/07/MultiPlayerScramble")]
        MultiPlayerScramble.Word join(string playerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/join", ReplyAction="http://tempuri.org/IWordScrambleGame/joinResponse")]
        System.Threading.Tasks.Task<MultiPlayerScramble.Word> joinAsync(string playerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/guessWord", ReplyAction="http://tempuri.org/IWordScrambleGame/guessWordResponse")]
        bool guessWord(string playerName, string guessedWord, string unscrambledWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWordScrambleGame/guessWord", ReplyAction="http://tempuri.org/IWordScrambleGame/guessWordResponse")]
        System.Threading.Tasks.Task<bool> guessWordAsync(string playerName, string guessedWord, string unscrambledWord);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWordScrambleGameChannel : Client.GameService.IWordScrambleGame, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WordScrambleGameClient : System.ServiceModel.ClientBase<Client.GameService.IWordScrambleGame>, Client.GameService.IWordScrambleGame {
        
        public WordScrambleGameClient() {
        }
        
        public WordScrambleGameClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WordScrambleGameClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WordScrambleGameClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WordScrambleGameClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool isGameBeingHosted() {
            return base.Channel.isGameBeingHosted();
        }
        
        public System.Threading.Tasks.Task<bool> isGameBeingHostedAsync() {
            return base.Channel.isGameBeingHostedAsync();
        }
        
        public string hostGame(string playerName, string hostAddress, string wordToScramble) {
            return base.Channel.hostGame(playerName, hostAddress, wordToScramble);
        }
        
        public System.Threading.Tasks.Task<string> hostGameAsync(string playerName, string hostAddress, string wordToScramble) {
            return base.Channel.hostGameAsync(playerName, hostAddress, wordToScramble);
        }
        
        public MultiPlayerScramble.Word join(string playerName) {
            return base.Channel.join(playerName);
        }
        
        public System.Threading.Tasks.Task<MultiPlayerScramble.Word> joinAsync(string playerName) {
            return base.Channel.joinAsync(playerName);
        }
        
        public bool guessWord(string playerName, string guessedWord, string unscrambledWord) {
            return base.Channel.guessWord(playerName, guessedWord, unscrambledWord);
        }
        
        public System.Threading.Tasks.Task<bool> guessWordAsync(string playerName, string guessedWord, string unscrambledWord) {
            return base.Channel.guessWordAsync(playerName, guessedWord, unscrambledWord);
        }
    }
}
