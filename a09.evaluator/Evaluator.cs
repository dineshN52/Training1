namespace Eval;

#region Classes----------------------------
/// <summary>Custom Evalexception class for the evaluator</summary>
public class EvalException : Exception {
   public EvalException (string message) : base (message) { }
}

/// <summary>Evaluator class which holds the evaluate method and basepriority</summary>
public class Evaluator {
   #region Constructor-----------
   public Evaluator () {
      BasePriority = 0;
   }
   #endregion

   #region Properties-----------
   public int BasePriority { get; set; }
   #endregion

   #region Methods-------------------------
   /// <summary>Method evaluates the input string and give result of the input mathematical expression or function</summary>
   /// <param name="text">Input mathematical expression</param>
   /// <returns>Return the output value</returns>
   /// <exception cref="EvalException">Returns an exception if the expression is incorrect</exception>
   public double Evaluate (string text) {
      var tokenizer = new Tokenizer (text, this);
      tokens.Clear ();
      while (true) {
         var token = tokenizer.Next ();
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
      }
      TVariable? Variable = null;
      List<TUnary> Unaries = new ();
      TFuncOper? Func = null;
      TArithOper? arith = null;
      ModifyRange (tokens);
      foreach (var t in tokens) Process (t);
      while (mOperators.Count > 0) Applyoperator ();
      double result = mOperands.Pop ();
      if (Unaries.Count != 0) {
         for (int i = 0; i < Unaries.Count; i++)
            result = double.Parse (Unaries[^1] + "1") * result;
      }
      if (Variable != null) mVar[Variable.Name] = result;
      if (Func != null) result = Func.ApplyFunc (result);
      return Math.Round (result, 5);

      /// <summary>Method which modify the range of list based on the availability of unary or assignment expression</summary>
      void ModifyRange (List<Token> tokens) {
         int c = tokens.Count, l = c - 1;
         if (c >= 2 && (tokens.Any (x => x is TUnary or TVariable))) {
            foreach (Token token in tokens) {
               switch (token) {
                  case TUnary unar when c >= 2:
                     if (tokens.IndexOf (unar) > 0) {
                        if (this.GetPreviousToken (token) is TArithOper { Op: '-' } or TArithOper { Op: '+' }) break;
                     }
                     Unaries.Add (unar);
                     break;
                  case TVariable tvariable when c >= 3 && tokens[1] is TArithOper { Op: '=' }:
                     Variable = tvariable;
                     break;
                  case TArithOper { Op: '=' } ar:
                     arith = ar;
                     break;
                  case TFuncOper func when c >= 3 && tokens[1] is TUnary or TVariable:
                     Func = func;
                     break;
               }
            }
            if (Unaries.Count != 0) {
               foreach (var unar in Unaries)
                  tokens.Remove (unar);
            }
            if (Variable != null) tokens.Remove (Variable);
            if (Func != null) tokens.Remove (Func);
            if (arith != null) tokens.Remove (arith);
         }
      }

      /// <summary>Method which separate and stores the opearors and operands in the individual stacks</summary>
      void Process (Token t) {
         switch (t) {
            case TNumber num:
               if (tokens.IndexOf (num) > 0) {
                  if (tokens.Count >= 2 && this.GetPreviousToken (num) is TUnary un) {
                     Evaluator evals = new ();
                     mOperands.Push (evals.Evaluate (un + num.Value.ToString ()));
                  } else
                     mOperands.Push (num.Value);
               } else
                  mOperands.Push (num.Value);
               break;
            case TOperator op:
               while (mOperators.Count > 0 && mOperators.Peek ().Priority > op.Priority)
                  Applyoperator ();
               if (op is TUnary) break;
               mOperators.Push (op);
               break;
            case TPunc p:
               BasePriority += p.Punc == '(' ? 10 : -10; break;
         }
      }
   }

   /// <summary>Method to get the previous token in the token list</summary>
   /// <param name="token">Input token whose previous token to be found</param>
   /// <returns>Returns the previous token in the token list</returns>
   public Token GetPreviousToken (Token token) => tokens[tokens.IndexOf (token) - 1];

   /// <summary>Method to return the last token in the tokens list</summary>
   public Token GetLastToken () => tokens[^1];
   
   /// <summary>Method to get the value for the corresponding variable which are stored in the dictionary</summary>
   /// <param name="name">Varible name</param>
   /// <returns>Returns the value of the variable</returns>
   /// <exception cref="EvalException">Return exception if the variable is not present in the dictionary</exception>
   public double GetVariable (string name) => mVar.TryGetValue (name, out double f) ? f : throw new EvalException ("Unknown variable");

   /// <summary>Method which evokes the actual mathematical operation between the two operands and returns the result of operation</summary>
   /// <exception cref="EvalException">Return exception if input expression is wrong</exception>
   void Applyoperator () {
      var element1 = mOperands.Pop ();
      var Operator = mOperators.Pop ();
      if (Operator is TFuncOper func) mOperands.Push (func.ApplyFunc (element1));
      else if (Operator is TArithOper arith) {
         if (mOperands.Count > 0) {
            var element2 = mOperands.Pop ();
            mOperands.Push (arith.ApplyFunc (element2, element1));
         } else
            throw new EvalException ("Insufficient operands");
      }
   }
   #endregion

   #region Private data-------------------
   readonly Stack<double> mOperands = new ();
   readonly Stack<TOperator> mOperators = new ();
   readonly Dictionary<string, double> mVar = new ();
   List<Token> tokens = new ();
   #endregion
}
#endregion