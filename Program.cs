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
namespace SortArray {
   #region Class Program-----------------------
   /// <summary>Sort and swap special character</summary>
   internal class Program {
      #region Methods--------------------------------------
      /// <summary>Method gets input from user like characte array,special character to be swapped and order of sequence
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter the array values, special character, sort order" +
             "\nEnter only alpahabets as array values and special character, with a space between array,special character and sort order");
         while (true) {
            string s = Console.ReadLine ().ToLower ();
            if (IsValid (s)) {
               string[] Inputs = s.Split (' ');
               int count = 0;
               char[] values = Inputs[0].ToCharArray ();
               char S = char.Parse (Inputs[1]);
               List<char> result = Swap (S, values, ref count, Inputs.Length == 3 ? Inputs[2] : "ascending");
               PrintList (result, S, count);
               break;
            } else
               Console.WriteLine ("Enter valid input.Input should not be empty and a numerical character");
         }
      }

      /// <summary>Method to check whether input string only contains alphabets</summary>
      /// <param name="s">Input string</param>
      /// <returns>Returns the boolean value ehther given input is valid or not</returns>
      static bool IsValid (string input) {
         char[] letters = input.ToCharArray ();
         var alpha = letters.Any (char.IsLetter);
         string[] s = input.Split (' ');
         if (alpha && s.Length >= 2 && (s.Length == 2 || (s.Length == 3 &&
             (s[1].Length == 1 && (s[2] == "ascending" || s[2] == "descending")))))
            return true;
         return false;
      }

      /// <summary>Method which helps in swapping the special charcter in the list</summary>
      /// <param name="a">Special character to be swapped</param>
      /// <param name="b">Input array of characters</param>
      /// <param name="c">coubt of repetition of special character</param>
      /// <param name="d">List of characters without the special character</param>
      static List<char> Swap (char a, char[] b, ref int c, string sortOrder) {
         int j = b.Length;
         List<char> d = new ();
         for (int i = 0; i < j; i++) {
            if (b[i] == a) {
               SwapHelp (ref b[i], ref b[j - 1]);
               c++; j--;
            }
         }
         d = b.SkipLast (c).ToList ();
         if (sortOrder == "descending")
            d = d.OrderByDescending (a => a).ToList ();
         else
            d = d.OrderBy (a => a).ToList ();
         return d;
      }

      /// <summary>Method helps in swapping of characters</summary>
      /// <param name="a">Input character1</param>
      /// <param name="b">Input character2</param>
      static void SwapHelp (ref char a, ref char b) => (b, a) = (a, b);

      /// <summary>Method to add special charcter at last and print the list</summary>
      /// <param name="a">List with characters are arranged in given order</param>
      /// <param name="S">Special character</param>
      /// <param name="n">Number of repetitionsof special character</param>
      static void PrintList (List<char> a, char S, int n) {
         for (int i = 0; i < n; i++)
            a.Add (S);
         foreach (char c in a)
            Console.Write (c);
      }
      #endregion
   }
   #endregion
}