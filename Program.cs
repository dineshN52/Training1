using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace NandR {
   class Program {
      static void Main (string[] args) {
         int n;
         Console.Write("Enter the value:");
         n = int.Parse (Console.ReadLine ());
         Console.WriteLine ("Number into words:");
         Console.WriteLine (int_to_words (n));
         Console.WriteLine ("Roman numerals of the said integer value:");
         Console.WriteLine (int_to_Roman (n));
         Console.ReadKey ();
      }
      public static string int_to_words (int n) {
         string[] ones = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
         string[] tens = new string[] { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
         string[] mult = new string[] { "zero", "ten", "hundred", "thousand", "thousand", "million", "billion", "trillion", "hundred and" };
         var int_to_w = new StringBuilder ();
         var b = new StringBuilder ();
         int a = 0, rem = n, q,r;
         a = n.ToString ().Length;
         switch (a) {
            case 1:
               for (int i = 9; i >= 1; i--) 
                  if (rem % i == 0) 
                     return ones[i-1];               
               return ones[0];
               break;
            case 2:
               if (n < 20) {
                  for (int i = 19; i >= 11; i--)
                     if (rem % i == 0)
                        return teens[i - 10];
                  return teens[0];
               }                 
               else {
                  q = rem / 10;
                  r = rem % 10;
                  if (r == 0)
                     return tens[q - 1];
                  else
                     for (int i = 1; i <= 1; i++)
                        if (r % i == 0)
                           return tens[q - 1] + ones[r - 1];
               }
               break;
            case 3:
               q = rem / 100;
               r = rem % 100;
               if (r == 0) {
                  return ones[q - 1] + mult[2];
               } else {
                  if (r.ToString ().Length == 1)
                     return ones[q - 1] + mult[8] + ones[r - 1];
                  else
                     b =goto case 2;
                  return ones[q - 1] + mult[2] + b ;
                    
               }
               break;
         }
         return int_to_w.ToString ();
      }
      public static string int_to_Roman (int n) {
         string[] roman_symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
         int[] int_value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
         var roman_numerals = new StringBuilder ();
         var index_num = 0;
         while (n != 0) {
            if (n >= int_value[index_num]) {
               n -= int_value[index_num];
               roman_numerals.Append (roman_symbol[index_num]);
            }                              
            else 
               index_num++;                 
         }
         return roman_numerals.ToString ();
      }
   }   
}