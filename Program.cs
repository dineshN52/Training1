// ----------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------
// Program.cs
// Armstrong number
// Ask the user to give a number and check whether given number is armstrong or not
// For example, The given number 3 7 1, produced output is 3 7 1 and 3 7 1 is an armstrong number
// Ask the user to give a number and produce the nth armstrong number of the given number
// For example, The given number is 12, Produced output: 12th armstrong number is 371
// ----------------------------------------------------------------------------------------------
namespace Armstrong {
   #region class Program------------------------------
   /// <summary>Armstrong number</summary>
   class Program {
      #region Methods------------------------------------
      /// <summary>Method to find armstrong number</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         uint num, n;
         double result;
         Console.Write ("Enter the number:");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out num)) {
               result = Isarmstrong ((int)num);
               Console.WriteLine ($"Produced output: {result}");
               break;
            } else
               Console.WriteLine ("Invalid input.Enter a non-negative integer");
         }
         Console.WriteLine ((result == (double)num) ? $"{num} is an armstrong number" : $"{num} is not an armstrong number");
         Console.Write ("Enter the nth value: ");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out n)) {
               NthArmstrong (n);
               break;
            } else
               Console.WriteLine ("Invalid input.Enter an integer value");
         }
         Console.ReadKey ();
      }
      /// <summary>
      /// Method finds sum of exponentials of each digits of number with legth of number as power
      /// (Mathematical logic behind Armstrong numbers)
      /// </summary>
      /// <param name="temp"></param>
      /// <param name="digits">Variable to store the number of digits in the number</param>
      /// <param name="digit">Variable to store the current digit  </param>"
      /// <returns>Return the produced output</returns>
      static double Isarmstrong (int temp) {
         double final = 0;
         int digits = temp.ToString ().Length;
         while (temp > 0) {
            int digit = temp % 10;
            final += Math.Pow (digit, digits);
            temp /= 10;
         }
         return final;
      }
      /// <summary>This method checks each number whether its armstrong or not and update the count with the respective nth value</summary>
      /// <param name="n"></param>
      /// <param name="number">A variable to keep track of the current number</param>
      /// <param name="count">A variable to keep track of the count of Armstrong numbers</param>
      static void NthArmstrong (uint n) {
         int number = 1, count = 0, result = 0;
         while (count < n) {
            if (Isarmstrong (number) == number) {
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