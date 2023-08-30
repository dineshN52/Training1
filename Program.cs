using System;
namespace PasswordChecker {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the password: ");
         string pass = Console.ReadLine ();
         Console.WriteLine (IsStrongPassword (pass) ? "Password is strong." : "Password is weak.");
         Console.ReadKey ();
      }
      static bool IsStrongPassword (string password) {
         if (password.Length < 6) {
            Console.WriteLine ("Your password has less than 6 letters");
            return false;
         }
         var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; var lowerCase = "abcdefghijklmnopqrstuvwxyz";
         var specialChar = ":!@#$%^&*()-_+=<>?"; var Digits = "0123456789";
         bool hasUpperCase = false, hasLowerCase = false, hasSpecialCharacter = false, hasNumericDigit = false;
         foreach (char c in password) {
            switch (c) {
               case char u when upperCase.Contains (u):
                  hasUpperCase = true;
                  break;
               case char l when lowerCase.Contains (l):
                  hasLowerCase = true;
                  break;
               case char s when specialChar.Contains (s):
                  hasSpecialCharacter = true;
                  break;
               case char n when Digits.Contains (n):
                  hasNumericDigit = true;
                  break;
            }
         }
         if (!hasUpperCase == true)
            Console.WriteLine ("Your password doesn't have Uppercase");
         if (!hasLowerCase == true)
            Console.WriteLine ("Your password doesn't have Lowercase");
         if (!hasSpecialCharacter == true)
            Console.WriteLine ("Your password doesn't have Special Charcter");
         if (!hasNumericDigit == true)
            Console.WriteLine ("Your password doesn't have Numeric digit");
         return hasUpperCase && hasLowerCase && hasSpecialCharacter && hasNumericDigit;
      }
   }
}
