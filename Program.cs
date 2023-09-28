//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Training~A training program for new joinees at metamation,Batch-July 2023
//Copyright(c) Metamation India
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Program.cs
//NUMBERS TO WORDS & ROMAN NUMERALS
//Ask the user to enter the number and convert it into equivalent english words and roman numerals
//For Example,For user input of 78563: The output produced will be Roman numerals:MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMDLXIII
//For the same number output produced for words conversion is "Seventy Eight thousand and Five hundred and Sixty Three
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Text;
namespace NandR {
   #region Program------------------------------------------------------------------------
   /// <summary>NUMBER TO WORDS & ROMAN</summary>
   class Program {
      #region Methods---------------------------------------------------------------------
      /// <summary>Method which gets input from user and passes to other methods which converts numerical value to roman numerals and english words(According to international numerical system)</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         long n;
         Console.Write("Enter the value:");
         while (true) {
            if (long.TryParse (Console.ReadLine (), out n)) {
               Console.WriteLine ($"Original numerical value: {n}\nRoman numerals of the input\n{int_to_Roman (n)}");
               Console.WriteLine ($"Input number into words: {IntToWords (n)}");
               break;
            } else
               Console.WriteLine ("Invalid input.Please enter an numerical value.");
         }
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
         if (a >= 3)
            ConvertNumberToWords (n, mult, ones, intToW);
         else if (a == 2)
            HandleTensAndTeens (n, ones, teens, tens, intToW);
         else
            intToW.Append (ones[n - 1]);
         return intToW.ToString ();
      }
      /// <summary>Method which handle all the number which have length of more than two digits and convert it into words</summary>
      /// <param name="n"></param>
      /// <param name="mult"></param>
      /// <param name="intToW"></param>
      private static void ConvertNumberToWords (long n, string[] mult, string[] ones, StringBuilder intToW) {
         switch (n) {
            case long when n >= 1000000000000:
               long trillions = n / 1000000000000;
               intToW.Append (IntToWords (trillions)).Append (" ").Append (mult[6]).Append (" ");
               n %= 1000000000000;
               break;
            case long when n >= 1000000000:
               long billions = n / 1000000000;
               intToW.Append (IntToWords (billions)).Append (" ").Append (mult[5]).Append (" ");
               n %= 1000000000;
               break;
            case long when n >= 1000000:
               long millions = n / 1000000;
               intToW.Append (IntToWords (millions)).Append (" ").Append (mult[4]).Append (" ");
               n %= 1000000;
               break;
            case long when n >= 1000:
               int thousands = (int)n / 1000;
               intToW.Append (IntToWords (thousands)).Append (" ").Append (mult[3]).Append (" and ");
               n %= 1000;
               break;
            default:
               int hundreds = (int)n / 100;
               intToW.Append (ones[hundreds - 1]).Append (" ").Append (mult[2]).Append (" and ");
               n %= 100;
               break;
         }
         if (n > 0) {
            intToW.Append (IntToWords (n)).Append (" ");
         }
      }
      /// <summary>This method specifically handle numbers which have only two digits and convert into words</summary>
      /// <param name="n"></param>
      /// <param name="ones"></param>
      /// <param name="teens"></param>
      /// <param name="tens"></param>
      /// <param name="intToW"></param>
      private static void HandleTensAndTeens (long n , string[] ones, string[] teens, string[] tens, StringBuilder intToW) {
         if (n >= 20) {
            int tensDigit = (int)n / 10, onesDigit = (int)n % 10;
            intToW.Append (tens[tensDigit - 1]);
            if (onesDigit > 0)
               intToW.Append (" ").Append (ones[onesDigit - 1]);
         } else if (n >= 10 && n < 20) {
            intToW.Append (teens[n - 10]);
         }
      }
      /// <summary>This method converts the input number into equivalent roman numerals with the help of array of roman symbols given</summary>
      /// <param name="n"></param>
      /// <returns></returns>
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
      #endregion 
   }
   #endregion 
}