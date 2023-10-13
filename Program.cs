// ---------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Longest Abecederian word
// For given list of words,Find the longest abecedrian word and returns it
// For Example,in word "Aegilops",Letters are arranged in alphabetical order so, it is abecederaian
// The word Aim is also arranged in alphabetical order but it is smaller in length,so it returns Aegilops as LongestAbecederian
// ----------------------------------------------------------------------------------------------------------------------------
using System;
namespace Abcederain {
   #region Program-------------------------------------
   /// <summary>Longest abecederian word</summary>
   class Program {
      #region Methods------------------------------------------
      /// <summary>Method to check whether input has any abecederian word, if it has returns the longest word</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         string[] words = { "Aegilops", "Aim", "Bill", "Lilly", };
         string longAbecedarian = FindLongestAbecedarian (words);
         Console.WriteLine (string.IsNullOrEmpty (longAbecedarian) ? "No abecedarian word found." :
            $"The longest abecedarian word is: {longAbecedarian}");
         Console.ReadKey ();
      }
      /// <summary>Method to find whether a word has letters arranged in alphabetical order</summary>
      /// <param name="word">Input words</param>
      /// <returns>It returns true if word is abecederian,false if it not abecederian</returns>
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
         string longabecedarian = "";
         foreach (string word in words) {
            if (IsAbecedarian (word)) {
               if (word.Length > longabecedarian.Length)
                  longabecedarian = word;
            }
         }
         return longabecedarian;
      }
      #endregion 
   }
   #endregion 
}
