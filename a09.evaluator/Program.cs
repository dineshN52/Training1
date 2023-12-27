// ---------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ---------------------------------------------------------------------------------------------------------------
// Program.cs
// Unary evaluator
// An expression evaluator which handles both binary and unary operations
// For example,the eval.Evaluate method in class Evaluator produce "-1" as output for input string "-tan45"
// And it also handles variable assignment like for string "a=log0" it assigns log0 that is 0 to the variable a
// It throws exception for unknown arithmetic operators, function and incomplete expression whenever necessary
// ---------------------------------------------------------------------------------------------------------------
namespace Eval;

#region Program-------------------------
/// <summary>Unary Expression evaluator</summary>
class Program {
   #region Methods--------------------
   /// <summary>Main method which calls the evaluator class to evaluate the input string</summary>
   /// <param name="args"></param>
   static void Main (string[] args) {
      Evaluator eval = new ();
      Console.WriteLine ("Enter any mathematical expression\nPress enter without input to Escape");
      while (true) {
         Console.Write ('>');
         string str = Console.ReadLine ().Trim ().ToLower ();
         if (str == "") break;
         try {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine (eval.Evaluate (str));
         } catch (Exception e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine (e.Message);
         }
         Console.ResetColor ();
      }
   }
   #endregion
}
#endregion
