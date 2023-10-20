// -------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -------------------------------------------------------------------------------------------
// Program.cs
// Swap values of two variables
// For given two variable input it swap their respective values in it
// For Example, if A=90,B=45 as input, the output will be A=45,B=90 as their values are swaped
// -------------------------------------------------------------------------------------------
namespace Swapnum {
   #region class Program-------------------------------
   /// <summary>Swap values of two variable</summary>
   internal class Program {
      #region Methods-----------------------------
      /// <summary>Method gets valid integer input from the user and pass it to swap function</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter two integer values separated by a space: ");
         while (true) {
            string[] s = Console.ReadLine ().Split (' ');
            if (s.Length == 2 && int.TryParse (s[0], out int a) && int.TryParse (s[1], out int b)) {
               Console.Write ($"Original values A={a} B={b}");
               Swap (ref a, ref b);
               Console.Write ($"\nSwaped values A={a} B={b}");
               break;
            } else
               Console.Write ("Invalid input. Enter integer values separated by a space");
         }
         Console.ReadKey ();
      }

      /// <summary>Method takes two inputs and swap the values</summary>
      /// <param name="a">Input1</param>
      /// <param name="b">Input2</param>
      static void Swap (ref int a, ref int b) => (b, a) = (a, b);
      #endregion
   }
   #endregion
}