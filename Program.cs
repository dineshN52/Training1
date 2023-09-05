using System;

namespace Pascals {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the number of rows: ");
         int numRows = int.Parse (Console.ReadLine ());
         PascalsTriangle (numRows);
         Console.ReadKey ();
      }
      static void PascalsTriangle (int numRows) {
         for (int i = 0; i < numRows; i++) {
            int num = 1;
            Console.Write (new string (' ', numRows - i - 1)); // Print leading spaces
            for (int j = 0; j <= i; j++) {
               Console.Write ($"{num} ");
               num = num * (i - j) / (j + 1);
            }
            Console.WriteLine ();
         }
      }
   }
}
