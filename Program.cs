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

   #region class Tqueue----------------
   public class Tqueue<T> {
      public T a = default;
      #region Private Data------
      int mCount;
      int mFront;
      int mRear;
      T[] mTqueue;
      #endregion --------------

      #region Constructor---------
      public Tqueue () {
         mCount = 0;
         mFront = 0;
         mRear = 0;
         mTqueue = new T[4];
      }
      #endregion

      #region Properties-------------------
      /// <summary>Method gives current number of elements in the list</summary>
      public int Count => mCount;

      /// <summary>Method gives maximum limit of elements in the list</summary>
      public int Capacity => mTqueue.Length;

      /// <summary>This method check the stack is empty or not and returns the boolen value accordingly</summary>
      public bool IsEmpty {
         get {
            if (mCount > 0)
               return false;
            return true;
         }
      }
      #endregion

      #region Methods--------------------      
      public void Enqueue (T a) {
         if (mCount == Capacity)
            ResizeArray ();
         mTqueue[mRear] = a;
         mRear = (mRear + 1) % Capacity;
         mCount++;
      }

      public T Dequeue () {
         if (mCount > 0) {
            a = mTqueue[mFront];
            mTqueue[mFront] = default;
            mFront = (mFront + 1) % Capacity;
            mCount--;
            return a;
         } else
            throw new InvalidOperationException ("Queue is empty");
      }

      /// <summary>Method used to view fisrt element in the stack</summary>
      /// <returns>Return the first element of stack</returns>
      public T Peek () {
         if (mCount > 0)
            return mTqueue[mFront];
         else
            throw new InvalidOperationException ("Stack is empty");
      }

      /// <summary>Method will double the size of list if the count exceeds the capacity</summary>
      private void ResizeArray () {
         var temp = new T[Capacity * 2];
         for (int i = 0; i < Capacity; i++) {
            temp[i] = mTqueue[mFront];
            mFront = (mFront + 1) % Capacity;
         }
         (mTqueue, mRear, mFront) = (temp, mCount, 0);
      }
      #endregion
   }
   #endregion
}