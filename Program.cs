using System;
namespace DigitalRoot {
   class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the number: ");
         int a = int.Parse  (Console.ReadLine ());
         Console.WriteLine ($"Digital root of {a} is {Root (a)}");
         Console.ReadKey ();
      }
      static int Root (int n) {
         while (n >= 10) {
            int sum = 0;
            while (n > 0) {
               sum += n % 10; n /= 10;
            }
            n = sum;
         }
         return n;
      }
   }
}
