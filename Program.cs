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
         for (int i = 1; i <= numRows; i++) {
            Console.Write (new string (' ', numRows - i));
            Console.WriteLine (new string ('*', 2 * i - 1));
         }
         for (int i = numRows - 1; i >= 1; i--) {
            Console.Write (new string (' ', numRows - i));
            Console.WriteLine (new string ('*', 2 * i - 1));
         }
      }
   }
}