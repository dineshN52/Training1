namespace Eval;

#region Classes-------------------------------
/// <summary>Base class token where each type of token can be inherited</summary>
abstract class Token { }

/// <summary>Class which inherits token class and has a property called value</summary>
abstract class TNumber : Token {
   public abstract double Value { get; }
}

/// <summary>CLass which inherits the TNumber class and overrides only the double value and it reprsents a numerical value</summary>
class TLiteral : TNumber {
   public TLiteral (double f) => mValue = f;
   public override double Value => mValue;
   public override string ToString () => $"{Value}";
   readonly double mValue;
}

/// <summary>Class which inherits TNumber and it has one more property called name which is used to decribe the variable name</summary>
class TVariable : TNumber {
   public TVariable (Evaluator eval, string name) => (mEval, Name) = (eval, name);
   public string Name { get; private set; }
   public override double Value => mEval.GetVariable (Name);
   readonly Evaluator mEval;
}

/// <summary>Class which inherits Token and has additional property called priority</summary>
abstract class TOperator : Token {
   protected TOperator (Evaluator eval) => mEval = eval;
   public abstract int Priority { get; }
   readonly protected Evaluator mEval;
}

/// <summary>Class which inherits TOperator, which majorly targets the arithemtic operation signs and assigns it priority</summary>
class TArithOper : TOperator {
   public TArithOper (Evaluator eval, char ch) : base (eval) => Op = ch;
   public char Op { get; private set; }
   public override int Priority => cPriority[Op] + mEval.BasePriority;

   /// <summary>Method to apply the arithmetic operation between two operands based on input operator</summary>
   /// <returns>Result of the operation between operands</returns>
   /// <exception cref="EvalException">If input character doesn't matches any opearator it throws the exception</exception>
   public double ApplyFunc (double f1, double f2) {
      return Op switch {
         '+' => f1 + f2,
         '-' => f1 - f2,
         '*' => f1 * f2,
         '/' => f1 / f2,
         '^' => Math.Pow (f1, f2),
         _ => throw new EvalException ("Unknown operator")
      };
   }
   readonly Dictionary<char, int> cPriority = new () { ['+'] = 1, ['-'] = 1, ['*'] = 2, ['/'] = 2, ['^'] = 3, ['='] = 4 };
}

/// <summary>Class which inherits TOperator,which targets all functions other than arithmetic signs and overides the priority</summary>
class TFuncOper : TOperator {
   public TFuncOper (Evaluator eval, string name) : base (eval) => Func = name;
   public string Func { get; private set; }
   public override string ToString () => $"{Func} : {Priority}";
   public override int Priority => 4 + mEval.BasePriority;

   /// <summary>Method to apply non arithmetic function over the given operand</summary>
   /// <returns>Returns result of function</returns>
   /// <exception cref="EvalException">If the keyword doesn't match with any non-arithemtic function thrwos exception</exception>
   public double ApplyFunc (double f) {
      return Func switch {
         "sin" => Math.Sin (Deg2Rad (f)),
         "cos" => Math.Cos (Deg2Rad (f)),
         "tan" => Math.Tan (Deg2Rad (f)),
         "sqrt" => Math.Sqrt (f),
         "exp" => Math.Exp (f),
         "log" => Math.Log (f),
         "asin" => Rad2Deg (Math.Asin (f)),
         "acos" => Rad2Deg (Math.Acos (f)),
         "atan" => Rad2Deg (Math.Atan (f)),
         _ => throw new EvalException ("Incorrect function name")
      };
   }

   /// <summary>Method to convert given degree value to radians</summary>
   /// <returns>Returns radians value of input degree</returns>
   static double Deg2Rad (double f) => f * Math.PI / 180;

   /// <summary>Method to convert given radians value to degree</summary>
   /// <returns>Returns degree vale of the input radians</returns>
   static double Rad2Deg (double f) => f * 180 / Math.PI;
}

/// <summary>Class which inherits the TOperator and overrides the priority</summary>
class TUnary : TOperator {
   public TUnary (Evaluator eval, char c) : base (eval) => Op = c;
   public char Op { get; private set; }
   public override int Priority => 5 + mEval.BasePriority;
   public override string ToString () => $"{Op}";
}

/// <summary>Class which inherits the Token class which represents the presence of brackets in the input</summary>
class TPunc : Token {
   public TPunc (char ch) => Punc = ch;
   public char Punc { get; private set; }
   public override string ToString () => $"{Punc}";
}

/// <summary>Class which inherits Token and basically represents all exception cases that can occur</summary>
class TError : Token {
   public TError (string message) => Message = message;
   public string Message { get; private set; }
   public override string ToString () => $"Error:{Message}";
}

/// <summary>Class which inherits the Token class and it marks the end of the input</summary>
class TEnd : Token {
   public override string ToString () => "end";
}
#endregion