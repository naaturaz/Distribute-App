

using System;
using System.Linq;

namespace ScrambleWCFServiceLib
{
    /// <summary>
    /// Scramble class
    /// </summary>
    public class Scramble : IScramble
    {
        /// <summary>
        /// Returns a Scrambled word
        /// </summary>
        /// <returns></returns>
        public Word ScrambledWord()
        {
            IWordScrambleGame game = new WordScrambleGame();
            Word scrambledWord = game.getScrambledWord();
            return scrambledWord;
        }

        /// <summary>
        /// Returns true if guessedWord == unscrambledVal
        /// </summary>
        /// <param name="guessedWord">The guessed word from player</param>
        /// <param name="unscrambledVal">The correct word to be guess</param>
        /// <returns></returns>
        public bool WasCorrect(string guessedWord, string unscrambledVal)
        {
            IWordScrambleGame game = new WordScrambleGame();

            if (game.guessWord(guessedWord, unscrambledVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// IWordScrambleGame Interface
    /// </summary>
    public interface IWordScrambleGame
    {
        /**
        * Randonly selects a word, scrambles it, and retuns the original
        * (unscrambled) and the scrambed words as a single Word object
        **/
        Word getScrambledWord();

        /**
        * Returns true if the guessed word correctly matches the
        * unscrambled word or false otherwise
        **/
        bool guessWord(string guessedWord, string unscrambledWord);
    }

    /// <summary>
    /// WordScrambleGame class
    /// </summary>
    public class WordScrambleGame : IWordScrambleGame
    {
        string[] words = { "kitchener", "waterloo", "toronto", "ottawa",
				    "montreal", "calgary", "edmonton", "vancouver" };

        public Word getScrambledWord()
        {
            Random random = new Random();
            string selectedWord = words[random.Next(words.Length)];
            string scrambledWord = scrambleWord(selectedWord);
            Word wordObj = new Word();
            wordObj.unscrambledWord = selectedWord;
            wordObj.scrambledWord = scrambledWord;
            return wordObj;
        }

        public bool guessWord(string guessedWord, string unscrambledWord)
        {
            return (guessedWord.CompareTo(unscrambledWord) == 0);
        }

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

    /// <summary>
    /// Word class
    /// </summary>
    public class Word
    {
        public string unscrambledWord;
        public string scrambledWord;
    }
}
