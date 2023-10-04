// ------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Reduce a string
// Ask the user to give a string,check it for double repetition of character and remove all the repetitions and reduce a string
// For Example,If the user input is "aadammm",the produced output will be "dam", thus reduce the repetition of letter 'a' and 'm'
// ------------------------------------------------------------------------------------------------------------------------------
using System.Text;
namespace ReduceString {
   #region Program-------------------------------------
   /// <summary>Reduce string with repetitions</summary>
   internal class Program {
      #region Methods------------------------------
      /// <summary>Get the input string from user and pass it other function to reduce double repetitions</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         Console.WriteLine ($"Input string : {s}\nOutput string :{ReduceString (s)}");
         Console.ReadKey ();
      }
      /// <summary>
      /// Creates a stack to store the charcter and chec for repetition by comparing and pop it out if have repetition
      /// </summary>
      /// <param name="input">Input string from main function</param>
      /// <returns>String with reduction in charctewith double repetition</returns>
      static string ReduceString (string input) {
         Stack<char> stack = new Stack<char> ();
         foreach (char c in input) {
            if (stack.Count > 0 && stack.Peek () == c)
               stack.Pop ();
            else
               stack.Push (c);
         }
         char[] resultArray = stack.ToArray ();// Convert the stack to a string
         Array.Reverse (resultArray);//Reverse it to get the correct order.
         return new string (resultArray);
      }
      #endregion
   }
   #endregion 
}
