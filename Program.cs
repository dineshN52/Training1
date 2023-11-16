// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Seed characters for spelling bee game
// Read the input dictionary of words from the location of file,convert to single string with all words
// Findcharfrequency method find the repetition of each alphabet in the whole string and create a dictionary 
// Dictionary will hold each alpahabetical character with the respective count as key, value pair in it
// Dictionary is sorted with respect to value in descending order and first seven characters are displayed as the seed characters for spelling bee game
// ----------------------------------------------------------------------------------------------------------------------------------------------------
using System.Data;
using System.Linq;
namespace Spellingbee {
   #region Program class------------------------------
   /// <summary>Seed characters for spelling bee game</summary>
   internal class Program {
      #region Methods-------------------------------
      /// <summary>Method which read the dictionary of words,converts to single string and passes to Findcharfrequency method</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         var seed = Findcharfrequency ().OrderByDescending (x => x.Value).ToDictionary (x => x.Key, x => x.Value).Take (7);
         Console.WriteLine ("Below were the list of first seven characters with higher appearances in the dictionary" +
             "\nThis letters can be used as seed for spelling bee game");
         Console.WriteLine ($"\n{String.Join ("\n", seed.Select (res => res.Key + "-" + res.Value))}");
      }

      /// <summary>Method gets the input string and find frequency of each alphabetical character and creates a dictionary with character and count</summary>
      /// <param name="lines"></param>
      /// <returns>Returns dictionary of each character with their repetition count in words dictionary</returns>
      static Dictionary<char, int> Findcharfrequency () {
         var lines = File.ReadAllLines ("C:\\dinesh.n\\words.txt");
         Dictionary<char, int> table = Enumerable.Range ('A', 26).ToDictionary (c => (char)c, c => 0);
         foreach (var c in from words in lines from char c in words where table.ContainsKey (c) select c)
            table[c] += 1;
         return table;
      }
      #endregion
   }
   #endregion
}