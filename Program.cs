// ----------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------
// Program.cs
// Armstrong number
// Ask the user to give a number and check whether given number is armstrong or not
// For example, the given number 3 7 1, produced output is 3 7 1 and 3 7 1 is an armstrong number
// Ask the user to give a number and produce the nth armstrong number of the given number
// For example, the given number is 12, produced output: 12th armstrong number is 371
// ----------------------------------------------------------------------------------------------
namespace Armstrong {
   #region class Program------------------------------
   /// <summary>Armstrong number</summary>
   class Program {
      #region Methods------------------------------------
      /// <summary>Method to find armstrong number</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the number: ");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out uint num)) {
               Console.WriteLine ($"{num} is {(Isarmstrong (num) ? "an" : "not an")} armstrong number");
               break;
            } else
               Console.WriteLine ("Invalid input. Enter a non-negative integer");
         }
         Console.Write ("[Note: Maximum value of n is restricted to 25]\nEnter the nth value: ");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out uint n)) {
               NthArmstrong (n);
               break;
            } else
               Console.WriteLine ("Invalid input. Enter an integer value");
         }
         Console.ReadKey ();
      }

      /// <summary>Method finds sum of exponentials of each digits of number with legth of number as power
      /// (Mathematical logic behind Armstrong numbers)</summary>
      /// <param name="temp"></param>
      /// <param name="digits">Variable to store the number of digits in the number</param>
      /// <param name="digit">Variable to store the current digit</param>"
      /// <returns>Return the produced output</returns>
      static bool Isarmstrong (uint input) {
         double final = 0; uint temp = input;
         int digits = input.ToString ().Length;
         while (temp > 0) {
            uint digit = temp % 10;
            final += Math.Pow (digit, digits);
            temp /= 10;
         }
         if (final == input)
            return true;
         return false;
      }

      /// <summary>This method checks each number whether its armstrong or not and update the count with the respective nth value</summary>
      /// <param name="n"></param>
      /// <param name="number">A variable to keep track of the current number</param>
      /// <param name="count">A variable to keep track of the count of armstrong numbers</param>
      static void NthArmstrong (uint n) {
         uint number = 1, count = 0, result = 0;
         while (count < n) {
            if (Isarmstrong (number)) {
               count++;
               result = number;
            }
            number++;
         }
         Console.WriteLine ($"The {n}th Armstrong number is {result}");
      }
      #endregion 
   }
   #endregion 
}