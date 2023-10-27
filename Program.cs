// -------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -------------------------------------------------------------------------------------------------------------
// Program.cs
// Number to words and roman numerals
// Ask the user to enter the number and convert it into equivalent english words and roman numerals
// For Example,For user input of 8547: the output produced will be roman numerals:MMMMMMMMDXLVII
// For the same number output produced for words conversion is "Eight Thousand and Five Hundred and Forty Seven"
// -------------------------------------------------------------------------------------------------------------
using System;
using System.Text;
namespace NandR {
   #region Program------------------------------------------------------------------------
   /// <summary>Number to words and roman numerals</summary>
   class Program {
      #region Methods---------------------------------------------------------------------
      /// <summary>Method which gets input from user and passes to other methods which converts numerical value to roman numerals and english words
      /// (According to international numerical system)</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the value: ");
         while (true) {
            if (long.TryParse (Console.ReadLine (), out long n)) {
               Console.WriteLine ($"Original numerical value: {n}\nRoman numerals of the input\n{InttoRoman (n)}");
               Console.WriteLine ($"Input number into words: {ChangeCapital (IntToWords (n))}");
               break;
            } else
               Console.WriteLine ("Invalid input. Please enter an numerical value.");
         }
         Console.ReadKey ();
      }

      /// <summary>This method compares the length of the input numericals 
      /// and pass to differnt methods which can convert the number to equivalent english words</summary>
      /// <param name="n">Input number</param>
      /// <returns>It returns the string of words build by the function equivalent to the number</returns>
      public static string IntToWords (long n) {
         string[] ones = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
         string[] tens = new string[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
         string[] mult = new string[] { "hundred", "thousand", "million", "billion", "trillion" };
         StringBuilder intToW = new ();
         int a = n.ToString ().Length;
         if (a >= 3)
            ConvertNumberToWords (n, mult, intToW);
         else if (a == 2)
            HandleTensAndTeens (n, ones, teens, tens, intToW);
         else
            intToW.Append (ones[n - 1]);
         return intToW.ToString ();
      }

      /// <summary>Method which handle all the number which have length of more than two digits and convert it into words</summary>
      /// <param name="n">Input number</param>
      /// <param name="mult">Array which has words for higher numericals</param>
      /// <param name="intToW">Stringbuilder which holds words for number</param>
      private static void ConvertNumberToWords (long n, string[] mult, StringBuilder intToW) {
         switch (n) {
            case long when n >= 1000000000000:
               long trillions = n / 1000000000000;
               intToW.Append ($"{IntToWords (trillions)} {mult[4]} ");
               n %= 1000000000000;
               break;
            case long when n >= 1000000000:
               long billions = n / 1000000000;
               intToW.Append ($"{IntToWords (billions)} {mult[3]} ");
               n %= 1000000000;
               break;
            case long when n >= 1000000:
               long millions = n / 1000000;
               intToW.Append ($"{IntToWords (millions)} {mult[2]} ");
               n %= 1000000;
               break;
            case long when n >= 1000:
               long thousands = n / 1000;
               intToW.Append ($"{IntToWords (thousands)} {mult[1]} ");
               n %= 1000;
               break;
            default:
               long hundreds = n / 100;
               n %= 100;
               intToW.Append (n == 0 ? $"{IntToWords (hundreds)} {mult[0]}" : $"{IntToWords (hundreds)} {mult[0]} and ");
               break;
         }
         if (n > 0)
            intToW.Append (IntToWords (n));
      }

      /// <summary>This method specifically handle numbers which have only two digits and convert into words</summary>
      /// <param name="n">Input number</param>
      /// <param name="ones">Array which has words for unit digits</param>
      /// <param name="teens">Array which has words for teen numbers</param>
      /// <param name="tens">Array which has words for tens digit</param>
      /// <param name="intToW">string builder which holds words for number</param>
      static void HandleTensAndTeens (long n, string[] ones, string[] teens, string[] tens, StringBuilder intToW) {
         if (n >= 20) {
            int tensDigit = (int)n / 10, onesDigit = (int)n % 10;
            intToW.Append (tens[tensDigit - 1]);
            if (onesDigit > 0)
               intToW.Append ($" {ones[onesDigit - 1]}");
         } else if (n >= 10 && n < 20)
            intToW.Append (teens[n - 10]);
      }

      /// <summary>Method gets a string and change the first character of string to upper</summary>
      /// <param name="s">String in lowercase</param>
      /// <returns>String with first letter alone as upper</returns>
      static string ChangeCapital (string s) {
         char[] letters = s.ToCharArray ();
         letters[0] = char.ToUpper (letters[0]);
         return new string (letters);
      }

      /// <summary>Method converts the input number into equivalent roman numerals with the help of array of roman symbols given</summary>
      /// <param name="n">Input number</param>
      /// <returns>Returns the roman numeral of a number</returns>
      public static string InttoRoman (long n) {
         string[] roman_symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX",
            "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
         int[] int_value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
         StringBuilder roman_numerals = new ();
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
      #endregion 
   }
   #endregion 
}