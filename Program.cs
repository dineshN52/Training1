using System;
namespace Pascals {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the number of rows: ");
         uint numRows;
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out numRows)) {
               PascalsTriangle (numRows);
               break;
            } else {
               Console.WriteLine ("Invalid input. Please enter a valid non negative integer");
            }
         }
         Console.ReadKey ();
      }
      static void PascalsTriangle (uint numRows) {
         int[,] triangle = new int[numRows, numRows];
         for (int i = 0; i < numRows; i++) {
            Console.Write (new string (' ', (int)numRows - i - 1)); // Print leading spaces
            for (int j = 0; j <= i; j++) {
               if (j == 0 || j == i)
                  triangle[i, j] = 1;
               else
                  triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
               Console.Write ($"{triangle[i, j]} "); // Fill the triangle with values
            }
            Console.WriteLine ();
         }
      }
   }
}