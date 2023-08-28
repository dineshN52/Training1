using System;
using System.ComponentModel;
using System.Text;
namespace chess_board {
   class Program {
      static void Main (string[] args) {
         int boardSize = 8;
         string[,] chessboard = new string[boardSize, boardSize];
         Console.OutputEncoding = System.Text.Encoding.UTF8; // For unicode conversion
         for (int row = 0; row < boardSize; row++) {
            for (int col = 0; col < boardSize; col++)
               Console.Write ($"{chessboard[row, col]} ");
         }
         string[] whitePieces = { "\u2656", "\u2658", "\u2657", "\u2655", "\u2654", "\u2656", "\u2658", "\u2657" };
         string[] blackPieces = { "\u265c", "\u265e", "\u265d", "\u265b", "\u265a", "\u265c", "\u265e", "\u265d" };
         for (int i = 0; i < whitePieces.Length; i++) {
            chessboard[0, i] = whitePieces[i]; // White pieces
            chessboard[7, i] = blackPieces[i]; // Black pieces
         }
         for (int col = 0; col < boardSize; col++) {
            chessboard[1, col] = "\u2659"; // Black pawns
            chessboard[6, col] = "\u265f"; // White pawns
            for (int row = 2; row < 6; row++) 
               chessboard[row, col] = "\u00a0"; // Empty square      
         }
         Console.WriteLine ();
         for (int i = 0; i < 8; i++) {
            Console.Write (i == 0 ? "\u250c" : "\u252c");
            Console.Write ("\u2500\u2500\u2500");
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
            Console.Write (i == 0 ? "\u2514" : "\u2534");
            Console.Write ("\u2500\u2500\u2500");
         }
         Console.WriteLine ("\u2518");
         Console.ReadKey ();
      }
   }
}