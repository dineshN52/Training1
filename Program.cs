using System;
namespace multitable {
   class Program {
      static void Main (string[] args) {
         int maxT = 10, Size = 10;
         for (int table = 1; table <= maxT; table++) {
            for (int a = 1; a <= Size; a ++) {
               int r = table * a;
               Console.WriteLine ($"{table} * {a} = {r}");
            }
            Console.WriteLine ();
         }
         Console.ReadKey ();
      }
   }
}