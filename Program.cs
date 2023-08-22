using System;
using System.Runtime.CompilerServices;
namespace LCMGCD {
   internal class Program {
      static int Gcd (int a, int b) {
         while (b != 0) {
            int temp = b;
            b = a % b; a = temp;
         }
         return a;
      }
      static int Lcm (int a, int b) {
         return (a * b) / Gcd (a, b);
      }
      static void Main (string[] args) {
         Console.WriteLine ("Enter the first number");
         int num1 = int.Parse (Console.ReadLine ());
         if (num1 <= 0)
            Console.WriteLine ("Enter a Positive integer");
         Console.WriteLine ("Enter the other number");
         int num2 = int.Parse (Console.ReadLine ());
         if (num2 <= 0)
            Console.WriteLine ("Enter a Positive integer");
         Console.WriteLine ($"LCM of {num1} and {num2} is {Lcm (num1, num2)}");
         Console.WriteLine ($"GCD of {num1} and {num2} is {Gcd (num1, num2)}");
         Console.ReadKey ();
      }
   }
}
