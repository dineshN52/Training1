// ------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ------------------------------------------------------------------------------------------
// Program.cs
// Swap values of two variables
// For given two variable input it swap their respective values in it
// For Example,if A=90,B=45 as input, the output will be A=45,B=90 as their values are swaped
// ------------------------------------------------------------------------------------------
namespace Swapnum {
   #region class Program-------------------------------
   /// <summary>Swap values of two variable</summary>
   internal class Program {
      #region Methods-----------------------------
      /// <summary>Method gets valid integer input from the user and pass it to swap function</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         int a, b;
         do {
            Console.Write ("Enter the valid number for A:");
         } while (!int.TryParse (Console.ReadLine (), out a));
         do {
            Console.Write ("Enter the valid number for B:");
         } while (!int.TryParse (Console.ReadLine (), out b));
         Console.WriteLine ($"Original values A={a} B={b}");
         Swap (a, b);
         Console.ReadKey ();
      }
      /// <summary>Method takes two inputs and swap the values</summary>
      /// <param name="a">Input1</param>
      /// <param name="b">Input2</param>
      static void Swap (int a, int b) {
         (b, a) = (a, b);
         Console.WriteLine ($"Swaped values A={a} B={b}");
      }
      #endregion
   }
   #endregion
}