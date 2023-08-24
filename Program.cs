using System;
namespace Numconv {
   internal class Program {
      static void Main (string[] args) {
         Console.WriteLine ("Enter the decimal number:");
         int deci = int.Parse (Console.ReadLine ());
         string hex = Convert.ToString (deci, 16); // Convert to hexadecimal
         string binary = Convert.ToString (deci, 2);// Convert to binary
         Console.WriteLine ($"The Hexadecimal output:{hex}");
         Console.WriteLine ($"The binary output:{binary}");
         Console.ReadKey ();
      }
   }
}