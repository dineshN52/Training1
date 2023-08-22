using System;
namespace Palindrome {
   class Program {
      static bool IsPalindrome (string input) {
         input = input.ToLower (); // Convert the input to lowercase for case-insensitive comparison
         int left = 0, right = input.Length - 1;
         while (left < right) {
            if (input[left] != input[right])
               return false;
            left++;
            right--;
         }
         return true;
      }
      static void Main (string[] args) {
         Console.Write ("Enter a string: ");
         string input = Console.ReadLine ();
         Console.WriteLine (string.Concat ($"{input}, is", IsPalindrome (input) ? " a palindrome." : " not a palindrome."));
         Console.ReadKey ();
      }
   }
}