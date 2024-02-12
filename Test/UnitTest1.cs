using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void PropertiesTest () {
         TQueue<int> mQue = new ();
         Assert.IsTrue (mQue.IsEmpty);
         mQue.TEnqueue (1);
         Assert.IsFalse (mQue.IsEmpty);
         mQue.TEnqueue (2);
         mQue.TEnqueue (3);
         Assert.AreEqual (3, mQue.Count);
         mQue.TEnqueue (4);
         Assert.AreEqual (4, mQue.Count);
         Assert.AreEqual (4, mQue.Capacity);
         mQue.TEnqueue (5);
         Assert.AreEqual (8, mQue.Capacity);
      }

      [TestMethod]
      public void PassTest () {
         TQueue<int> mQue = new ();
         mQue.TEnqueue (1);
         mQue.TEnqueue (2);
         mQue.TEnqueue (3);
         mQue.TEnqueue (4);
         Assert.AreEqual (1, mQue.HDequeue ());
         mQue.HEnqueue (5);
         Assert.AreEqual (4, mQue.TDequeue ());
         mQue.TEnqueue (6);
         Assert.AreEqual (6, mQue.TDequeue ());
         mQue.TEnqueue (7);
         Assert.AreEqual (5, mQue.HDequeue ());
         mQue.TEnqueue (8);
         mQue.HEnqueue (9);
         mQue.TEnqueue (10);
         Assert.AreEqual (9, mQue.HDequeue ());
      }

      [TestMethod]
      public void Failtest () {
         TQueue<int> mQue = new ();
         mQue.HEnqueue (1);
         mQue.TDequeue ();
         _ = Assert.ThrowsException<InvalidOperationException> (() => mQue.TDequeue ());
         _ = Assert.ThrowsException<InvalidOperationException> (() => mQue.HDequeue ());
      }
   }
}