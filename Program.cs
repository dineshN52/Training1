using system
namespace fibonocci {
   internal class Program {
      public static void Main (string[] args) {
         int n1 = 0, n2 = 1, n3, number;// n1 & n2 were the input, n3 & number were temporary variable
         Console.Write("Enter the number of elements:");
         number = int.Parse (Console.ReadLine ());
         Console.WriteLine(n1 + " " + n2 + " "); //printing 0 and 1    
         for (int i = 2; i < number; ++i) { //loop starts from 2 because 0 and 1 are already printed
            n3 = n1 + n2;
            Console.WriteLine(n3 + " ");
            n1 = n2;
            n2 = n3;
         }
         Console.ReadKey ();
      }
   }
}