// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Password checker
//Ask the user to enter a password which follows a crieria:password must be 6 charcters length,has an uppercase,lowercase,numerical value & special charcter
//If the user missed any criteria,it prompts the user with an error message indicating what character is missing or length smaller than 6 characters
//For example,for input dineshN@password like dinesh5@,as given string doesn't have uppercase letter, output is "Password doesnot have uppercase"
//----------------------------------------------------------------------------------------------------------------------------------------------------------
using System.Text;
using System.Linq;
namespace PasswordChecker {
   #region  class Program------------------------------------------------
   /// <summary>PASSWORD CHECKER</summary>
   class Program {
      #region method-------------------------------------------------------------------
      /// <summary>Main method gets the user input and passes it to other function to check whether its meet the requirements</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Welcome! Your Password must be 6 characters in length \nAnd have an uppercase,lowercase,special character and number in it");
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
      /// <returns>Returns the boolean output for all criteria, 
      /// For example if input has uppercase letter it return True for hasUppercase and False if it not,same for other criteria</returns>
      static bool IsStrongPassword (string password) {
         bool hasUpperCase = false, hasLowerCase = false, hasNumericDigit = false, hasSpecialchar = false;
         StringBuilder message = new StringBuilder ();
         message.Append ("Your password does not have ");
         string[] cases = { "uppercase", "lowercase", "numerical digit", "special character" };
         string specialChar = @"\|!#$%&/()=?»«@{}.-;'<>_,";
         if (password.Length < 6) {
            Console.WriteLine ("Password must be atleast 6 characters in length");
            return false;
         }
         foreach (char c in password) {
            if (char.IsUpper (c))
               hasUpperCase = true;
            else if (char.IsLower (c))
               hasLowerCase = true;
            else if (char.IsDigit (c))
               hasNumericDigit = true;
            else if (specialChar.Contains (c))
               hasSpecialchar = true;
         }
         if (!hasUpperCase) {
            message.Append (cases[0]).Append (' ');
         }
         if (!hasLowerCase) {
            message.Append (cases[1]).Append (' ');
         }
         if (!hasNumericDigit) {
            message.Append (cases[2]).Append (' ');
         }
         if (!hasSpecialchar) {
            message.Append (cases[3]).Append (' ');
         }
         if(hasUpperCase && hasLowerCase && hasNumericDigit && hasSpecialchar) {
            Console.WriteLine ();
         }else
            Console.Write (message.ToString ());
         return hasUpperCase && hasLowerCase && hasNumericDigit && hasSpecialchar;
      }
      #endregion  
   }
   #endregion 
}
