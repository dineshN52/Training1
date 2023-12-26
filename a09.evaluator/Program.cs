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
            Console.WriteLine (Math.Round (eval.Evaluate (str), 8));
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
