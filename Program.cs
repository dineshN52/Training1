// ------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Sort and swap special character
// Ask the user to give a array of alphabetic characters, a special character and order of arrangement(ascending or descending)
// For example, given array is a b c a c b d, special character is 'a' and order is descending output will be "dccbba"
// For example, if given array is y z x, special character is 'a',output is x y z
// In the above example special charcter is not present in given array, so it orders the given array in ascending by default without swapping
// ------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace SortArray {
   #region Class Program-----------------------
   /// <summary>Sort and swap special character</summary>
   internal class Program {
      #region Methods--------------------------------------
      /// <summary>Method gets input from user like character array, special character to be swapped and order of sequence</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter an array of alphabets, alphabetical character to be swapped, sort order with a space between all."
             + "\nMention sort order, only if descending, as '1' or keep empty if ascending(default case)");
         while (true) {
            Console.Write ("Input: ");
            var input = Console.ReadLine ()?.ToLower ().Split (' ');
            if (input != null && IsValid (input)) {
               SwapandSort (input);
               break;
            } else
               Console.WriteLine ("Invalid input. Enter input by following above criteria");
         }
      }

      /// <summary>Method to check whether input string only contains alphabets</summary>
      /// <param name="s">Input string array</param>
      /// <returns>Returns the boolean value based on given input is valid or not, as true(valid) or false(invalid)</returns>
      static bool IsValid (string[] s) {
         var reg = new Regex (@"^[a-zA-Z]+$");
         if (s.Length >= 2 && reg.IsMatch (s[0]) && reg.IsMatch (s[1]) && s[1].Length == 1) {
            if (s.Length == 2 || (s.Length == 3 && s[2] == "1"))
               return true;
         }
         return false;
      }

      /// <summary>Method which helps in swapping the special character in the list and sort it based on input order</summary>
      /// <param name="specialchar">Special character to be swapped</param>
      /// <param name="b">Input array of characters</param>
      /// <param name="count">count of repetition of special character</param>
      /// <param name="sortorder">Sorting order as ascending or descending</param>
      static void SwapandSort (string[] input) {
         char[] chars = input[0].ToCharArray ();
         char specialchar = char.Parse (input[1]);
         int count = 0, arrLength = chars.Length;
         bool sortOrder = input.Length == 3;
         for (int i = 0; i < arrLength; i++) {
            if (chars[i] == specialchar) {
               SwapHelp (ref chars[i], ref chars[arrLength - 1]);
               count++; arrLength--;
            }
         }
         chars = (sortOrder ? chars.SkipLast (count).OrderByDescending (a => a).ToArray () :
                  chars.SkipLast (count).OrderBy (a => a).ToArray ());
         string s = new (chars);
         s = s.PadRight (count + s.Length, specialchar);
         Console.Write ($"Swapped and sorted string: {s}");
      }

      /// <summary>Method helps in swapping of characters</summary>
      /// <param name="a">Input character1</param>
      /// <param name="b">Input character2</param>
      static void SwapHelp (ref char a, ref char b) => (b, a) = (a, b);
      #endregion
   }
   #endregion
}