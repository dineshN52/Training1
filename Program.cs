// ---------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Longest abecedarian word
// For given list of words,Find the longest abecedarian word and returns it
// For Example, in word "Aegilops",Letters are arranged in alphabetical order so, it is abecedarian
// The word "Aim" is also arranged in alphabetical order but it is smaller in length,so it returns "Aegilops" as longest abecedarian
// ---------------------------------------------------------------------------------------------------------------------------------
using System;
namespace Abecedarian {
   #region Program-------------------------------------
   /// <summary>Longest abecedarian word</summary>
   class Program {
      #region Methods------------------------------------------
      /// <summary>Method to check whether input has any abecedarian word, if it has returns the longest word</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         string[] words = { "Aegilops", "Aim", "Bill", "Lilly", };
         string result = LongAbecedarian (words);
         Console.WriteLine (string.IsNullOrEmpty (result) ? "No abecedarian word found." :
            $"The longest abecedarian word is: {result}");
         Console.ReadKey ();
      }

      /// <summary>Method to find whether a word has letters arranged in alphabetical order</summary>
      /// <param name="word">Input words</param>
      /// <returns>It returns true if word is abecedarian,false if it not abecedarian</returns>
      static bool IsAbecedarian (string word) {
         word = word.ToLower ();
         for (int i = 1; i < word.Length; i++) {
            if (word[i] < word[i - 1])
               return false;
         }
         return true;
      }

      /// <summary>Method to check the longest of all abecedarian words</summary>
      /// <param name="words">Input words</param>
      /// <returns>Returns the longest abecedarain word</returns>
      static string LongAbecedarian (string[] words) {
         string longword = "";
         foreach (string word in words) {
            if (IsAbecedarian (word)) {
               if (word.Length > longword.Length)
                  longword = word;
            }
         }
         return longword;
      }
      #endregion 
   }
   #endregion 
}
