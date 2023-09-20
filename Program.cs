using System;
using System.Text.RegularExpressions;
class Program {
   static void Main (string[] args) {
      string[] words = { "Aegilops", "Aim@", "3Bill", "Lilly" };
      string longestAbecedarianWord = FindLongestAbecedarian (words);
      Console.WriteLine (string.IsNullOrEmpty (longestAbecedarianWord) ? "No abecedarian word found." : $"The longest abecedarian word is: {longestAbecedarianWord}");
   }
   static bool IsValidInput (string input) {
      string pattern = "^[a-zA-Z]"; // Regular expression pattern to match only alphabetical characters
      return Regex.IsMatch (input, pattern);
   }
   static bool IsAbecedarian (string word) {
      word = word.ToLower (); // Convert the word to lowercase to handle both uppercase and lowercase letters
      for (int i = 1; i < word.Length; i++) {
         if (word[i] < word[i - 1])
            return false; // If any letter is out of order, it's not abecedarian           
      }
      return true;
   }
   static string FindLongestAbecedarian (string[] words) {
      string longestAbecedarianWord = "";
      foreach (string word in words) {
         if (IsValidInput (word) && IsAbecedarian (word)) {
            if (word.Length > longestAbecedarianWord.Length)
               longestAbecedarianWord = word;
         }
      }
      return longestAbecedarianWord;
   }
}
