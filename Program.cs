using System;

namespace Training {
   #region class Program-----------
   class Program {
      #region method---------------
      /// <summary>Main method where the class is implemented</summary>
      /// <param name="args"></param>
      public static void Main () {

      }
      #endregion
   }
   #endregion

   #region class MyList----------------
   public class MyList<T> {
      #region Private Data------
      int mcount;
      int mcapacity;
      T[] mylist;
      #endregion ---------------

      #region Constructor---------
      public MyList () {
         mcount = 0;
         mcapacity = 4;
         mylist = new T[mcapacity];
      }
      #endregion

      #region Properties-------------------
      /// <summary>Method gives current number of elements in the list</summary>
      public int Count => mcount;
      /// <summary>Method gives maximum limit of elements in the list</summary>
      public int Capacity => mcapacity;
      /// <summary>Method used to get or set a value of element at particular index of list</summary>
      /// <param name="index">Index to be get or set</param>
      /// <returns>Returns the value at index</returns>
      public T this[int index] {
         get {
            Indexexception (index);
            return mylist[index];
         }
         set {
            Indexexception (index);
            mylist[index] = value;
         }
      }
      #endregion

      #region Methods--------------------
      /// <summary>Method add the argument at end of list</summary>
      /// <param name="item">Element to be added</param>
      public void Add (T item) {
         if (mcount == mcapacity)
            ResizeArray ();
         mylist[mcount++] = item;
      }

      /// <summary>Check whether element is present in the list and remove if it is there</summary>
      /// <param name="item"></param>
      /// <returns>Returns the boolean value of presence and absence of the particular element in the list</returns>
      public bool Remove (T item) {
         if (mylist.Contains (item)) {
            int index = Array.IndexOf (mylist, item);
            RemoveAt (index);
            return true;
         }
         return false;
      }

      /// <summary>Method used to clear all the elements in the list</summary>
      public void Clear () {
         Array.Clear (mylist);
         mcount = 0;
      }

      /// <summary>Method insert the given element at the particular index given</summary>
      /// <param name="index">Index in which element should be inserted</param>
      /// <param name="item">Element to be inserted</param>
      /// <exception cref="ArgumentOutOfRangeException">If the index passed is out of range, it throws argument out of range exception</exception>
      public void Insert (int index, T item) {
         if (Argumentexception (index)) {
            mcount++;
            for (int i = mcount; i >= index; i--)
               mylist[i] = mylist[i - 1];
            mylist[index] = item;
         }
      }

      /// <summary>Method remove the element in the particular index given</summary>
      /// <param name="index">Index in which elemnt to be removed</param>
      public void RemoveAt (int index) {
         if (Argumentexception (index)) {
            for (int i = index; i < mcount - 1; i++)
               mylist[i] = mylist[i + 1];
            mcount--;
         }
      }

      /// <summary>Method will double the size of list if the count exceeds the capacity</summary>
      private void ResizeArray () {
         mcapacity *= 2;
         Array.Resize (ref mylist, mcapacity);
      }

      /// <summary>This method check whether given index is within the limit of list or exceeds it</summary>
      /// <param name="index">Index to be checked</param>
      /// <returns>Returns true if index is within limit, false otherwise</returns>
      /// <exception cref="IndexOutOfRangeException">If index is out of limit, throw index out of range exception</exception>
      public bool Indexexception (int index) {
         try {
            if (index >= 0 && index < mcount)
               return true;
            else
               throw new IndexOutOfRangeException ("Index out of range");
         } catch (IndexOutOfRangeException exception) {
            Console.WriteLine (exception.Message);
         }
         return false;
      }

      /// <summary>Method check whether argument to be passed at partuclar index is within the limit of list</summary>
      /// <param name="index">Index of the argument to be passed</param>
      /// <returns>Returns true if index of element is within the limit or false otherwise</returns>
      /// <exception cref="ArgumentOutOfRangeException">If index is out of limit, throw argument out of range exception</exception>
      public bool Argumentexception (int index) {
         try {
            if (index >= 0 && index < mcount)
               return true;
            else
               throw new ArgumentOutOfRangeException (nameof (index), "Argument is out of range");
         } catch (ArgumentOutOfRangeException ex) {
            Console.WriteLine (ex.Message);
         }
         return false;
      }
      #endregion
   }
   #endregion
}


