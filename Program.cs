// --------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------
// Program.cs
// Pascal's triangle
// Ask the user to give number of rows in triangle and produces pascal's triangle with give number of rows
// For example,for input 5, it produces pascal's triangle with 5 rows
//---------------------------------------------------------------------------------------------------------
namespace Pascals {
   #region class program--------------------------
   /// <summary>Pascal's triangle</summary>
   class Program {
      #region Methods---------------------------------
      /// <summary>Method gets the number of rows in trianfle from user and passes it to other function to produce triangle</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the number of rows: ");
         while (true) {
            if (uint.TryParse (Console.ReadLine (), out uint numRows)) {
               PascalsTriangle (numRows);
               break;
            } else
               Console.WriteLine ("Invalid input. Please enter a valid non negative integer");
         }

         Console.ReadKey ();
      }
      /// <summary>Method prints the pascal's triangle with given number of rows</summary>
      /// <param name="numRows">Number of rows</param>
      static void PascalsTriangle (uint numRows) {
         int[,] triangle = new int[numRows, numRows];
         for (int i = 0; i < numRows; i++) {
            Console.Write (new string (' ', 4 * ((int)numRows - i - 1))); // Print leading spaces
            for (int j = 0; j <= i; j++) {
               if (j == 0 || j == i)
                  triangle[i, j] = 1;
               else
                  triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
               Console.Write ($"{triangle[i, j],8}");
            }
            Console.WriteLine ();
         }
      }
      #endregion 
   }
   #endregion 
}