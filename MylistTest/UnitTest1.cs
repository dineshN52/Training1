using Training;
namespace MylistTest {
   #region Class Test---------------------
   [TestClass]
   public class UnitTest1 {
      #region Global values------------
      MyList<int> mList = new ();
      List<int> list = new ();
      #endregion

      #region Methods----------------------

      [TestMethod]
      public void AddTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         Assert.AreEqual (list.Count, mList.Count);
      }

      [TestMethod]
      public void Removetest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         list.Remove (17); mList.Remove (17);
         Assert.AreEqual (list.Count, mList.Count);
      }

      [TestMethod]
      public void Thistest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         list[0] = 10; mList[0] = 10;
         Assert.AreEqual (list[0], mList[0]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mList[5] = 12, "Index out of range");
      }

      [TestMethod]
      public void InsertTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         list.Insert (0, 14); mList.Insert (0, 14);
         Assert.AreEqual (list[0], mList[0]);
         list.Insert (3, 5); mList.Insert (3, 5);
         Assert.AreEqual (list[3], mList[3]);
         Assert.ThrowsException<ArgumentOutOfRangeException> (() => mList.Insert (6, 5), "Argument out of range");
      }

      [TestMethod]
      public void RemoveatTest () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         list.RemoveAt (0); mList.RemoveAt (0);
         Assert.AreEqual (list[0], mList[0]);
         Assert.ThrowsException<ArgumentOutOfRangeException> (() => mList.RemoveAt (7), "Index out of range");
      }

      [TestMethod]
      public void ClearTest () {
         list.Clear (); mList.Clear ();
         Assert.AreEqual (list.Count, mList.Count);
      }

      [TestMethod]
      public void Resizablecheck () {
         for (int i = 15; i < 18; i++) {
            list.Add (i);
            mList.Add (i);
         }
         for (int i = 18; i < 20; i++)
            mList.Add (i);
         Assert.AreEqual (8, mList.Capacity);
      }
      #endregion 
   }
   #endregion 
}