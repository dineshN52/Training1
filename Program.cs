using System;
namespace multitable {
   class Program {
      static void Main (string[] args) {
         int maxTable = 10, tableSize = 10;
         for (int table = 1; table <= maxTable; table++) {
            for (int multiplier = 1; multiplier <= tableSize; multiplier++) {
               int result = table * multiplier;
               Console.WriteLine ($"{table} * {multiplier} = {result}");
            }
            Console.WriteLine ();
         }
         Console.ReadKey ();
      }
   }
}