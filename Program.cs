using System;
namespace reversenumber {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter a number: ");
         int num = int.Parse (Console.ReadLine ());
         int reversedNumber = ReverseNumber (num);
         Console.WriteLine ($"Reversed number: {reversedNumber}");
         Console.WriteLine (IsPalindrome (num) ? "The number is a palindrome." : "The number is not a palindrome");
      }
      static int ReverseNumber (int a) { // reverse a number
         int reverse = 0;
         while (a > 0) {
            int digit = a % 10;
            reverse = reverse * 10 + digit;
            a /= 10;
         }
         return reverse;
      }
      static bool IsPalindrome (int b) {
         return b == ReverseNumber (b);  // check number is a palindrome
      }
   }
}
