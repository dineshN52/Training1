// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Spelling bee game
// Ask the user to give a series of letters to form words, where first letter will be considered as must have character in each word
// With input series of letters it will compare the words in the given dictionary and print words can be formed by letters which has minimum of length 4
// Game also follows scoring methods:If word has all inout letters score will be 15, words with length of 4 will be 1.
// All other words will ahave score equivalent to their length
// For characters, u x a l t n e, word with maximum score is EXULTANT as it used all 7 characters in the series is printed first, similarly other words with scores also printed
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Text.RegularExpressions;
namespace Spellingbee {
   #region Program class------------------------------
   /// <summary>Spelling bee game</summary>
   internal class Program {
      #region Methods-------------------------------
      /// <summary>Method which gets the character input from the user and pass it to Checkwords method</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter series of alphabets, where first character should be present in all words");
         while (true) {
            string? input = Console.ReadLine ()?.ToUpper ();
            if (input != null && Regex.IsMatch (input, @"^[a-zA-Z]+$")) {
               char[] letters = input.ToCharArray ();
               CheckWords (letters);
               break;
            } else
               Console.WriteLine ("Invalid input. Enter only alphabets");
         }
      }

      /// <summary>Method which loads the dictionary and check words which met all the criteria of spelling bee and print along with scores</summary>
      /// <param name="letters">Input character array</param>
      static void CheckWords (char[] letters) {
         StreamReader sr = new ("C:\\dinesh.n\\words.txt");
         string? line = sr.ReadLine ();
         int score = 0, total = 0;
         List<(int, string)> finalList = new ();
         while (line != null) {
            if (line.Contains (letters[0]) && line.All (x => letters.Contains (x)) && line.Length >= 4) {
               score = line.Length > 4 ? (CheckHigherscore (line, letters) ? 15 : line.Length) : 1;
               finalList.Add ((score, line));
               total += score;
            }
            line = sr.ReadLine ();
         }
         finalList = finalList.OrderByDescending (x => x).ToList ();
         Console.WriteLine (string.Join ("\n", finalList));
         Console.WriteLine ($"{total} Total");
         sr.Close ();
      }

      /// <summary>method to check if word has all charcaters of series and allot High score</summary>
      /// <param name="input">Input word</param>
      /// <param name="validChars">Input charcater array</param>
      /// <returns>Return bool value for the condition, True if word has all character, else false</returns>
      static bool CheckHigherscore (string input, char[] validChars) {
         string d = new (input.Distinct ().ToArray ());
         if (d.Length == validChars.Length)
            return true;
         return false;
      }
      #endregion
   }
   #endregion
}