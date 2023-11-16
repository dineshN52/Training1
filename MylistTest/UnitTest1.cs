using Training;
namespace MylistTest {
   #region Class Test---------------------
   [TestClass]
   public class UnitTest1 {
      #region Global values------------
      MyList<int> mlist = new ();
      List<int> list = new ();
      int initialcapacity = 0;
      #endregion

      #region Methods----------------------
      [TestMethod]
      public void AddTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mlist.Add (i);
         }
         Assert.AreEqual (list.Count, mlist.Count);
         initialcapacity = mlist.Capacity;
      }

      [TestMethod]
      public void Removetest () {
         list.Remove (18);mlist.Remove (18);
         Assert.AreEqual (list[3], mlist[3]);
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void InsertTest () {
         list.Insert (1, 5);mlist.Insert (1, 5);
         Assert.AreEqual (list[1], mlist[1]);
      }

      [TestMethod]
      public void RemoveatTest () {
         list.RemoveAt (0);mlist.RemoveAt (0);
         Assert.AreEqual (list[0], mlist[0]);
      }

      [TestMethod]
      public void ClearTest () {
         list.Clear ();mlist.Clear ();
         Assert.AreEqual (list.Count, mlist.Count);
      }

      [TestMethod]
      public void Resizablecheck () {
         for (int i = 10; i < 14; i++)
            mlist.Add (i);
         Assert.AreNotEqual (initialcapacity, mlist.Capacity);
      }
      #endregion 
   }
   #endregion 
}