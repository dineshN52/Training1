using System;
using System.Runtime.CompilerServices;
namespace LCMGCD {
   internal class Program {
      static int gcd (int a, int b) {
         while (b != 0) {
            int temp = b;
            b = a % b; a = temp;
         }
         return a;
      }
      static int lcm (int a, int b) {
         return (a * b) / gcd (a, b);
      }
      static void Main (string[] args) {
         Console.WriteLine ("Enter the first number");
         int num1 = int.Parse (Console.ReadLine ());
         if (num1 <= 0) {
            Console.WriteLine ("Enter a Positive integer");
         }
         Console.WriteLine ("Enter the other number");
         int num2 = int.Parse (Console.ReadLine ());
         if (num2 <= 0) {
            Console.WriteLine ("Enter a Positive integer");
         }
         int LCM = lcm (num1, num2);
         int GCD = gcd (num1, num2);
         Console.WriteLine ($"LCM of {num1} and {num2} is {LCM}");
         Console.WriteLine ($"GCD of {num1} and {num2} is {GCD}");
         Console.ReadKey ();
      }
   }
}
