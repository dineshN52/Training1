// ------------------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ------------------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Guessing an assumed number
// Ask the user to Assume a number between 0 to 127.
// Again ask the user to guess the number from MSB or LSB
// If MSB, it invokes GuessMSB method, if LSB it invokes GuessLSB method
// In both method user have to answer series of yes or no questions, based on the answers the machine will output the assumed number by user.
// ------------------------------------------------------------------------------------------------------------------------------------------
using System;
namespace Guessnum {
   #region Class Program-----------------------------
   /// <summary>Guessing an assumed number</summary>
   internal class Program {
      #region Methods----------------------------------
      /// <summary>Method to guess the assumed number</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Welcome to the Number Guessing Game!\nAssume a number between 0 to 127.");
         int bitcount = 7;
         Console.Write ("Guess from (M)SB or (L)SB: ");
         while (true) {
            var feedback = Console.ReadKey ().Key;
            if (feedback == ConsoleKey.M) {
               Console.WriteLine ("\nMachine will guess the binary value of assumed number from MSB.");
               GuessMSB (bitcount);
               break;
            } else if (feedback == ConsoleKey.L) {
               Console.WriteLine ("\nMachine will guess the binary value of assumed number from LSB.");
               GuessLSB (bitcount);
               break;
            } else
               Console.Write ("\nInvalid input. Press M or L: ");
         }
      }

      /// <summary>Method which guess the number in binary from MSB</summary>
      /// <param name="result">Array to hold binary digits of number</param>
      /// <param name="bitcount">Number of binary digits based on mode</param>
      /// <param name="max">Maximum limit of number in each mode</param>
      static void GuessMSB (int bitcount) {
         int[] result = new int[bitcount];
         int min = 0, max = 127;
         while (bitcount > 0) {
            int machineGuess = (min + max + 1) / 2;
            Console.Write ($"\nMachine guess: {machineGuess}" +
                "\nIs your number Lower than machine guess (Y)es or (N)o? ");
            while (true) {
               var feedback = Console.ReadKey ().Key;
               if (feedback == ConsoleKey.Y) {
                  max = machineGuess;
                  result[bitcount - 1] = 0;
                  break;
               } else if (feedback == ConsoleKey.N) {
                  min = machineGuess;
                  result[bitcount - 1] = 1;
                  break;
               } else
                  Console.Write ("\nInvalid input, Please use (Y)es, (N)o for the feedback: ");
            }
            bitcount--;
         }
         Array.Reverse (result);
         int answer = Convert.ToInt32 (string.Join ("", result), 2);
         Console.WriteLine ($"\nThe assumed number by user is {answer}");
      }

      /// <summary>Method which guess the number by questions from LSB</summary>
      /// <param name="result">An integer array to hold binary digits of number</param>
      /// <param name="bitcount">Number of binary digits based on mode</param>
      static void GuessLSB (int bitcount) {
         int[] result = new int[bitcount];
         int dividend = 2, remainder = 0, count = 0;
         while (bitcount > 0) {
            Console.Write ($"\nIs the number divided by {dividend} the remainder {remainder}: (Y)es or (N)o: ");
            while (true) {
               var feed = Console.ReadKey ().Key;
               if (feed == ConsoleKey.Y) {
                  result[bitcount - 1] = 0;
                  break;
               } else if (feed == ConsoleKey.N) {
                  result[bitcount - 1] = 1;
                  remainder += (int)Math.Pow (2, count);
                  break;
               } else
                  Console.Write ("\nInvalid input. Please use (Y)es, (N)o for the feedback: ");
            }
            bitcount--;
            dividend *= 2;
            count++;
         }
         Console.WriteLine ($"\nThe assumed number by the user is {Convert.ToInt32 (string.Join ("", result), 2)}");
      }
      #endregion
   }
   #endregion
}

