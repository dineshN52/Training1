// ----------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Guessing of a number
// Ask the user to guess a number between 1 to 10, 1 to 100 or 1 to 1000 based on selected modes like easy, medium, hard respectively
// For example, in easy mode, machine will generate a random number between 1 to 10 and store it as secret
// If user entered the same random number , output will be "you gueesed correctly in (n) tries", where n is number of tries
// If user entered a number < secret, it displays"your guess is too low" and if number > secret, it displays"Your guess is too high"
// ----------------------------------------------------------------------------------------------------------------------------------
namespace NumberGuess {
   #region Class program-------------------------------------------
   /// <summary>Guess the number</summary>
   internal class Program {
      #region Methods-------------------------------------------------------
      /// <summary>This method asks the user to select mode and enter the guessed number according to mode</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the mode: (E)asy, (M)edium, (H)ard :");
         int max = GetMode ();
         Console.WriteLine ($"\nGuess & Enter the number between 1 and {max}");
         int secret = new Random ().Next (1, max + 1);
         for (int tries = 1; ; tries++) {
            Console.Write (">");
            if (int.TryParse (Console.ReadLine (), out int guess)) {
               var result = Checkguess (secret, guess);
               if (result == EGuess.Exact) {
                  Console.WriteLine ($"you guessed correctly in {tries} tries");
                  break;
               } else
                  Console.WriteLine ($"your guess is too {result}");
            } else
               Console.WriteLine ("Invalid input.Enter an integer value");
         }
         Console.ReadKey ();
      }

      /// <summary>Enumeration class for returning the guessed value</summary>
      enum EGuess { Exact, Low, High };

      /// <summary>Method to select the mode</summary>
      /// <returns>Returns the mode selected by the user</returns>
      static int GetMode () {
         while (true) {
            var keyInfo = Console.ReadKey (intercept: true);
            switch (keyInfo.Key) {
               case ConsoleKey.E:
                  Console.Write ("Easy");
                  return 10;
               case ConsoleKey.M:
                  Console.Write ("Medium");
                  return 100;
               case ConsoleKey.H:
                  Console.Write ("Hard");
                  return 1000;
            }
         }
      }

      /// <summary>Method to check entered number is equivalent to, lower or higher than random number</summary>
      /// <param name="secret"></param>
      /// <param name="guess"></param>
      /// <returns>It returns boolean answer for the guessing with secret number</returns>
      static EGuess Checkguess (int secret, int guess) {
         if (guess == secret) return EGuess.Exact;
         if (guess < secret) return EGuess.Low;
         return EGuess.High;
      }
      #endregion
   }
   #endregion
}
