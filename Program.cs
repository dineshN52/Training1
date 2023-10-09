// --------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------
// Program.cs
// Isogram checker
// Ask the user to give a word or string and output whether the string is isogram or not
// For Example,the word "Coin", None of the letters are repeated,so output is "Coin is an isogram".
// For another example,the word "Apple",letter p was repeated,so output is "Apple is not an isogram".
// --------------------------------------------------------------------------------------------------
namespace Isogram {
   #region Program-------------------------
   /// <summary>Isogram checker</summary>
   internal class Program {
      #region Method-------------------------
      /// <summary>Method gets the input from user and passes into an IsIsogram method to check it isogram or not</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         Console.WriteLine ($"{s} is {(IsIsogram (s.ToLower ()) ? "an" : "not an")} isogram");
         Console.ReadKey ();
      }
      /// <summary>This method checks for the repetition of letter in input & produce output as Isogram or not</summary>
      /// <param name="s">String from user</param>
      /// <returns>It returns boolean output of true or false for IsIsogarm function(If Isogram:True,Not Isogram:False)</returns>
      static bool IsIsogram (string s) {
         List<char> seenCharacters = new ();
         foreach (char c in s) {
            if (seenCharacters.Contains (c))
               return false;
            seenCharacters.Add (c);
         }
         return true;
      }
      #endregion 
   }
   #endregion 
}