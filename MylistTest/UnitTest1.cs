using Training;
namespace MylistTest {
   #region Class Test---------------------
   [TestClass]
   public class UnitTest1 {
      #region Global values------------
      MyList<int> mlist = new ();
      List<int> list = new ();
      #endregion

      #region Methods----------------------

      [TestMethod]
      public void AddTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void Removetest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         list.Remove (18); mlist.Remove (18);
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void InsertTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         list.Insert (1, 5); mlist.Insert (1, 5);
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void RemoveatTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         list.RemoveAt (0); mlist.RemoveAt (0);
         Assert.AreEqual (list[0], mlist[0]);
      }

      [TestMethod]
      public void ClearTest () {
         list.Clear (); mlist.Clear ();
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void Resizablecheck () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         int initialcapacity = mlist.Capacity;
         for (int i = 10; i < 14; i++)
            mlist.Add (i);
         Assert.AreNotEqual (initialcapacity, mlist.Capacity);
      }
      #endregion 
   }
   #endregion 
}