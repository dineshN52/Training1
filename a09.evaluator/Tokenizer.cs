namespace Eval;

/// <summary>Class which helps to get tokens from the input string</summary>
class Tokenizer {

   #region Constructor-------------
   public Tokenizer (string text, Evaluator eval) {
      mN = 0; mText = text; mEval = eval;
   }
   #endregion

   #region Methods-------------------
   /// <summary>Method to get next token at the end of one token</summary>
   /// <returns>Return different token based on the charcater analysis in the input string</returns>
   public Token Next () {
      while (mN < mText.Length) {
         char ch = mText[mN++];
         switch (ch) {
            case ' ' or '\t': continue;
            case (>= '0' and <= '9') or '.': return GetNumber ();
            case >= 'a' and <= 'z': return GetIdentifier ();
            case '+' or '-':
               if (mText.StartsWith (ch) || mEval.GetLastToken () is TOperator or TPunc) return new TUnary (mEval, ch);
               return new TArithOper (mEval, ch);
            case '*' or '/' or '^' or '=': return new TArithOper (mEval, ch);
            case '(' or ')': return new TPunc (ch);
            default: return new TError ($"Invalid character : {ch}");
         }
      }
      return new TEnd ();

      /// <summary>Method to get identifier tokens like TFuncOper or TVariable</summary>
      Token GetIdentifier () {
         int initial = mN - 1;
         while (mN < mText.Length) {
            if (mText[mN++] is >= 'a' and <= 'z') continue;
            mN--; break;
         }
         string sub = mText[initial..mN];
         return Func.Contains (sub) ? new TFuncOper (mEval, sub) : new TVariable (mEval, sub);
      }

      /// <summary>Method to get number tokens like TLiteral</summary>
      Token GetNumber () {
         int initial = mN - 1;
         while (mN < mText.Length) {
            if (mText[mN++] is (>= '0' and <= '9') or '.') continue;
            mN--; break;
         }
         return double.TryParse (mText[initial..mN], out double n) ? new TLiteral (n) : new TError ("Invalid number");
      }
   }
   #endregion

   #region Private data---------------
   readonly string[] Func = { "sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan" };
   readonly Evaluator mEval;
   readonly string mText;
   int mN;
   #endregion
}