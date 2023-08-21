using System;
namespace Training {
   namespace Prime {
      class Program {
         static bool IsPrime (int num) {
            if (num <= 1)
               return false;
            else if (num == 2 & num == 3)
               return true;
            for (int i = num - 1; i > 1; i--) {
               if (num % i == 0)
                  return false;
            }
            return true;
         }
         static void Main (string[] args) {
            Console.Write ("Enter a number: ");
            int number = int.Parse (Console.ReadLine ());

            if (IsPrime (number))
               Console.WriteLine ($"{number} is a prime number.");
            else
               Console.WriteLine ($"{number} is not a prime number.");
         }
      }
   }
}