using System;
namespace Palindrome {
   class Program {
      static bool IsPalindrome (string input) {
         input = input.ToLower (); // Convert the input to lowercase for case-insensitive comparison
         char left = input[0];
         char right = input[input.Length - 1];
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
         if (IsPalindrome (input))
            Console.WriteLine ("Given input is a palindrome.");
         else
            Console.WriteLine ("Given input is not a palindrome.");
      }
   }
}