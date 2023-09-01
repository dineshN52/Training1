using System.Text;
namespace ReduceString {
   internal class Program {
      static void Main (string[] args) {
         StringBuilder reduced = new StringBuilder ();
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         if (s.Length > 0) {
            reduced.Append (s[0]);
            for (int i = 1; i < s.Length; i++)
               if (s[i] != s[i - 1])
                  reduced.Append (s[i]);
         }
         Console.WriteLine (reduced.ToString ());
         Console.ReadKey ();
      }
   }
}
