// --------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Print individual digits of number
// Ask the user to give a number and function will print its individual digits separately for whole and decimal numbers
// For example, The given number is whole number : 4785, Output produced will be 4 7 8 5
// For example, The given number is decimal number : 378.586, Output will be Integral part digit: 3 7 8,Factorial part digit: 5 8 6
// --------------------------------------------------------------------------------------------------------------------------------
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
               Individualdigits (number);
               break;
            } else
               Console.WriteLine ("Invalid input.Please enter a valid numerical value.");
         }
         Console.ReadKey ();
      }

      /// <summary>Method converts input integer or decimal to string 
      /// and split the number into substrings of integral and factorial part</summary>
      /// <param name="number"></param>
      static void Individualdigits (double number) {
         string value = number.ToString ();
         if (value.Contains ('.')) {
            string[] parts = value.Split ('.'); //split input into two substrings(Integral and factorial part)
            Console.WriteLine ("Integral part digits are: {0}", string.Join (' ', parts[0].ToCharArray ()));
            Console.WriteLine ("Factorial part digits are:{0}", string.Join (' ', parts[1].ToCharArray ()));
         } else
            Console.Write ("Individual digits are: {0}", string.Join (' ', value.ToCharArray ()));
      }
      #endregion 
   }
   #endregion 
}