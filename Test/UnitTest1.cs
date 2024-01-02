using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {

      readonly MyDouble db = new ();

      [TestMethod]
      public void PassTest () {
         string[] inputs = { "0", "0.0", "50", "+50", "-50", "4.58", "+4.58", "-4.58", ".734", "+.734", "-7.34", "0.734", "+85.",
                "+0.734", "-0.734", "5e85", "+5e85", "-5e85", "+5e+85", "+5e-85", "-5e-85", "-5e+85", "5e+85", "5e-85", "85.",
                ".5e75", ".5e+75", ".5e-75", "0.5e75", "+0.5e75", "-0.5e75", "0.5e-75", "+0.5e-75", "-0.5e-75","-85.","0.1e2"
            };
         foreach (string input in inputs) {
            var f1 = db.Parse (input);
            var f2 = double.Parse (input);
            Assert.AreEqual (f1, f2);
         }
      }

      [TestMethod]
      public void FailTest () {
         string[] inputs = { "e34", "+e34", "-e34", "e+34", "e-34", ".e34", "e3-4", "4e3.4", "3/.e34", "34+e34", "79.+e34",
                "87.6e3+", "67.6.34", "67.6a34", "67.8e3.4", "67.8e1+4", "67e8e3.4", "+3+3.e-2", "+3+3.e-2", "+3-3.e+2"
            };
         foreach (string input in inputs)
            Assert.ThrowsException<FormatException> (() => db.Parse (input));
         Assert.ThrowsException<ArgumentNullException> (() => db.Parse (null));
      }
   }
}