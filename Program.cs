// -------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -------------------------------------------------------------------------------------------------------
// Program.cs
// Create console based wordle game
// Game is similar to normal wordle, it should able to show letters in the correct position in green color
// Also should show letters which are not present in the secret word as gray
// And letters which are present and in wrong position as blue color
// And should display no of tries the player used to found the word
// And incase of failure of all tries should display secret word
// -------------------------------------------------------------------------------------------------------
using System.Reflection;
using System.Text;
using static System.Console;

namespace Training {
   #region Class Program---------------------
   internal class Program {
      #region Method-------------
      public static void Main (string[] args) {
         Wordle w = new ();
         SetWindowSize (50, 25);
         w.Initialize ();
         w.Start ();
      }
      #endregion
   }
   #endregion

   #region class Wordle------------------
   public class Wordle {
      #region Methods-------------------------------
      /// <summary>Method to initialize list with custom letters</summary>
      public void Initialize () {
         mLetters.Add (new Tuple<string, EState> ("◌", EState.UNCHECKED));
         for (int count = 0; count < 29; count++)
            mLetters.Add (new Tuple<string, EState> ("·", EState.UNCHECKED));
         for (char c = 'A'; c <= 'Z'; c++)
            mAllLetters[c.ToString ()] = EState.UNCHECKED;
      }

      /// <summary>Method to start the game</summary>
      public void Start () {
         CursorVisible = false;
         string[] words = LoadStrings ("puzzle-5.txt");
         mSecretword = words[new Random ().Next (words.Length)];
         OutputEncoding = Encoding.UTF8;
         DisplayBoard ();
         CheckInput ();
      }

      /// <summary>Method to display the content</summary>
      void DisplayBoard () {
         Clear ();
         AssignColorAndPrint (mLetters);
         WriteLine ("\t---------------------------------");
         var list = mAllLetters.Select (x => new Tuple<string, EState> (x.Key, x.Value)).ToList ();
         AssignColorAndPrint (list);
         WriteLine ("\t---------------------------------");
      }

      /// <summary>Method to assign the console color based on the letter'mString state</summary>
      /// <param name="list">List of letters to be checked status and assign console color</param>
      static void AssignColorAndPrint (List<Tuple<string, EState>> list) {
         int rowValue = 4, colValue = 7; string tabs = "\t"; int i = 0;
         if (list.Count > 26) {
            rowValue = 6; colValue = 5; tabs += "      ";
         }
         for (int row = 0; row < rowValue; row++) {
            Write (tabs);
            for (int col = 0; col < colValue; col++) {
               ForegroundColor = list[i].Item2 switch {
                  EState.CHECKED_AND_CORRECTPOS => ConsoleColor.Green,
                  EState.CHECKED_AND_DIFFPOS => ConsoleColor.Blue,
                  EState.CHECKED_AND_WRONG => ConsoleColor.DarkGray,
                  _ => ConsoleColor.White,
               };
               Write (list[i].Item1 + "    "); i++;
               ResetColor ();
               if (i >= list.Count) break;
            }
            WriteLine ("\n");
         }
      }

      /// <summary>Method which gets the input word from user and checks it is equal to secret</summary>
      void CheckInput () {
         mLimit = 0; int space = 0;
         CursorLeft = 14;
         string[] allWords = LoadStrings ("dict-5.txt");
         for (int tries = 0; tries < 6; tries++) {
            CursorTop = space; CursorLeft = mNotInDict ? 35 : 14;
            mString = mNotInDict ? mString : new StringBuilder ();
            string value = GetInput ();
            mLimit -= 5;
            UpdateGameState (allWords, value, ref tries);
            space = mNotInDict ? space : space + 2;
            DisplayBoard ();
            if (PrintResult (value, tries)) break;
         }
      }

      /// <summary>Method to check current word is the secret word and print result accordingly</summary>
      /// <param name="value">Current input word from user</param>
      /// <param name="tries">Current trial value of user</param>
      /// <returns>Return bool true if the current word is secret, false if not</returns>
      bool PrintResult (string value, int tries) {
         if (value == mSecretword) {
            WriteLine ($"\n\t\t  You win\n\n\tYou found the word in {tries + 1} tries");
            return true;
         }
         if (tries == 5) WriteLine ($"\t    Sorry the word was {mSecretword}");
         if (mNotInDict) WriteLine ($"\t\t{value} IS  NOT A WORD");
         return false;
      }

