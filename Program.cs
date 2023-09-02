namespace Isogram {
   internal class Program {
      static void Main (string[] args) {
         Console.Write ("Enter the string: ");
         string s = Console.ReadLine ();
         Console.WriteLine (IsIsogram (s) ? "It is an isogram" : "It is not an isogram");
         Console.ReadKey ();
      }
      static bool IsIsogram (string s) {
         HashSet<char> seenCharacters = new HashSet<char> ();
         foreach (char c in s) {
            if (seenCharacters.Contains (c))
               return false;
            seenCharacters.Add (c);
         }
         return true;
      }
   }
}