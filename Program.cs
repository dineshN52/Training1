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
         Console.Write ("Enter a series of numbers with a space between them: ");
         while (true) {
            List<string> s = Console.ReadLine ().Split (' ').ToList ();
            int[] ints = s.Select (s => Int32.TryParse (s, out int n) ? n : (int?)null).Where (n => n.HasValue).Select (n => n.Value).ToArray ();
            Console.WriteLine ("Input number list: {0}", string.Join (' ', ints));
            if (ints.Any () && ints.Length > 1) {
               SwapHelp (ints);
               break;
            } else
               Console.WriteLine ("All inputs are invlaid. Enter an integers with a space between them");
         }
      }

      /// <summary>Method accepts input number list,ask the user to give indices to be swapped and pass to swap function</summary>
      /// <param name="series">Input number list</param>
      static void SwapHelp (int[] series) {
         int n = series.Length;
         Console.Write ("[Note: Index values should be less than length of list]\nEnter indices to be swapped separated by a space: ");
         while (true) {
            string[] s = Console.ReadLine ().Split (' ');
            if (s.Length == 2 && uint.TryParse (s[0], out uint a) && uint.TryParse (s[1], out uint b) && a < n && b < n) {
               Swap (ref series, (int)a, (int)b);
               Console.WriteLine ("Output number list: {0}", string.Join (' ', series));
               break;
            } else
               Console.WriteLine ("Invalid input. Enter integer values less than list length");
         }
      }

      /// <summary>Method takes two inputs and swap the values</summary>
      /// <param name="a">Input1</param>
      /// <param name="b">Input2</param>
      static void Swap (ref int[] arr, int a, int b) => (arr[b], arr[a]) = (arr[a], arr[b]);
      #endregion
   }
   #endregion
}



