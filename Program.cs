using System;
namespace diamond {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the number of rows: ");
         int n = int.Parse (Console.ReadLine ());
         PrintDiamond (n);
         Console.ReadKey ();
      }
      static void PrintDiamond (int numRows) {
         for (int i = 1; i <= numRows * 2 - 1; i++) {
            int spaces = Math.Abs (numRows - i);
            int stars = numRows * 2 - 1 - 2 * spaces;
            Console.Write (new string (' ', spaces));
            Console.WriteLine (new string ('*', stars));
         }
      }
   }
}