// ----------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Print individual digits of number
// Ask the user to give a number and function will print its individual digits separately for whole and decimal numbers
// For example, if given number is whole number : 4785, Output produced will be 4 7 8 5
// For example, if given number is decimal number : 378.586, output will be "Integral part digit: 3 7 8, Factorial part digit: 5 8 6"
// ----------------------------------------------------------------------------------------------------------------------------------
namespace Individualdigit {
   #region class Program------------------------
   /// <summary>Individual digits</summary>
   internal class Program {
      #region Methods--------------------------------------
      /// <summary>Function to print individual digits</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the number: ");
         while (true) {
            if (double.TryParse (Console.ReadLine (), out double number)) {
               SeparateDigits (number);
               break;
            } else
               Console.WriteLine ("Invalid input. Please enter a valid numerical value.");
         }
      }

      /// <summary>Method converts input integer or decimal to string 
      /// and split the number into substrings of integral and factorial part</summary>
      /// <param name="number"></param>
      static void SeparateDigits (double number) {
         string[] parts = number.ToString ().Split ('.'); //split input into two substrings(Integral and factorial part)
         PrintDigits (parts[0], (parts.Length == 1) ? "Individual" : "Integral");
         if (parts.Length > 1)
            PrintDigits (parts[1], "Factorial");
      }

      /// <summary>Join each value in the array of individual digits into a single string</summary>
      /// <param name="s">Array of Individual digits</param>
      /// <returns>Return string of individual digits with a space between each digits</returns>
      static void PrintDigits (string s, string prefix) => Console.WriteLine ($"{prefix} digits are: {string.Join (' ', s.ToCharArray ())}");
      #endregion 
   }
   #endregion 
}