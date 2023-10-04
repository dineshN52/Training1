// ---------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Longest Abcederian word
// For given list of words,Find the longest abcedrian word and returns it
// For Example,in word "Aegilops",Letters are arranged in alphabetical order so, it is abcederaian
// The word Aim is also arranged in alphabetical order but it is smaller in length,so it returns Aegilops as LongestAbcederian
// ---------------------------------------------------------------------------------------------------------------------------
using System;
using System.Text.RegularExpressions;
namespace Abcederain {
   #region Program-------------------------------------
   /// <summary>Longest abcederian word</summary>
   class Program {
      #region Methods------------------------------------------
      /// <summary>Method to check whether input has any abcederian word, if it has returns the longest word</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         string[] words = { "Aegilops", "Aim", "3Bill", "Lilly", };
         string longestAbecedarianWord = FindLongestAbecedarian (words);
         Console.WriteLine (string.IsNullOrEmpty (longestAbecedarianWord) ? "No abecedarian word found." : 
            $"The longest abecedarian word is: {longestAbecedarianWord}");
         Console.ReadKey ();
      }
      /// <summary>Method to check whether it has only alphabetical characters using regular expression</summary>
      /// <param name="input">Input words</param>
      /// <returns>It returns true if it has only alphabets,false if it has numbers or special characters</returns>
      static bool IsValidInput (string input) {
         string pattern = "^[a-zA-Z]";
         return Regex.IsMatch (input, pattern);
      }
      /// <summary>Method to find whether a word has letters arranged in alphabetical order</summary>
      /// <param name="word">Input words</param>
      /// <returns>It returns true if word is abcederian,false if it not abcederian</returns>
      static bool IsAbecedarian (string word) {
         word = word.ToLower ();
         for (int i = 1; i < word.Length; i++) {
            if (word[i] < word[i - 1])
               return false;
         }
         return true;
      }
      /// <summary>Method to check the longest of all abcederian words</summary>
      /// <param name="words">Input words</param>
      /// <returns>Returns the longest Abcederain word</returns>
      static string FindLongestAbecedarian (string[] words) {
         string longestAbecedarianWord = "";
         foreach (string word in words) {
            if (IsValidInput (word) && IsAbecedarian (word)) {
               if (word.Length > longestAbecedarianWord.Length)
                  longestAbecedarianWord = word;
            }
         }
         return longestAbecedarianWord;
      }
      #endregion 
   }
   #endregion 
}
