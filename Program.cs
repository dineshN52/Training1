using System;
namespace StringPermutation {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string input = Console.ReadLine ();
         Console.WriteLine ("Permutations:");
         Permute (input.ToCharArray (), 0, input.Length - 1);
         Console.ReadKey ();
      }
      static void Permute (char[] arr, int startIndex, int endIndex) {
         if (startIndex == endIndex) {
            Console.WriteLine (new string (arr));
         } else {
            for (int i = startIndex; i <= endIndex; i++) {
               Swap (ref arr[i], ref arr[startIndex]);
               Permute (arr, startIndex + 1, endIndex);
            }
         }
      }
      static void Swap (ref char a, ref char b) {
         char temp = a;
         a = b;
         b = temp;
      }
   }
}
