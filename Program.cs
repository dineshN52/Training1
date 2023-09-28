//------------------------------------------------------------------------------------------------------------------------------------------------
//Training~A training program for new joinees at metamation,Batch-July 2023
//Copyright(c) Metamation India
//------------------------------------------------------------------------------------------------------------------------------------------------
//Program.cs
//REDUCE A STRING 
//Ask the user to give a string,check the string for continuos repetition of caharcter and remove all the repetitions and thereby reduce a string
//For Example,If the user input is " aadammm" ,the produced output will be "adam", thus reduce the repetition of letter 'a' and 'm'
//------------------------------------------------------------------------------------------------------------------------------------------------
using System.Text;
namespace ReduceString {
   #region Program-------------------------------------
   /// <summary>REDUCE A STRING WITH REPETITIONS</summary>
   internal class Program {
      #region Method------------------------------
      /// <summary>Method get the input string from user and craete a new string with no repetition by replacing all repetition with single character</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         StringBuilder reduced = new StringBuilder ();
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         if (s.Length > 0) {
            reduced.Append (s[0]);
            for (int i = 1; i < s.Length; i++)
               if (s[i] != s[i - 1])
                  reduced.Append (s[i]);
         }
         Console.WriteLine ($"Reduced string: {reduced.ToString ()}");
         Console.ReadKey ();
      }
      #endregion 
   }
   #endregion 
}
