using System;
namespace PasswordChecker {
   class Program {
      static void Main (string[] args) {
         Console.WriteLine ("Welcome!Your password must satisfy following criteria \n An Uppercase letter\n A lowercase letter\n A special character\n A numerical digit\n And must be length of 6 characters");
         Console.Write ("Enter the password: ");
         string pass = Console.ReadLine ();
         Console.WriteLine (IsStrongPassword (pass) ? "\nPassword is strong." : "\nPassword is weak.");
         Console.ReadKey ();
      }
      static bool IsStrongPassword (string password) {
         bool hasUpperCase = false, hasLowerCase = false, hasNumericDigit = false, hasSpecialchar = false;
         string[] cases = { "Uppercase", "Lowercase", "NumericDigit","special charcater"};
         string specialChar = @"\|!#$%&/()=?»«@{}.-;'<>_,";
         if (password.Length < 6) {
            Console.WriteLine ("Your password has less than 6 characters.");
            return false;
         }             
         foreach (char c in password) {
            if (char.IsUpper (c)) {
               hasUpperCase = true;
            } else if (char.IsLower (c)) {
               hasLowerCase = true;
            } else if (char.IsDigit (c)) {
               hasNumericDigit = true;
            } else if (specialChar .Contains (c)) {
               hasSpecialchar = true;
            }
         }
         Console.Write(!hasUpperCase?$"Your password does not have {cases[0]}":" ");
         Console.Write(!hasLowerCase?$"\nYour password does not have {cases[1]}": " ");
         Console.Write(!hasNumericDigit?$"\nYour password does not have {cases[2]}": " ");
         Console.Write (!hasSpecialchar ? $"\nYour password does not have {cases[3]}" : " ");
         return hasUpperCase && hasLowerCase && hasNumericDigit && hasSpecialchar;
      }
   }
}

