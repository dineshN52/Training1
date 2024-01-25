
using System.Text;
using System.Text.RegularExpressions;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         var inputlist = File.ReadAllLines ("C:\\dineshn\\input.txt");
         Dictionary<string, int[]> dict = new ();
         foreach (string input in inputlist) {
            string[] games = input.Split (':');
            string[] sets = games[1].Split (';');
            dict.Add (games[0], CalculateRGB(sets));
         }
      }
      public static int[] CalculateRGB (string[] plays) {
         int[] red = new int[10], blue = new int[10], green = new int[10];
         int j = 0;
         foreach (string set in plays) {                
            string[] s = set.Split (',');
            StringBuilder b = new ();
            StringBuilder r = new ();
            StringBuilder g = new ();
            int ag = b.Length > 0 ? int.Parse (b.ToString ()) : 0;
            Regex re = new Regex (@"\b([0-9]|1[0-5])\s+red\b");
            Regex gr = new Regex (@"\b([0-9]|1[0-5])\s+green\b");
            Regex bl = new Regex (@"\b([0-9]|1[0-5])\s+blue\b");
            for (int i = 0; i < s.Length; i++) {            
               if (re.IsMatch (s[i])) {
                  char[] chars = s[i].ToCharArray ();
                  foreach (char c in chars) {
                     if (char.IsDigit (c))
                        r.Append (c);
                  }
               }
               if (gr.IsMatch (s[i])) {
                  char[] chars = s[i].ToCharArray ();
                  foreach (char c in chars) {
                     if (char.IsDigit (c))
                        g.Append (c);
                  }
               }
               if (bl.IsMatch (s[i])) {
                  char[] chars = s[i].ToCharArray ();
                  foreach (char c in chars) {
                     if (char.IsDigit (c))
                        b.Append (c);
                  }
               }
               if (r.Length > 0)
                  red[j] = int.Parse (r.ToString ());
               if (g.Length > 0)
                  green[j] = int.Parse (g.ToString ());
               if (b.Length > 0)
                  blue[j] = int.Parse (b.ToString ());
            }
            if()
            j++;
         }
         int finalRed = red.Sum (), finalGreen = green.Sum (), finalBlue = blue.Sum ();
         return new int[] { finalRed, finalGreen, finalBlue };
      }
   }
}