// --------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------------
// Program.cs
// Swap position of the digits
// For a given non-singular digit bumber, swaps the positio of digites with respect to given indices
// For Example,number 5 4 3 7 8,if the indices to be swapped is 1,2,new number with swapped position is 5 3 4 7 8
// --------------------------------------------------------------------------------------------------------------
namespace SwapIndices {
   #region Class program-----------------------------
   /// <summary>Swap positions of digits</summary>
   internal class Program {
      #region Methods-----------------------------
      /// <summary>Method gets the number & indices to be swapped from user and pass to swap function</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter an non single digit number: ");
         while (true) {
            string number = Console.ReadLine ();
            int length = number.ToString ().Length;
            if (int.TryParse (number, out int num) && length >= 2) {
               List<int> arr = new List<int> ();
               for (int i = 0; i < length; i++) {
                  arr.Add (num % 10);
                  num /= 10;
               }
               arr.Reverse ();
               Console.WriteLine ("[Note:Indices should be value less than the length of number]");
               while (true) {
                  Console.Write ("Enter two indices separated by space: ");
                  string input = Console.ReadLine ();
                  string[] indices = input.Split (' ');
                  if (indices.Length == 2 && uint.TryParse (indices[0], out uint a) &&
                      uint.TryParse (indices[1], out uint b) && a < length && b < length) {
                     Swap (ref arr, (int)a, (int)b);
                     Console.Write ("Number with swapped indices: ");
                     for (int i = 0; i < length; i++) {
                        Console.Write ($"{arr[i]}");
                     }
                     Console.ReadKey ();
                     break;
                  } else
                     Console.WriteLine ("Invalid input. Enter two valid indices separated by space.");
               }
               break;
            } else
               Console.WriteLine ("\nEnter a valid non-single digit number");
         }
      }
      /// <summary>It swaps the numbers at given indices with the help of tuple</summary>
      /// <param name="arr">Input number as list of digits</param>
      /// <param name="a">First index to be swapped</param>
      /// <param name="b">Second index to be swapped</param>
      /// <returns>Returns number with swapped digits</returns>
      static List<int> Swap (ref List<int> arr, int a, int b) {
         (arr[b], arr[a]) = (arr[a], arr[b]);
         return arr;
      }
      #endregion
   }
   #endregion
}
