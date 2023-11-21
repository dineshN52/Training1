using Training;
namespace Quetest {
   [TestClass]
   public class UnitTest1 {
      Tqueue<int> Que1 = new ();
      Queue<int> Que2 = new ();

      [TestMethod]
      public void EnqueueTest () {
         for (int i = 0; i < 4; i++) {
            Que1.Enqueue (i);
            Que2.Enqueue (i);
         }
         Assert.AreEqual (Que2.Count, Que1.Count);
         Que1.Enqueue (4);
         Assert.AreEqual (false, Que1.IsEmpty);
         Assert.AreEqual (8, Que1.Capacity);
      }

      [TestMethod]
      public void DequeTest () {
         for (int i = 0; i < 4; i++) {
            Que1.Enqueue (i);
            Que2.Enqueue (i);
         }
         Assert.AreEqual (Que2.Dequeue (), Que1.Dequeue ());
         for (int i = 0; i < 3; i++)
            Que1.Dequeue ();
         Assert.AreEqual (true, Que1.IsEmpty);
         Assert.ThrowsException<InvalidOperationException> (() => Que1.Dequeue ());
      }

      [TestMethod]
      public void PeekTest () {
         for (int i = 0; i < 4; i++) {
            Que1.Enqueue (i);
            Que2.Enqueue (i);
         }
         Assert.AreEqual (Que2.Peek (), Que1.Peek ());
         for (int i = 0; i < 4; i++)
            Que1.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => Que1.Peek ());
      }
   }
}