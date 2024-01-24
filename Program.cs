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
         int red, blue, green;
         foreach (string game in dict.Keys) {
            string[] plays = dict[game];
            
            foreach(string play in plays) {
               foreach(string set in plays) {
                  string[] s = set.Split (',');
                  
                  StringBuilder b = new ();
                  Regex r =@(^[0-12])
                  char[] chars = s[0].ToCharArray ();
                  foreach (char c in chars) {
                     if (char.IsDigit (c)) {
                        b.Append (c);
                        
                     }
                  }
               }
               
               
            }
         }
        // string set = dict.TryGetValue (, out string[] value);
      }
   }
}