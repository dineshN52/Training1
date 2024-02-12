using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void PropertiesTest () {
         TQueue<int> que = new ();
         Assert.IsTrue (que.IsEmpty);
         que.TEnqueue (1);
         Assert.IsFalse (que.IsEmpty);
         que.TEnqueue (2);
         que.TEnqueue (3);
         Assert.AreEqual (3, que.Count);
         que.TEnqueue (4);
         Assert.AreEqual (4, que.Count);
         Assert.AreEqual (4, que.Capacity);
         que.TEnqueue (5);
         Assert.AreEqual (8, que.Capacity);
      }

      [TestMethod]
      public void PassTest () {
         TQueue<int> que = new ();
         que.TEnqueue (1);
         que.TEnqueue (2);
         que.TEnqueue (3);
         que.TEnqueue (4);
         Assert.AreEqual (1, que.HDequeue ());
         que.HEnqueue (5);
         Assert.AreEqual (4, que.TDequeue ());
         que.TEnqueue (6);
         Assert.AreEqual (6, que.TDequeue ());
         que.TEnqueue (7);
         Assert.AreEqual (5, que.HDequeue ());
         que.TEnqueue (8);
         que.HEnqueue (9);
         que.TEnqueue (10);
         Assert.AreEqual (9, que.HDequeue ());
      }

      [TestMethod]
      public void Failtest () {
         TQueue<int> que = new ();
         que.HEnqueue (1);
         que.TDequeue ();
         _ = Assert.ThrowsException<InvalidOperationException> (() => que.TDequeue ());
         _ = Assert.ThrowsException<InvalidOperationException> (() => que.HDequeue ());
      }
   }
}