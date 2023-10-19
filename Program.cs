// ---------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------
// Program.cs
// String permutations
// For a given word or string, it produces all permutations of the same word
// For Example, for word "NOT", it produces permutations as "NOT,NTO,ONT,OTN,TON,TNO"
// ---------------------------------------------------------------------------------
using System;
namespace StringPermutation {
   #region Program------------------------------
   /// <summary>String permutations</summary>
   class Program {
      #region Methods-------------------------
      /// <summary>Method gets input from user and pass it to permute function to produce all permutations</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string input = Console.ReadLine ();
         Console.WriteLine ("Permutations:");
         Permute (input.ToCharArray (), 0, input.Length - 1);
         Console.ReadKey ();
      }

      /// <summary>Method passes the characters in the input words to swap function to produce permutation 
      ///  It also backtrack the swaps</summary>
      /// <param name="arr">Character array of input word</param>
      /// <param name="sIndex">Start index of an array</param>
      /// <param name="eIndex">End index of an array</param>
      static void Permute (char[] arr, int sIndex, int eIndex) {
         if (sIndex == eIndex)
            Console.WriteLine (new string (arr));
         else {
            for (int i = sIndex; i <= eIndex; i++) {
               Swap (ref arr[i], ref arr[sIndex]);
               Permute (arr, sIndex + 1, eIndex);
               Swap (ref arr[i], ref arr[sIndex]);
            }
         }
      }

      /// <summary>Method swaps the charcters in the word</summary>
      /// <param name="a">First variable</param>
      /// <param name="b">Second variable</param>
      static void Swap (ref char a, ref char b) => (b, a) = (a, b); 
      #endregion 
   }
   #endregion 
}
