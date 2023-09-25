//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Training~A training program for new joinees at metamation,Batch-July 2023
//Copyright(c) Metamation India
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Program.cs
//PASSWORD CHECKER
//Ask the user to enter a password which meets the following criteria: Password should atleast conatin one uppercase letter, a smallercase letter, a numerical digit & a special character and also should be og length >= 6 charcters
//If the user missed any criteria, program prompts the user with an error message indicating what character is missing or length smaller than 6 characters
//For example, if user enters a password like dinesh5@,Program produce an error message"Your password does not have uppercase" as input misses atleast one uppercase letter and the same for other criteria
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
namespace PasswordChecker {
   #region  class Program------------------------------------------------
   /// <summary>PASSWORD CHECKER</summary>
   class Program {
      #region method-------------------------------------------------------------------
      /// <summary>Main function which gets the user input and passes it to other function to check whether its meet the requirements</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Welcome!Your password must satisfy following criteria \n An Uppercase letter\n A lowercase letter\n A special character\n A numerical digit\n And must be length of 6 characters");
         Console.Write ("Enter the password: ");
         while (true) {
            string pass = Console.ReadLine ();
            if (IsStrongPassword (pass)) {
               Console.WriteLine ("\nPassword is strong.");
               break;
            } else {
               Console.WriteLine ("\nPassword is weak.Try again");
            }
         }
         Console.ReadKey ();
      }
      /// <summary>This class checks the input password with conditions like presence of uppercase,lowercase,Numericdigit,special character</summary>
      /// <param name="password">A string of charcters obtained from the user as a parameter called password</param>
      /// <returns>Returns the boolean output for all criteria, For example if input has uppercase letter it return True for hasUppercase and false if it doesnot have uppercase and same for other criteria</returns>
      static bool IsStrongPassword (string password) {
         bool hasUpperCase = false, hasLowerCase = false, hasNumericDigit = false, hasSpecialchar = false;
         string[] cases = { "Uppercase", "Lowercase", "NumericDigit", "special charcater" };
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
            } else if (specialChar.Contains (c)) {
               hasSpecialchar = true;
            }
         }
         Console.Write (!hasUpperCase ? $"Your password does not have {cases[0]}" : " ");
         Console.Write (!hasLowerCase ? $"\nYour password does not have {cases[1]}" : " ");
         Console.Write (!hasNumericDigit ? $"\nYour password does not have {cases[2]}" : " ");
         Console.Write (!hasSpecialchar ? $"\nYour password does not have {cases[3]}" : " ");
         return hasUpperCase && hasLowerCase && hasNumericDigit && hasSpecialchar;
      }
      #endregion  
   }
   #endregion 
}
