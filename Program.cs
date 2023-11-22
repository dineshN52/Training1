// ----------------------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// ----------------------------------------------------------------------------------------------------------------------------------
// Program.cs
// Creating a custom Mylist
// Includes creation of all properties like count, capacity and methods like add, remove, insert, removeat for our custom mylist.
// Craete test method for all properties and methods
// Custom list method should also be able to thrwo exception whenever necesaary
// Like accesing an index above or below the limit of list should produce IndexOutofRangeException
// And should produce ArgumentOutofRangeEXception whenever trying to insert or remove element whose index is not in the limit of list
// ----------------------------------------------------------------------------------------------------------------------------------
using System;

namespace Training {
   #region class Program-----------
   class Program {
      #region method---------------
      /// <summary>Main method where the class is implemented</summary>
      /// <param name="args"></param>
      public static void Main () { }
      #endregion
   }
   #endregion

   #region class MyList----------------
   public class MyList<T> {
      #region Private Data------
      int mCount;
      int mCapacity;
      T[] myList;
      #endregion ---------------

      #region Constructor---------
      public MyList () {
         mCount = 0;
         mCapacity = 4;
         myList = new T[mCapacity];
      }
      #endregion

      #region Properties-------------------
      /// <summary>Method gives current number of elements in the list</summary>
      public int Count => mCount;

      /// <summary>Method gives maximum limit of elements in the list</summary>
      public int Capacity => mCapacity;

      /// <summary>Method used to get or set a value of element at particular index of list</summary>
      /// <param name="index">Index to be get or set</param>
      /// <returns>Returns the value at index</returns>
      public T this[int index] {
         get {
            CheckValidIndex (index);
            return myList[index];
         }
         set {
            CheckValidIndex (index);
            myList[index] = value;
         }
      }
      #endregion

      #region Methods--------------------
      /// <summary>Method add the argument at end of list</summary>
      /// <param name="item">Element to be added</param>
      public void Add (T item) {
         if (mCount == mCapacity)
            ResizeArray ();
         myList[mCount++] = item;
      }

      /// <summary>Check whether element is present in the list and remove if it is there</summary>
      /// <param name="item"></param>
      /// <returns>Returns the boolean value of presence and absence of the particular element in the list</returns>
      public bool Remove (T item) {
         int index = Array.IndexOf (myList, item);
         if (index != -1)
            RemoveAt (index);
         return false;
      }

      /// <summary>Method used to clear all the elements in the list</summary>
      public void Clear () {
         Array.Clear (myList);
         mCount = 0;
      }

      /// <summary>Method insert the given element at the particular index given</summary>
      /// <param name="index">Index in which element should be inserted</param>
      /// <param name="item">Element to be inserted</param>
      /// <exception cref="ArgumentOutOfRangeException">If the index passed is out of range, it throws argument out of range exception</exception>
      public void Insert (int index, T item) {
         if (CheckValidArgumentIndex (index)) {
            if (mCount == mCapacity)
               ResizeArray ();
            for (int i = mCount; i > index; i--)
               myList[i] = myList[i - 1];
            myList[index] = item;
            mCount++;
         }
      }

      /// <summary>Method remove the element in the particular index given</summary>
      /// <param name="index">Index in which elemnt to be removed</param>
      public void RemoveAt (int index) {
         if (CheckValidArgumentIndex (index)) {
            for (int i = index; i < mCount - 1; i++)
               myList[i] = myList[i + 1];
            mCount--;
         }
      }

      /// <summary>Method will double the size of list if the count exceeds the capacity</summary>
      private void ResizeArray () {
         mCapacity *= 2;
         Array.Resize (ref myList, mCapacity);
      }

      /// <summary>Method checks whether given index is within the limit of list</summary>
      /// <param name="index">Index to be checked</param>
      /// <exception cref="IndexOutOfRangeException">If index is out of limit, throw index out of range exception</exception>
      public void CheckValidIndex (int index) {
         if (index < 0 || index >= mCount)
            throw new IndexOutOfRangeException ("Index out of range");
      }

      /// <summary>Method checks whether argument to be passed at partiuclar index is within the limit of list</summary>
      /// <param name="index">Index of the argument to be passed</param>
      /// <returns>Returns true if index of element is within the limit or false otherwise</returns>
      /// <exception cref="ArgumentOutOfRangeException">If index is out of limit, throw argument out of range exception</exception>
      public bool CheckValidArgumentIndex (int index) {
         if (index >= 0 && index <= mCount)
            return true;
         else
            throw new ArgumentOutOfRangeException (nameof (index), "Argument is out of range");
      }
      #endregion
   }
   #endregion
}


