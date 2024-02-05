using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      readonly TQueue<int> Que = new ();
      [TestMethod]
      public void PropertiesTest () {
         Assert.IsTrue (Que.IsEmpty);
         Que.TEnqueue (1);
         Assert.IsFalse (Que.IsEmpty);
         Que.TEnqueue (2);
         Que.TEnqueue (3);
         Assert.AreEqual (3, Que.Count);
         Que.TEnqueue (4);
         Assert.AreEqual (4, Que.Count);
         Assert.AreEqual (4, Que.Capacity);
         Que.TEnqueue (5);
         Assert.AreEqual (8, Que.Capacity);
      }

      [TestMethod]
      public void PassTest () {
         Que.TEnqueue (1);
         Que.TEnqueue (2);
         Que.TEnqueue (3);
         Que.TEnqueue (4);
         Assert.AreEqual (1, Que.HDequeue ());
         Que.HEnqueue (5);
         Assert.AreEqual (4, Que.TDequeue ());
         Que.TEnqueue (6);
         Assert.AreEqual (6, Que.TDequeue ());
         Que.TEnqueue (7);
         Que.HEnqueue (8);
         Que.TEnqueue (9);
         Assert.AreEqual (8, Que.HDequeue ());
      }

      [TestMethod]
      public void Failtest () {
         Que.HEnqueue (1);
         Que.TDequeue ();
         _ = Assert.ThrowsException<InvalidOperationException> (() => Que.TDequeue ());
         _ = Assert.ThrowsException<InvalidOperationException> (() => Que.HDequeue ());
      }
   }
}