      /// <summary>Method to upadate state of the each letter according to rules of wordle</summary>
      /// <param name="value">Input word by user</param>
      /// <param name="tries">Current try by the user</param>
      void UpdateGameState (string[] allWords, string value, ref int tries) {
         if (!allWords.Contains (value)) {
            mNotInDict = true; tries--; int end = mLimit < 25 ? 5 : 4;
            mLetters[mLimit + end] = new Tuple<string, EState> ("·", EState.UNCHECKED);
         }
         for (int j = 0; j < value.Length; j++) {
            if (!mNotInDict && mSecretword.Contains (value[j])) {
               if (mSecretword[j] == value[j]) {
                  CheckAllLetters (value[j].ToString (), EState.CHECKED_AND_CORRECTPOS);
                  mLimit++;
                  continue;
               }
               CheckAllLetters (value[j].ToString (), EState.CHECKED_AND_DIFFPOS);
               mLimit++;
               continue;
            }
            CheckAllLetters (value[j].ToString (), mNotInDict ? EState.UNCHECKED : EState.CHECKED_AND_WRONG);
            mLimit++;
         }
      }

      /// <summary>Method to assign the state for the given letter ib both letters list</summary>
      /// <param name="value">Letter to be assigned with state</param>
      /// <param name="st">state to be updated</param>
      void CheckAllLetters (string value, EState st) {
         foreach (var letter in mAllLetters) {
            if (letter.Key == value) {
               mAllLetters[value] = st;
               break;
            }
         }
         mLetters[mLimit] = new Tuple<string, EState> (value, st);
      }

      /// <summary>Method to get whole word as a string</summary>
      /// <returns>Returns the whole word which is given as input</returns>
      string GetInput () {
         for (int i = mNotInDict ? 5 : 0; i < 6; i++) {
            ConsoleKeyInfo key = ReadKey (true);
            Write (char.ToUpper (key.KeyChar));
            switch (key.Key) {
               case ConsoleKey.Enter:
                  if (i == 5) { mNotInDict = false; break; }
                  break;
               case ConsoleKey.Backspace:
                  if (i == 0) {
                     i--; CursorLeft += 1; continue;
                  }
                  HandleBackspace (ref i);
                  break;
               case >= ConsoleKey.A and <= ConsoleKey.Z:
                  HandleAlphabetInput (ref i, key.KeyChar);
                  break;
               default:
                  HandleDefaultInput (ref i);
                  break;
            }
            if (!mNotInDict) UpdateNextState ();
         }
         return mString.ToString ().ToUpper ();
      }

      /// <summary>Method to handle backspace entry</summary>
      void HandleBackspace (ref int i) {
         if (mString.Length > 0) mString.Remove (mString.Length - 1, 1);
         if (i == 5) {
            CursorLeft -= 1; Write (" ");
         } else {
            Write (" ·\b"); CursorLeft -= 5;
         }
         Write ("◌\b");
         i -= 2; mLimit--;
      }

      /// <summary>Method to handle alphabetical inputs</summary>
      /// <param name="keyChar">Console readkey input character</param>
      void HandleAlphabetInput (ref int i, char keyChar) {
         if (i < 5) {
            mString.Append (keyChar); mLimit++;
            if (i < 4) {
               CursorLeft += 4; Write ("◌\b");
            }
         } else {
            i--; Write ("\b \b");
         }
      }

      /// <summary>Method to handle key inputs other than letters, backspace and enter</summary>
      static void HandleDefaultInput (ref int i) {
         if (i < 5) Write ("\b◌");
         else Write ("\b ");
         CursorLeft -= 1; i--;
      }

      /// <summary>Method to update circle at the end to denote next entry</summary>
      void UpdateNextState () {
         if (mLimit is > 0 and < 30) {
            mLetters[mLimit - 1] = new Tuple<string, EState> ("·", EState.UNCHECKED);
            mLetters[mLimit] = new Tuple<string, EState> ("◌", EState.UNCHECKED);
         }
      }

      /// <summary>Methos to load the input dictionary of words</summary>
      /// <param name="file">Dictionary file name</param>
      /// <returns>Returns array of all the words in dictionary</returns>
      string[] LoadStrings (string file) {
         using var stream = Assembly.GetExecutingAssembly ().GetManifestResourceStream ($"Training.Data.{file}");
         using var reader = new StreamReader (stream);
         return reader.ReadToEnd ().Split ("\r\n");
      }
      #endregion

      #region Data------------------
      private int mLimit;
      private bool mNotInDict;
      private string mSecretword = "";
      private StringBuilder mString = new ();
      private List<Tuple<string, EState>> mLetters = new ();
      private Dictionary<string, EState> mAllLetters = new ();
      public enum EState {
         UNCHECKED, CHECKED_AND_CORRECTPOS, CHECKED_AND_DIFFPOS, CHECKED_AND_WRONG
      }
      #endregion
   }
   #endregion
}