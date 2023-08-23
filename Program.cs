using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace NandR {
   class Program {
      static void Main (string[] args) {
         long n;
         Console.Write("Enter the value:");
         n = long.Parse (Console.ReadLine ());
         Console.WriteLine ("Number into words:");
         Console.WriteLine (int_to_words (n));
         Console.WriteLine ("Roman numerals of the said integer value:");
         Console.WriteLine (int_to_Roman (n));
         Console.ReadKey ();
      }
      public static string int_to_words (long n) {
         string[] ones = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
         string[] tens = new string[] { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
         string[] mult = new string[] { "zero", "ten", "hundred", "thousand", "thousand", "million", "billion", "trillion", "hundred and" };
         var intToW = new StringBuilder ();
         int a;long b;
         if (n == 0) 
            return mult[0];       
         a = n.ToString ().Length;
         if (a == 13) {
            long trillions = n / 1000000000000;
            intToW.Append (int_to_words ((int)trillions)).Append (" ").Append (mult[7]);
            b=n%1000000000000;
            if (b > 0) 
               intToW.Append (" ");           
         }
         else if (a == 10) {
            long billions = n / 1000000000;
            intToW.Append (int_to_words ((int)billions)).Append (" ").Append (mult[6]);
            n %= 1000000000;
            if (n > 0) 
               intToW.Append (" ");            
         }
         else if (a == 7) {
            int millions = (int)n / 1000000;
            intToW.Append (int_to_words (millions)).Append (" ").Append (mult[5]);
            n %= 1000000;
            if (n > 0) 
               intToW.Append (" ");           
         }
         else if (a == 4) {
            int thousands = (int)n / 1000;
            intToW.Append (int_to_words (thousands)).Append (" ").Append (mult[3]);
            n %= 1000;
            if (n > 0) 
               intToW.Append (" ");            
         }
         else if (n == 3) {
            int hundreds = (int)n / 100;
            intToW.Append (ones[hundreds - 1]).Append (" ").Append (mult[2]);
            n %= 100;
            if (n > 0) 
               intToW.Append (" and ");           
         }
         else if (a == 2) {
            if (n >= 20) {
               int tensDigit = (int)n / 10, onesDigit = (int)n % 10;
               intToW.Append (tens[tensDigit - 1]).Append (ones[onesDigit-1]);              
            } else if (n >= 10 && n < 20) {
               intToW.Append (teens[n - 10]);
            }
         }
         else if (a==1) {
            intToW.Append (ones[n - 1]);
         } 
         return intToW.ToString ();
      }
      public static string int_to_Roman (long n) {
         string[] roman_symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
         int[] int_value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
         var roman_numerals = new StringBuilder ();
         var index_num = 0;
         while (n != 0) {
            if (n >= int_value[index_num]) {
               n -= int_value[index_num];
               roman_numerals.Append (roman_symbol[index_num]);
            } else
               index_num++;
         } 
         return roman_numerals.ToString ();
      }
   }   
}