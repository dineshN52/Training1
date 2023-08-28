using System;
namespace chess_board {
   class Program {
      static void Main (string[] args) {
         int boardSize = 8;
         string[,] chessboard = new string[boardSize, boardSize];
         Console.OutputEncoding = System.Text.Encoding.UTF8; // For unicode conversion
         string[] blackPieces = { "♜", "♞", "♝", "♛", "♚", "♝", "♞", "♜" };
         string[] whitePieces = { "♖", "♘", "♗", "♕", "♔", "♗", "♘", "♖" };
         for (int i = 0; i < whitePieces.Length; i++) {
            chessboard[0, i] = whitePieces[i]; // White pieces
            chessboard[7, i] = blackPieces[i]; // Black pieces
         }
         for (int col = 0; col < boardSize; col++) {
            chessboard[6, col] = "♟"; // Black pawns
            chessboard[1, col] = "♙"; // White pawns
            for (int row = 2; row < 6; row++) 
               chessboard[row, col] = "\u00a0"; // Empty square      
         }
         Console.WriteLine ();
         for (int i = 0; i < 8; i++) {
            Console.Write (i == 0 ? "\u250c\u2500\u2500\u2500" : "\u252c\u2500\u2500\u2500");
         }
         Console.WriteLine ("\u2510");
         for (int row = 0; row < boardSize; row++) {
            Console.Write ("\u2502");
            for (int col = 0; col < boardSize; col++) {
               Console.Write ($" {chessboard[row, col]} \u2502");
            }
            Console.WriteLine ();
            if (row < boardSize - 1) {
               Console.Write ("\u251c");
               for (int col = 0; col < boardSize; col++) {
                  Console.Write ("\u2500\u2500\u2500");
                  if (col < boardSize - 1) 
                     Console.Write ("\u253c");                 
               }
               Console.WriteLine ("\u2524");
            }
         }
         for (int i = 0; i < 8; i++) {
            Console.Write (i == 0 ? "\u2514\u2500\u2500\u2500" : "\u2534\u2500\u2500\u2500");
         }
         Console.WriteLine ("\u2518");
         Console.ReadKey ();
      }
   }
}