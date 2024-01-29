using System.Text;
using System.Text.RegularExpressions;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         var inputlist = File.ReadAllLines ("C:\\dineshn\\input.txt");
         Dictionary<string, int[]> dict = new ();
         int[] CorrectSlns = new int[100];int i = 0;
         foreach (string input in inputlist) {
            string[] games = input.Split (':');
            string[] sets = games[1].Split (';');        
            if (TryCalculateRGB(sets,out int[] f)) {
               StringBuilder game = new ();
               dict.Add (games[0], f);
               char[] chars = games[0].ToCharArray ();
               foreach (char c in chars) {
                  if (char.IsDigit (c))
                     game.Append (c);
               }
               CorrectSlns[i]=int.Parse (game.ToString());     
            }
            i++;
         }
         Console.WriteLine ($"Sum of all valid games:{CorrectSlns.Sum()}");
      }
      public static bool  TryCalculateRGB (string[] plays, out int[] f) {
         f = new int[3];
         int[] red = new int[10], blue = new int[10], green = new int[10];
         int j = 0;
         foreach (string set in plays) {                
            string[] s = set.Split (',');
            StringBuilder b = new ();
            StringBuilder r = new ();
            StringBuilder g = new ();
            Regex re = new (@"\b([0-9]|1[0-9])\s+red\b");
            Regex gr = new (@"\b([0-9]|1[0-9])\s+green\b");
            Regex bl = new (@"\b([0-9]|1[0-9])\s+blue\b");
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
               if (r.Length >0)
                  
                  red[j] = int.Parse (r.ToString ());
               if (g.Length > 0)
                  green[j] = int.Parse (g.ToString ());
               if (b.Length > 0)
                  blue[j] = int.Parse (b.ToString ());
            }
            j++;
         }
         bool finalRed = !red.Any (a => a > 12), finalGreen = !green.Any (b => b > 13), finalBlue = !blue.Any (c => c > 14);
         if(finalRed && finalGreen && finalBlue) {
            f=new int[]{ red.Sum(),green.Sum (), blue.Sum() };
            return true;
         }     
         return false;
      }
   }
}