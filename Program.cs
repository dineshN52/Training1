//-------------------------------------------------------------------------
//Training~A training program for new joinees at metamation,Batch-July 2023
//Copyright(c) Metamation India
//-------------------------------------------------------------------------
//Program.cs
//FACTORIAL OF A NUMBER
//Ask the user to give a number and produces the factorial value of it
//For example, The given number is 5, Produced output is 120
//-------------------------------------------------------------------------
namespace Factorial {
   /// <summary>FACTORIAL</summary>
   internal class Program {
      /// <summary>Method to find factorial of a given number</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the number:");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out uint number)) {
               Console.WriteLine ($"Factorial of {number} is " + Factorial (number));
               break;
            } else {
               Console.WriteLine ("Invalid input.Enter the non-negative positive number");
            }
         }
         Console.ReadKey ();
      }
      /// <summary>
      /// This method takes the number and multiply with the previous number until it reachs '1'(Mathematical logic of a factorial)
      /// </summary>
      /// <param name="number"></param>
      /// <returns>Return the multiplied output</returns>
      static double Factorial (uint number) {
         if (number == 0 || number == 1)
            return 1;
         double fact = 1;
         for (int i = 2; i <= number; i++) {
            fact *= i;
         }
         return fact;
      }
   }
}