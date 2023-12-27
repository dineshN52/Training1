using Eval;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      Evaluator eval = new ();
      [TestMethod]
      public void PassTest () {
         Dictionary<string, double> PassInputs = new () { {"sin0",0 } , {"cos0",1},{"tan 45",1},{"asin1",90},{"acos0.707",45.00865},{"atan1.732",59.99927}, {"log1",0}
         ,{"sqrt64",8},{"exp1",2.71828},{"5+7-6*4/2",0},{"9+3^2",18},{"a=sin30",0.5},{"a",0.5 },{"-tan45",-1},{"(a*4)/2",1 },{"b=-cos0",-1 },{"b*5+1",-4 } };
         foreach (var input in PassInputs) {
            Assert.AreEqual (eval.Evaluate (input.Key), input.Value);
         }
      }
      [TestMethod]
      public void FailTest () {
         List<string> FailInputs = new () { "c", "5+4-", "sen45", "bcos1", "5$2", "7&4", "1@7" };
         foreach (var input in FailInputs) {
            Assert.ThrowsException<EvalException> (() => eval.Evaluate (input));
         }
      }
   }
}