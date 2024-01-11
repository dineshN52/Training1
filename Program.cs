// ---------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------
// Program.cs
// Custom Double.parse
// A custom class called MyDouble with two major methods like Tryparse and parse was created
// Any valuable string argument to the method will produce the output double value or else throw a formatexception
// For example,the MyDouble.parse("+5.3e45") will produce the 5.3E+45
// And the string ".e34" should throw a format exception with message"Input string .e34 is not in correct format
// ---------------------------------------------------------------------------------------------------------------
namespace Training {
   #region Internal class Program---------------------------------------------
   internal class Program {
      /// <summary>Main method to implement the double parse</summary>
      static void Main () { }
   }
   #endregion

   #region Custom Double classs----------------------------
   /// <summary>Custom double class</summary>
   public class MyDouble {

      #region Methods-------------------------------
      /// <summary>Method which performs try parse and output the double value of string if valid, 
      /// or throw exception</summary>
      /// <param name="s">Input string to be parsed</param>
      /// <returns>Return the output double value of string</returns>
      /// <exception cref="FormatException">Throws the format exception 
      /// if the input string is not in a correct format for double conversion</exception>
      public double Parse (string s) {
         if (s == null) throw new ArgumentNullException ("Input should not be empty");
         if (TryParse (s.ToUpper (), out double final))
            return final;
         else throw new FormatException ($"Input string {s} was not in a correct format");
      }

      /// <summary>Tryparse method which checks the format 
      /// and produces the double value of input if it is valid, return false otherwise</summary>
      /// <param name="s">Input sring to be parsed</param>
      /// <param name="num">output double value of string</param>
      /// <returns>Returns boolean value of true if format is corerct and false if invalid</returns>
      /// <exception cref="ArgumentNullException">If string input is null or empty it throws argumentnull exception</exception>
      public static bool TryParse (string s, out double num) {
         num = 0;
         if (!IsValid (s)) return false;
         num = IsExp || IsDot ? ConvertDouble () : int.Parse (s);
         return true;
      }

      /// <summary>Method to convert given input to double, only if it has exponential(e) in it</summary>
      /// <param name="str">Input string</param>
      /// <returns>Returns the double value of string</returns>
      static double ConvertDouble () {
         if (IsExp) {
            var integerPart = parts[0] == "" ? 1 : parts[0].Contains ('.') ? Convert (parts[0].Split ('.')) : int.Parse (parts[0]);
            var fractionalPart = Math.Pow (10, int.Parse (parts[1]));
            return integerPart * fractionalPart;
         } else
            return Convert (parts);

         ///<summary>Method to convert decimal digits to double value</summary>
         static double Convert (string[] s) {
            double firstPart = s[0] == "" || s[0] == "-" || s[0] == "+" ? 0 : int.Parse (s[0]);
            double secondPart = IsExp || (s[1] != "" && s[1] != "-" && s[1] != "+") ? int.Parse (s[1]) / Math.Pow (10, s[1].Length) : 0;
            return s[0].StartsWith ('-') ? firstPart + (-secondPart) : firstPart + secondPart;
         }
      }

      /// <summary>Method to check whether input string is in valid format</summary>
      /// <param name="str">Input string</param>
      /// <returns>Returns true if string is in valid format or false, otherwise</returns>
      static bool IsValid (string str) {
         int eCount = 0, signCount = 0, dotCount = 0;
         foreach (var ch in str) {
            switch (ch) {
               case '+' or '-':
                  if (++signCount > 2) return false;
                  break;
               case '.':
                  if (++dotCount > 1) return false;
                  break;
               case 'E':
                  if (++eCount > 1) return false;
                  break;
               default:
                  if (!char.IsDigit (ch)) return false;
                  break;
            }
         }
         IsExp = eCount >= 1; IsDot = dotCount >= 1;
         if (IsExp || IsDot)
            parts = IsExp ? str.Split ('E') : str.Split ('.');
         if (!str.EndsWith ('E') && str[0] != 'E')
            return parts.Length > 0 ? IsPartsValid () : IsSignsValid (str, signCount);
         return false;

         /// <summary>Method checks if the placement and position of signs are in correct format in the string</summary>
         static bool IsSignsValid (string s, int signCount) {
            if (signCount >= 1) {
               if (s[0] is '+' or '-' && signCount == 1) return true;
               return false;
            }
            return true;
         }

         /// <summary>Method splits the string into two parts if it has "e" or "." 
         /// and check both parts is in corretc format</summary>
         static bool IsPartsValid () {
            bool final = IsSignsValid (parts[0], sCount (parts[0])) && IsSignsValid (parts[1], sCount (parts[1]));
            if (IsExp && final)
               return parts[0] != "" && parts[0] != "." && parts[1] != "" && !parts[1].Contains ('.');
            return final;
         }

         ///<summary>Method to give count of signs in a given string</summary>
         static int sCount (string s) => s.Count (a => a is '+' or '-');
      }
      #endregion

      #region Properties-------------------
      static bool IsExp { get; set; }
      static bool IsDot { get; set; }
      static string[] parts = Array.Empty<string> ();
      #endregion  
   }
   #endregion
}