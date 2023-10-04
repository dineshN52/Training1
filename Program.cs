// ----------------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Password checker
// Ask the user to give a password which follows a crieria:It must be 6 charcters length,has an uppercase,lowercase,numerical value & special charcter
// If the user missed any criteria,it prompts the user with an error message indicating what character is missing or length smaller than 6 characters
// For example,for input dineshN@password like dinesh5@,as given string doesn't have uppercase letter, output is "Password doesnot have uppercase"
//-----------------------------------------------------------------------------------------------------------------------------------------------------
using System.Text;
using System.Linq;
namespace PasswordChecker {
   #region  class Program------------------------------------------------
   /// <summary>Password checker</summary>
   class Program {
      #region method-------------------------------------------------------------------
      /// <summary>Main method gets the user input and passes it to other function to check whether its meet the requirements</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Welcome! Your Password must be 6 characters in length \nAnd should have an uppercase,lowercase,special character & number");
         Console.Write ("Enter the password: ");
         while (true) {
            string pass = Console.ReadLine ();
            if (IsStrongPassword (pass)) {
               Console.WriteLine ("\nPassword is strong.");
               break;
            } else
               Console.WriteLine ("\nPassword is weak.Try again");
         }
         Console.ReadKey ();
      }
      /// <summary>This method checks the input whether it satisfies required criteria</summary>
      /// <param name="password">A string of charcters obtained from the user as a parameter called password</param>
      /// <returns>Returns the boolean output for all criteria, 
      /// For example,if input has uppercase letter it return True for hasUppercase & False if it doesn't have,same for other criteria</returns>
      static bool IsStrongPassword (string password) {
         StringBuilder message = new StringBuilder ("Your password does not have ");
         string[] criteria = { "uppercase", "lowercase", "numerical digit", "special character" };
         string specialChar = @"\|!#$%&/()=?»«@{}.-;'<>_,";
         if (password.Length < 6) {
            Console.WriteLine ("Password must be atleast 6 characters in length");
            return false;
         }
         bool[] criterionChecks = {
                password.Any(char.IsUpper),
                password.Any(char.IsLower),
                password.Any(char.IsDigit),
                password.Any(c => specialChar.Contains(c))
            };
         bool isAlltrue = criterionChecks.All (check => check);
         if (!isAlltrue) {
            for (int i = 0; i < criteria.Length; i++) {
               if (!criterionChecks[i])
                  message.Append (criteria[i]).Append (',');
            }
            Console.Write (message.ToString ());
         }
         return isAlltrue;
      }
      #endregion
   }
   #endregion
}
