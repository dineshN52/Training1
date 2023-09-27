using System;
using System.Text;
namespace NandR {
   /// <summary>NUMBER TO WORDS & ROMAN</summary>
   class Program {
      /// <summary>Method which gets input from user and passes to other methods which converts numerical value to roman numerals and english words(According to international numerical system)</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         long n;
         Console.Write ("Enter the number: ");
         n = long.Parse (Console.ReadLine ());
         Console.WriteLine ("Original numerical value: " + n);
         Console.WriteLine ("Roman numerals of the given number:");
         Console.WriteLine (int_to_Roman (n));
         Console.WriteLine ("Number into words:");
         Console.WriteLine (IntToWords (n));
         Console.ReadKey ();
      }
      /// <summary>This method compares the length of the input numericals and pass to differnt methods which can convert the number to equivalent english words</summary>
      /// <param name="n"></param>
      /// <returns>It returns the string of words build by the function equivalent to the number</returns>
      public static string IntToWords (long n) {
         string[] ones = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
         string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
         string[] tens = new string[] { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
         string[] mult = new string[] { "zero", "Ten", "Hundred", "Thousand", "Million", "Billion", "Trillion" };
         StringBuilder intToW = new ();
         int a = n.ToString ().Length;
         if (a >= 13) {
            HandleTrillion (n, mult, intToW);
         } else if (a >= 10) {
            HandleBillion (n, mult, intToW);
         } else if (a >= 7) {
            HandleMillion (n, mult, intToW);
         } else if (a >= 4) {
            HandleThousand (n, mult, intToW);
         } else if (a == 3) {
            HandleHundreds (n, intToW, ones, mult[2]);
         } else if (a == 2) {
            HandleTensAndTeens (n, intToW, ones, teens, tens);
         } else if (a == 1) {
            intToW.Append (ones[n - 1]);
         }
         return intToW.ToString ();
      }
      /// <summary>
      /// Function which specifically add 
      /// </summary>
      /// <param name="n"></param>
      /// <param name="mult"></param>
      /// <param name="intToW"></param>
      private static void HandleTrillion (long n, string[] mult, StringBuilder intToW) {
         long trillions = n / 1000000000000;
         intToW.Append (IntToWords (trillions)).Append (" ").Append (mult[6]).Append (" ");
         n %= 1000000000000;
         if (n > 0)
            intToW.Append (IntToWords (n)).Append (" ");
      }
      private static void HandleBillion (long n, string[] mult, StringBuilder intToW) {
         long billions = n / 1000000000;
         intToW.Append (IntToWords (billions)).Append (" ").Append (mult[5]).Append (" ");
         n %= 1000000000;
         if (n > 0)
            intToW.Append (IntToWords (n)).Append (" ").Append (" ");
      }
      private static void HandleMillion (long n, string[] mult, StringBuilder intToW) {
         long millions = n / 1000000;
         intToW.Append (IntToWords (millions)).Append (" ").Append (mult[4]).Append (" ");
         n %= 1000000;
         if (n > 0)
            intToW.Append (IntToWords (n)).Append (" ");
      }
      private static void HandleThousand (long n, string[] mult, StringBuilder intToW) {
         int thousands = (int)n / 1000;
         intToW.Append (IntToWords (thousands)).Append (" ").Append (mult[3]).Append (" ");
         n %= 1000;
         if (n > 0)
            intToW.Append ("and ").Append (IntToWords (n));
      }
      private static void HandleHundreds (long n, StringBuilder intToW, string[] ones, string hundred) {
         int hundreds = (int)n / 100;
         intToW.Append (ones[hundreds - 1]).Append (" ").Append (hundred).Append (" ");
         n %= 100;
         if (n > 0)
            intToW.Append (" and ").Append (IntToWords (n));
      }
      private static void HandleTensAndTeens (long n, StringBuilder intToW, string[] ones, string[] teens, string[] tens) {
         if (n >= 20) {
            int tensDigit = (int)n / 10, onesDigit = (int)n % 10;
            intToW.Append (tens[tensDigit - 1]);
            if (onesDigit > 0)
               intToW.Append (" ").Append (ones[onesDigit - 1]);
         } else if (n >= 10 && n < 20) {
            intToW.Append (teens[n - 10]);
         }
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