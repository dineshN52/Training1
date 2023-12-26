namespace Eval;

/// <summary>Custom Evalexception class for the evaluator</summary>
class EvalException : Exception {
   public EvalException (string message) : base (message) { }
}

/// <summary>Evaluator class which holds the evaluate method and basepriority</summary>
class Evaluator {
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
      List<Token> tokens = new ();
      var tokenizer = new Tokenizer (text, this);
      while (true) {
         var token = tokenizer.Next ();
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
      }
      TVariable? Variable = null;
      TUnary? Unary = null;
      ModifyRange (tokens);
      foreach (var t in tokens) Process (t);
      while (mOperators.Count > 0) Applyoperator ();
      double result = mOperands.Pop ();
      if (Unary != null) result = double.Parse (Unary + result.ToString ());
      if (Variable != null) mVar[Variable.Name] = result;
      return result;

      /// <summary>Method whic modify the range of list based on the availability of unary or assignment expression</summary>
      void ModifyRange (List<Token> tokens) {
         if (tokens.Count >= 2 && (tokens[0] is TUnary or TVariable)) {
            switch (tokens[0]) {
               case TUnary unar when tokens.Count >= 2:
                  Unary = unar;
                  tokens.RemoveRange (0, 1);
                  break;
               case TVariable tvariable when tokens[1] is TArithOper { Op: '=' } && tokens.Count >= 3:
                  if (tokens[2] is TUnary unary) {
                     Unary = unary;
                     tokens.RemoveRange (0, 3);
                  } else
                     tokens.RemoveRange (0, 2);
                  Variable = tvariable;
                  break;
            }
         }
      }

      /// <summary>Method which separate and stores the opearors and operands in the individual stacks</summary>
      void Process (Token t) {
         switch (t) {
            case TNumber num:
               mOperands.Push (num.Value); break;
            case TOperator op:
               while (mOperators.Count > 0 && mOperators.Peek ().Priority > op.Priority)
                  Applyoperator ();
               mOperators.Push (op); break;
            case TPunc p:
               BasePriority += p.Punc == '(' ? 10 : -10; break;
         }
      }
   }

   /// <summary>Method to get the value for the corresponding variable which are stored in the dictionary</summary>
   /// <param name="name">Varible name</param>
   /// <returns>Returns the value of the variable</returns>
   /// <exception cref="EvalException">Return exception if the variable is not present in the dictionary</exception>
   public double GetVariable (string name) {
      if (mVar.TryGetValue (name, out double f)) return f;
      throw new EvalException ("Unknown variable");
   }

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
   #endregion
}