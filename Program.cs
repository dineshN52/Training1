﻿// ---------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Guessing of a number
// Ask the user to guess a number between 1 to 10, 1 to 100 or 1 to 1000 based on selected modes like Easy,Medium,Hard respectively
// For example, in Easy mode, machine will generate a random number between 1 to 10 and store it as secret
// If user entered the same random number , output will be "you gueesed correctly in (n) tries".
// If user entered a number < secret,it displays"your guess is too low & if number > secret,it displays"Your guess is too high".
// ---------------------------------------------------------------------------------------------------------------------------------
namespace NumberGuess {
   #region Class program-------------------------------------------
   /// <summary>Guess the number</summary>
   internal class Program {
      #region Methods-------------------------------------------------------
      /// <summary>This function asks the user to selct mode and enter the guessed number according to mode</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter the mode: (E)asy, (M)edium, (H)ard :");
         var mode = GetMode ();
         int max = GetMax (mode);
         Console.WriteLine ($"{mode}\nGuess & Enter the number between 1 and {max}");
         int secret = new Random ().Next (1, max + 1);
         for (int tries = 1; ; tries++) {
            Console.Write (">");
            if (int.TryParse (Console.ReadLine (), out int guess)) {
               var result = Checkguess (secret, guess);
               if (result == Guess.Exact) {
                  Console.WriteLine ($"you guessed correctly in {tries} tries");
                  break;
               } else
                  Console.WriteLine ($"your guess is too {result}");
            } else
               Console.WriteLine ("Invalid input.Enter an integer value");
         }
         Console.ReadKey ();
      }
      /// <summary>Enumeration class for selecting the mode</summary>
      enum Mode { Easy, Medium, Hard };
      /// <summary>Enumeration class for returning the guessed value</summary>
      enum Guess { Exact, Low, High };
      /// <summary>Method to select the mode</summary>
      /// <returns>Returns the mode selected by the user</returns>
      static Mode GetMode () {
         while (true) {
            var keyInfo = Console.ReadKey (intercept: true);
            switch (keyInfo.Key) {
               case ConsoleKey.E: return Mode.Easy;
               case ConsoleKey.M: return Mode.Medium;
               case ConsoleKey.H: return Mode.Hard;
            }
         }
      }
      /// <summary>Method to get maximum value top assign random number for input mode</summary>
      /// <param name="mode"></param>
      /// <returns>Returns the maximum value for respective mode</returns>
      static int GetMax (Mode mode) {
         switch (mode) {
            case Mode.Easy: return 10;
            case Mode.Medium: return 100;
            default: return 1000;
         }
      }
      /// <summary>Method to check entered number is equivalent,lower or higher to random number</summary>
      /// <param name="secret"></param>
      /// <param name="guess"></param>
      /// <returns>It returns boolean answer for the guessing with secret number</returns>
      static Guess Checkguess (int secret, int guess) {
         if (guess == secret) return Guess.Exact;
         if (guess < secret) return Guess.Low;
         return Guess.High;
      }
      #endregion
   }
   #endregion
}
