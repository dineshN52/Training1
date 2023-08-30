﻿using System;
namespace reversenumber {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter a number: ");
         int num = int.Parse (Console.ReadLine ());
         Console.WriteLine ($"Reversed number: {ReverseNumber(num)}");
         Console.WriteLine (IsPalindrome (num) ? "The number is a palindrome." : "The number is not a palindrome");
         Console.ReadKey ();
      }
      static int ReverseNumber (int a) { // reverse a number
         int reverse = 0;
         while (a > 0) {
            reverse = reverse * 10 + a % 10;
            a /= 10;
         }
         return reverse;
      }
      static bool IsPalindrome (int b) {
         return b == ReverseNumber (b);  // check number is a palindrome
      }
   }
}
