using System;
namespace Prime {
   class Program {
      static bool IsPrime (int b) {
         if (b <= 1)
            return false;
         for (int i = 2; i * i <= b; i++) 
            if (b % i == 0) 
               return false;
         return true;
      }
      static void Main (string[] args) {
         Console.Write ("Enter a number:");
         int a = int.Parse (Console.ReadLine ());
         Console.WriteLine (string.Concat ($"{a} is" , IsPrime (a) ? " a prime number" : " not a prime number"));
         Console.ReadKey ();
      }
   }
}