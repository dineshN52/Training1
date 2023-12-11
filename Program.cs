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
   internal class Program {
      /// <summary>Main method to implement the double parse</summary>
      static void Main () { }
   }

   /// <summary>Custom double class</summary>
   public class MyDouble {

      /// <summary>Method which performs try parse and output the double value of string if valid, 
      /// or throw exception</summary>
      /// <param name="s">Input string to be parsed</param>
      /// <returns>Return the output double value of string</returns>
      /// <exception cref="FormatException">Throws the format exception 
      /// if the input string is not in a correct format for double conversion</exception>
      public static double Parse (string s) => MyDouble.TryParse (s, out double final) ? final :
               throw new FormatException ($"Input string {s} was not in a correct format");

      /// <summary>Tryparse method which checks the format 
      /// and produces the double value of input if it is valid, return false otherwise</summary>
      /// <param name="s">Input sring to be parsed</param>
      /// <param name="num">output double value of string</param>
      /// <returns>Returns boolean value of true if format is corerct and false if invalid</returns>
      public static bool TryParse (string s, out double num) {
         num = 0;
         string a = s.ToUpper ();
         if (!IsValid (a)) return false;
         if (ExponentCheck (a)) {
            num = ConvertDouble (a);
            return true;
         } else if (a.Contains ('.')) {
            string[] number = a.Split ('.');
            int IntegralPart = number[0] == "" || number[0] == "-" || number[0] == "+" ? 0 : int.Parse (number[0]);
            double secondPart = number[1] == "" || number[1] == "-" || number[1] == "+" ? 0 : int.Parse (number[1]);
            double factorialPart = number[0].StartsWith ('-') ? -(secondPart / Math.Pow (10, number[1].Length)) :
               secondPart / Math.Pow (10, number[1].Length);
            num = IntegralPart + factorialPart;
            return true;
         } else {
            num = int.Parse (a);
            return true;
         }
      }

      /// <summary>Method to convert given input to double, only if it has exponential(e) in it</summary>
      /// <param name="str">Input string</param>
      /// <returns>Returns the double value of string</returns>
      static double ConvertDouble (string str) {
         string[] parts = str.Split ('E');
         string integerPart = parts[0] == "" ? "1" : parts[0];
         var firstPart = integerPart.Contains ('.') ? float.Parse (integerPart) : int.Parse (integerPart);
         var d = firstPart * Math.Pow (10, int.Parse (parts[1]));
         return d;
      }

      /// <summary>Method to check whether given input string has exponent in it</summary>
      /// <param name="s">Input string</param>
      /// <returns>Return true if it has exponential value or false, otherwise</returns>
      static bool ExponentCheck (string s) => s.Contains ('E');

      /// <summary>Method to check whether input string is in valid format</summary>
      /// <param name="str">Input string</param>
      /// <returns>Returns true if string is in valid format or false, otherwise</returns>
      static bool IsValid (string str) {
         int Ecount = 0, signCount = 0, dotCount = 0;
         foreach (var ch in str) {
            switch (ch) {
               case '+' or '-':
                  if (++signCount > 2) return false;
                  break;
               case '.':
                  if (++dotCount > 1) return false;
                  break;
               case 'E':
                  if (++Ecount > 1) return false;
                  break;
               default:
                  if (!char.IsDigit (ch)) return false;
                  break;
            }
         }
         bool result = (str[0] == '+' || str[0] == '-' || str[0] == '.' || char.IsDigit (str[0])) &&
                !str.EndsWith ('+') && !str.EndsWith ('-') && !str.EndsWith ('E');
         if (result) {
            result = ExponentCheck (str) || str.Contains ('.') ? IsPartsValid (str) :
                (str.Contains ('+') || str.Contains ('-')) ? IsSignsValid (str) : true;
            return result;
         }
         return false;

         /// <summary>Method checks if the placement and position of signs are in correct format in the string</summary>
         static bool IsSignsValid (string s) {
            if (s.StartsWith ('+') || s.StartsWith ('-')) {
               string x = s[1..];
               if (!x.Contains ('+') && !x.Contains ('-'))
                  return true;
            }
            return false;
         }

         /// <summary>Method splits the string into two parts if it has "e" or "." 
         /// and check both parts is in corretc format</summary>
         static bool IsPartsValid (string s) {
            bool final = false;
            string[] parts = s.Contains ('E') ? s.Split ('E') : s.Split ('.');
            (string integerPart, string factorialPart) = (parts[0], parts[1]);
            if (s.Contains ('.'))
               final = !factorialPart.Contains ('E');
            else
               final = integerPart != "" && factorialPart != "" && !factorialPart.Contains ('.');
            if (integerPart.Contains ('+') || integerPart.Contains ('-'))
               final = integerPart.Count (a => a is '+' or '-') == 1 && integerPart[0] is '+' or '-';
            if (factorialPart.Contains ('+') || factorialPart.Contains ('-'))
               final = factorialPart.Count (a => a is '+' or '-') == 1 && factorialPart[0] is '+' or '-';
            return final;
         }
      }
   }
}