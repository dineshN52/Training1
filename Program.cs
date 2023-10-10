// ---------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------
// Program.cs
// Voting character with maximum count
// Ask the user to give a atring with multiple character,each count of charcter is considered as vote for charcter
// Find the character with maximum vote and earliest to get the maximum vote (Cahrcters are case-insensitive)
// For example, The given string is AabBcCab, A or a has count of 3, B or b has count of 3, C or c has count of 2
// Both A and B has mximum count of 3 but in sequential manner A or a attain it earlier, so A or a is winner
// ---------------------------------------------------------------------------------------------------------------
namespace Voting {
   #region class Program---------------------------
   /// <summary>Voting character with maximum count</summary>
   internal class Program {
      #region Methods----------------------------------------------
      /// <summary>Method gets the input from the user and find the maximum count of characters</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the input string:");
         string s = Console.ReadLine ().ToLower ();
         List<char> Dist = s.Distinct ().ToList ();
         List<int> counts = new (Dist.Count);
         for (int i = 0; i < Dist.Count; i++) {
            counts.Add (0);
            for (int j = 0; j < s.Length; j++) {
               if (s[j] == Dist[i])
                  counts[i] = counts[i] + 1;
            }
         }
         int max = counts.Max ();
         Vote (s, max);
      }
      /// <summary>Method compares count of each charcter with maximum and find the charcter which attain it first</summary>
      /// <param name="s">Input string</param>
      /// <param name="max">Maximu value of charcacter count array</param>
      static void Vote (string s, int max) {
         Dictionary<char, int> charCounts = new ();
         for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (!charCounts.ContainsKey (c))
               charCounts[c] = 0;
            charCounts[c]++;
            if (charCounts[c] == max) {
               Console.WriteLine ($"The character {c} or {c.ToString ().ToUpper ()} win\nwith the maximum count of {max} early than other characters");
               Console.ReadKey ();
               break;
            }
         }
      }
      #endregion
   }
   #endregion
}
