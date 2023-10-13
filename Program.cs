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
      /// <summary>Method gets the input from user and check it isogram or not by distinct() function</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         Console.WriteLine ($"{s} is {(s.ToLower().Distinct ().Count () == s.Length ? "an" : "not an")} isogram");
         Console.ReadKey ();
      }
      #endregion
   }
   #endregion 
}