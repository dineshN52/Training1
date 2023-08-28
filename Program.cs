using System;
namespace Numconv {
   class Program {
      static void Main (string[] args) {
         Console.WriteLine ("Enter the number");// Convert integer to hexadecimal string
         int intValue = int.Parse (Console.ReadLine ());
         string hexValue = IntToHex (intValue);
         Console.WriteLine ($"Integer {intValue} in hexadecimal: 0x{hexValue}");
         string BiValueFromInt = IntToBi (intValue);
         Console.WriteLine ($"Integer {intValue} as Binary: {BiValueFromInt}");
         Console.ReadKey ();
      }
      static string IntToHex (int value) {
         string hex = "";
         while (value > 0) {
            hex += GetHexDigit (value % 16);
            value /= 16;
         }
         return hex;
      }
      static string IntToBi (int value) {
         string binary = "";
         while (value > 0) {
            binary += (value % 2);
            value /= 2;
         }
         if (binary == "")
            binary = "0";  // Special case for input value 0
         return binary;
      }
      static char GetHexDigit (int value) {
         return value < 10 ? (char)('0' + value) : (char)('A' + (value - 10));
      }
   }
}