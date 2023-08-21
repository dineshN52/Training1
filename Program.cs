using System;
namespace Prime {
   class Program {
      static bool IsPrime (int b) {
         if (b <= 1)
            return false;
         for (int i = b - 1; i > 1;i--)
            if (b % i == 0)
               return false;
         return true;
      }
      static void Main (string[] args) {
         Console.Write ("Enter a number:");
         int a = int.Parse (Console.ReadLine ());
         if (IsPrime (a))
            Console.WriteLine ($"{a} is a prime number.");
         else
            Console.WriteLine ($"{a} is not a prime number.");
         Console.ReadKey ();
      }
   }
}