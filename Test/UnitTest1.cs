using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void PassTest () {
         Assert.AreEqual (double.Parse ("0"), MyDouble.Parse ("0"));
         Assert.AreEqual (double.Parse ("0.0"), MyDouble.Parse ("0.0"));
         Assert.AreEqual (double.Parse ("50"), MyDouble.Parse ("50"));
         Assert.AreEqual (double.Parse ("-50"), MyDouble.Parse ("-50"));
         Assert.AreEqual (double.Parse ("4.58"), MyDouble.Parse ("4.58"));
         Assert.AreEqual (double.Parse ("+4.58"), MyDouble.Parse ("+4.58"));
         Assert.AreEqual (double.Parse ("-4.58"), MyDouble.Parse ("-4.58"));
         Assert.AreEqual (double.Parse (".734"), MyDouble.Parse (".734"));
         Assert.AreEqual (double.Parse ("+.734"), MyDouble.Parse ("+.734"));
         Assert.AreEqual (double.Parse ("-.734"), MyDouble.Parse ("-.734"));
         Assert.AreEqual (double.Parse ("0.734"), MyDouble.Parse ("0.734"));
         Assert.AreEqual (double.Parse ("+0.734"), MyDouble.Parse ("+0.734"));
         Assert.AreEqual (double.Parse ("-0.734"), MyDouble.Parse ("-0.734"));
         Assert.AreEqual (double.Parse ("85."), MyDouble.Parse ("85."));
         Assert.AreEqual (double.Parse ("+85."), MyDouble.Parse ("+85."));
         Assert.AreEqual (double.Parse ("-85."), MyDouble.Parse ("-85."));
         Assert.AreEqual (double.Parse ("5e85"), MyDouble.Parse ("5e85"));
         Assert.AreEqual (double.Parse ("+5e85"), MyDouble.Parse ("+5e85"));
         Assert.AreEqual (double.Parse ("-5e85"), MyDouble.Parse ("-5e85"));
         Assert.AreEqual (double.Parse ("+5e+85"), MyDouble.Parse ("+5e+85"));
         Assert.AreEqual (double.Parse ("+5e-85"), MyDouble.Parse ("+5e-85"));
         Assert.AreEqual (double.Parse ("-5e-85"), MyDouble.Parse ("-5e-85"));
         Assert.AreEqual (double.Parse ("-5e+85"), MyDouble.Parse ("-5e+85"));
         Assert.AreEqual (double.Parse ("5e+85"), MyDouble.Parse ("5e+85"));
         Assert.AreEqual (double.Parse ("5e-85"), MyDouble.Parse ("5e-85"));
         Assert.AreEqual (double.Parse (".5e75"), MyDouble.Parse (".5e75"));
         Assert.AreEqual (double.Parse (".5e+75"), MyDouble.Parse (".5e+75"));
         Assert.AreEqual (double.Parse (".5e-75"), MyDouble.Parse (".5e-75"));
         Assert.AreEqual (double.Parse ("0.5e75"), MyDouble.Parse ("0.5e75"));
         Assert.AreEqual (double.Parse ("+0.5e75"), MyDouble.Parse ("+0.5e75"));
         Assert.AreEqual (double.Parse ("-0.5e75"), MyDouble.Parse ("-0.5e75"));
         Assert.AreEqual (double.Parse ("0.5e-75"), MyDouble.Parse ("0.5e-75"));
         Assert.AreEqual (double.Parse ("+0.5e-75"), MyDouble.Parse ("+0.5e-75"));
         Assert.AreEqual (double.Parse ("-0.5e-75"), MyDouble.Parse ("-0.5e-75"));
      }

      [TestMethod]
      public void FailTest () {
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("34+78"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("+e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("-e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("e+34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("e-34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse (".e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("e3-4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("4e3.4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("3/.e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("34+e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("79.+e34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("87.6e3+"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.6.34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.6a34"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.8e3.4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.8e1+4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.8e3.4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67.8e3.4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("67e8e3.4"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("+3+3.e-2"));
         Assert.ThrowsException<FormatException> (() => MyDouble.Parse ("+3-3.e+2"));
      }
   }
}