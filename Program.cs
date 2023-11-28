// --------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Eight Queens problem
// It is a famous problem, where eight queens had to be placed in the chessboard, such that no key collides with each other
// For example, if queen is placed in 'a1' in the board, no queen should be placed in the 'a', '1' and diagonal column in the board
// such placement of eightqueens in the board give one single solution,this program will give both 12 unique and all 92 solution
// Ask the user to press U for unique solution or anyother key for all solution
// Unique solution is defined such that no mirror placements and no rotated(90, 180, 270 degrees) placement
// --------------------------------------------------------------------------------------------------------------------------------
namespace EightQueens {
   #region Class Program---------------------
   /// <summary>Eight Queens problem</summary>
   public class Program {
      #region Methods-----------------------------
      /// <summary>Main method which asks the user to produce unique or all solutions for Eight queens problem</summary>
      public static void Main (string[] args) {
         Console.WriteLine ("Eight Queens problem\nPress 'U' for Unique solution or anyother key for all solution");
         var keyInfo = Console.ReadKey (intercept: true);
         bool unique = false;
         if (keyInfo.Key == ConsoleKey.U)
            unique = true;
         EightQueens (0, unique);
         ChessBoard ();
      }

      /// <summary>Method which produces the solution to Eight queens problem</summary>
      /// <param name="row">Nth row of the chessboard</param>
      public static void EightQueens (int row, bool unique) {
         for (int col = 0; col < 8; col++) {
            if (!IsCollision (row, col)) {
               sol[row] = col;
               var eachSol = sol.ToArray ();
               if (unique ? row == 7 && IsUnique (eachSol) : row == 7) finalSol.Add (eachSol); else EightQueens (row + 1, unique);
            }
         }

         /// <summary>Method to check current queen position is colliding with previous positions</summary>
         /// <param name="row">Row value of queen position</param>
         /// <param name="col">Column value of queen position</param>
         /// <returns>Returns true if it collides with previous position, false otherwise</returns>
         static bool IsCollision (int row, int col) {
            for (int preRow = 0; preRow < row; preRow++) {
               int preCol = sol[preRow];
               if (Math.Abs (col - preCol) == Math.Abs (row - preRow) || col == preCol)
                  return true;
            }
            return false;
         }
      }

      /// <summary>Method checks current solution is a unique solution of all</summary>
      /// <returns>Returns true if current solution is unique, false otherwise</returns>
      static bool IsUnique (int[] sol) => !IsMirror (sol) && !IsRotatedSol (sol);

      /// <summary>Method checks for the presence of mirror solution</summary>
      /// <returns>Returns true, if mirror solution is present, false otherwise</returns>
      static bool IsMirror (int[] a) => IsPresent (a.Reverse ().ToArray ());

      /// <summary>Method checks if the given solution is already present in the total solution list</summary>
      /// <returns>Returns true if solution is present, false otherwise</returns>
      static bool IsPresent (int[] c) => finalSol.Any (a => a.SequenceEqual (c));

      /// <summary>Method check whether rotated solution and mirror of rotated solution is present in the list</summary>
      /// <param name="b">Solution to be checked</param>
      /// <returns>Returns true if rotated and it's mirror image is present in all solution list, false otherwise</returns>
      static bool IsRotatedSol (int[] b) {
         int[] temp = new int[8];
         int[] rotatedArray = new int[8];
         Array.Copy (b, temp, 8);
         for (int i = 0; i < 3; i++) {
            Rotate90 (rotatedArray, temp);
            if (IsPresent (rotatedArray) || IsMirror (rotatedArray))
               return true;
         }
         return false;

         ///<summary>Method to rotate the given solution to 90 degrees</summary>
         static void Rotate90 (int[] rotatedArray, int[] temp) {
            for (int i = 0; i < 8; i++)
               rotatedArray[temp[i]] = 7 - i;
            Array.Copy (rotatedArray, temp, 8);
         }
      }

      /// <summary>Method to print chessboard along with the solution(Either unique or all solution)</summary>
      static void ChessBoard () {
         Console.OutputEncoding = System.Text.Encoding.UTF8;
         for (int i = 0; i < finalSol.Count; i++) {
            Console.CursorLeft = Console.CursorTop = 1;
            Console.WriteLine ($"\nSolution {i + 1} of {finalSol.Count}\n");
            var solution = finalSol[i];
            Console.WriteLine ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int row = 0; row < 8; row++) {
               for (int col = 0; col < 8; col++)
                  Console.Write ($"│ {(col == solution[row] ? "♕" : " ")} ");
               Console.WriteLine ("│");
               if (row < 8 - 1)
                  Console.WriteLine ("├───┼───┼───┼───┼───┼───┼───┼───┤");
            }
            Console.WriteLine ("└───┴───┴───┴───┴───┴───┴───┴───┘");
            Console.ReadKey ();
         }
      }
      #endregion

      #region Private data-------------------------------
      static List<int[]> finalSol = new ();
      static int[] sol = new int[8];
      #endregion
   }
   #endregion
}

