using System.Text;
using System.Text.RegularExpressions;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         var inputlist = File.ReadAllLines ("C:\\dineshn\\input.txt");
         List<int> CorrectSlns = new (); int i = 1;
         foreach (string input in inputlist) {
            string[] games = input.Split (':');
            string[] sets = games[1].Split (';');
            if (TryCalculateRGB (sets))
               CorrectSlns.Add (i);
            i++;
         }
         CorrectSlns.Sort ();
         Console.WriteLine ($"Sum of all valid games:{CorrectSlns.Sum ()}");
      }
      public static bool TryCalculateRGB (string[] plays) {
         int j = 0, R, G, B;
         foreach (string set in plays) {
            R = 0; G = 0; B = 0;
            string[] s = set.Split (',');
            Regex re = new (@"\b([0-9]|1[0-9])\s+red\b");
            Regex gr = new (@"\b([0-9]|1[0-9])\s+green\b");
            Regex bl = new (@"\b([0-9]|1[0-9])\s+blue\b");
            for (int i = 0; i < s.Length; i++) {
               if (re.IsMatch (s[i])) R = ConvertInt (s[i]);
               if (gr.IsMatch (s[i])) G = ConvertInt (s[i]);
               if (bl.IsMatch (s[i])) B = ConvertInt (s[i]);
               if (R > 12 || G > 13 || B > 14) return false;
            }
            j++;
         }
         return true;
      }
      static int ConvertInt (string sr) {
         StringBuilder b = new ();
         char[] chars = sr.ToCharArray ();
         foreach (char c in chars) {
            if (char.IsDigit (c))
               b.Append (c);
         }
         return int.Parse (b.ToString ());
      }
   }
}