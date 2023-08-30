﻿
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace wordsquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordLength = Int32.Parse(args[0]);
            var letters = args[1];
            var allWords = GetAllWords();
            var wordsByLength = GetWordsByLength(allWords, wordLength);
            var charFreq = GetCharFreq(args[1]);
            var validWords = GetValidWords(wordsByLength, charFreq, wordLength);
            var wordSquare = GetWordSquare(validWords, wordLength, new List<string>(), charFreq);

            foreach(var word in wordSquare)
            {
                Console.WriteLine(word);
            }
        }

        public static List<string> GetAllWords()
        {
            var words = new List<string>();
            try
            {
                var sr = new StreamReader("wordsquare/enable1.txt");
                var line = sr.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return words;
        }

        public static IEnumerable<string> GetWordsByLength(List<string> allWords, int length)
        {
            return allWords.Where(w => w.Length == length);
        }

        public static Dictionary<char, int> GetCharFreq(string letters)
        {
            var charFreq = new Dictionary<char, int>();
            foreach(var c in letters)
            {
                if(charFreq.ContainsKey(c))
                {
                    charFreq[c]++;
                }
                else
                {
                    charFreq.Add(c, 1);
                }
            }
            return charFreq;
        }

        
        public static IEnumerable<string> GetValidWords(IEnumerable<string> words, Dictionary<char, int> charFreq, int length)
        {
            var validWords = new List<string>();
            foreach(var word in words)
            {
                var wordCharFreq = GetCharFreq(word);
                var valid = true;
                foreach(var c in wordCharFreq.Keys)
                {
                    if(!charFreq.ContainsKey(c) || charFreq[c] < wordCharFreq[c])
                    {
                        valid = false;
                        break;
                    }
                }
                if(valid)
                {
                    validWords.Add(word);
                }
            }
            return validWords;
        }

        public static List<string> GetWordSquare(IEnumerable<string> validWords, int length, List<string> wordSquare,  Dictionary<char, int> charFreq)
        {
            if (wordSquare.Count == length)
            {
                Console.WriteLine("Valid word square");
                return new List<string>(wordSquare);
            }

            var currentIndex = wordSquare.Count;
            
            var prefixBuilder = new StringBuilder();
            for (var i = 0; i < currentIndex; i++)
            {
                prefixBuilder.Append(wordSquare[i][currentIndex]);
            }
            var prefix = prefixBuilder.ToString();
            
            foreach (var validWord in validWords)
            {
                if (validWord.StartsWith(prefix))
                {
                    var newWordSquare = GetWordSquare(validWords, length, wordSquare.Concat(new[] { validWord }).ToList(), charFreq);
                    if (newWordSquare != null)
                    {
                        var newWordSquareChars = newWordSquare.SelectMany(w => w).ToList();
                        var currentCharFreq = new Dictionary<char, int>(charFreq);
                        foreach(var c in newWordSquareChars)
                        {
                            if(currentCharFreq.ContainsKey(c))
                            {
                                currentCharFreq[c]--;
                            }
                            if(currentCharFreq[c] < 0)
                            {
                                Console.WriteLine("Invalid word square");
                                return null;
                            }
                        }
                        
                        return newWordSquare;
                    }
                }
            }

            return null; 
        }

    }
}