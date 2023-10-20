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
   #region class Program-----------------------
   /// <summary>Voting character with maximum count</summary>
   internal class Program {
      #region Methods-----------------------
      /// <summary>Method to find character with maximum repetition earlier than other characters</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the input string: ");
         while (true) {
            string s = Console.ReadLine ().ToLower ();
            if (IsValidInput (s)) {
               List<char> Dist = s.Distinct ().ToList ();
               List<(char Character, int Count)> charCounts = new ();
               foreach (char c in Dist) {
                  int count = s.Count (ch => ch == c);
                  charCounts.Add ((c, count));
               }
               Vote (charCounts);
               break;
            } else
               Console.WriteLine ("Invalid input. Enter only alpahabetical character as input");
         }
         Console.ReadKey ();
      }

      /// <summary>Method checks input only has alphabetical character</summary>
      /// <param name="input">Input string</param>
      /// <returns>Return true if all characters are alphabets,false if any is non-alphabetical character</returns>
      static bool IsValidInput (string input) {
         foreach (char c in input) {
            if (!(char.IsLetter (c)))
               return false; // If any character is not a letter, the input is invalid.
         }
         return true;
      }

      /// <summary>Method to find earliest charcter to attain maximum count</summary>
      /// <param name="charCounts">List of tuple which hold characters along with their count</param>
      static void Vote (List<(char Character, int Count)> charCounts) {
         var (Character, Count) = charCounts.MaxBy (t => t.Count);
         Console.WriteLine ($"Winner character is {Character.ToString ().ToUpper ()} or " +
             Character.ToString ().ToLower () + " with count: " + Count);
      }
      #endregion
   }
   #endregion
}
