using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         var inputlist = File.ReadAllLines ("C:\\dineshn\\input.txt");
         Dictionary<string, string[]> dict = new ();
         foreach (string input in inputlist) {
            string[] games = input.Split (':');
            string[] sets = games[1].Split (';');
            dict.Add (games[0], sets);
            Calculate (dict);
         }
      }
      static void Calculate(Dictionary <string ,string[]> dict) {
        
         foreach (string game in dict.Keys) {
            int red, blue, green;
            string[] plays = dict[game];  
            foreach(string play in plays) {
               foreach(string set in plays) {
                  string[] s = set.Split (',');
                  StringBuilder b = new ();
                  StringBuilder r = new ();
                  StringBuilder g = new ();
                  Regex re = new Regex ("@(^[0 - 12{2} red$])");
                  Regex gr = new Regex ("@(^[0 - 13{2} green$])");
                  Regex bl = new Regex ("@(^[0 - 14{2} blue$])");
                  for (int i = 0; i < s.Length; i++) {
                     if (re.IsMatch (s[i])) {
                        char[] chars = s[i].ToCharArray ();
                        foreach (char c in chars) {
                           if (char.IsDigit (c))
                              r.Append (c);
                        }
                     }
                     if(gr.IsMatch (s[i])) {
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
                        red = int.Parse (r.ToString ());
                     if (g.Length > 0)
                        green = int.Parse (g.ToString ());
                     if (b.Length > 0)
                        blue = int.Parse (b.ToString ());
                  }    
               }
            }
         }
      }
   }
}