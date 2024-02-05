// -------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -------------------------------------------------------------------------------------------------
// Program.cs
// Creating a custom Double ended Queue
// Includes creation of all properties like count, capacity, IsEmpty and methods like
// HEnqueue, HDequeue(),TEnqueue, TDequeue().
// Custom Queue method should also be able to throw exception whenever necesaary
// Like Dequeue an element from the queue which is empty should produce Inavalidoperation Exception.
// -------------------------------------------------------------------------------------------------
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

   #region class TQueue----------------
   /// <summary>Method to create a Custom Queue class</summary>
   /// <typeparam name="T"></typeparam>
   public class TQueue<T> {
      public T a = default;
      #region Private Data------
      int mCount;
      int mFront;
      int mRear;
      T[] mTQueue;
      #endregion --------------

      #region Constructor---------
      public TQueue () {
         mCount = 0;
         mFront = 0;
         mRear = 0;
         mTQueue = new T[4];
      }
      #endregion

      #region Properties-------------------
      /// <summary>Method gives current number of elements in the list</summary>
      public int Count => mCount;

      /// <summary>Method gives maximum limit of elements in the list</summary>
      public int Capacity => mTQueue.Length;

      /// <summary>This method check the stack is empty or not and returns the boolen value accordingly</summary>
      public bool IsEmpty => mCount <= 0;
      #endregion

      #region Methods--------------------
      /// <summary>Method to enqueue a new element in the head side(Left) of queue</summary>
      /// <param name="a">New element to be added</param>
      public void HEnqueue (T a) {
         if (mCount == Capacity)
            ResizeArray ();
         mFront = (Capacity + mFront - 1) % Capacity;
         mTQueue[mFront] = a;
         mCount++;
      }

      /// <summary>Method to enqueue a new element in the Tail side(left) of queue</summary>
      /// <param name="a">New element to be added</param>
      public void TEnqueue (T a) {
         if (mCount == Capacity)
            ResizeArray ();
         mTQueue[mRear] = a;
         mRear = (mRear + 1) % Capacity;
         mCount++;
      }

      /// <summary>Method to Deque the element from head side of the queue</summary>
      /// <returns>Returns the first element added on the head side</returns>
      public T HDequeue () {
         if (mCount > 0) {
            a = mTQueue[mFront];
            mFront = (mFront + 1) % Capacity;
            mCount--;
            return a;
         } else
            throw new InvalidOperationException ("Queue is empty");
      }

      /// <summary>Method to Deque the element from tail side of the queue</summary>
      /// <returns>Returns the first element added on tail side</returns>
      public T TDequeue () {
         if (mCount > 0) {
            mRear = mRear == 0 ? mCount - 1 : (mRear - 1) % Capacity;
            a = mTQueue[mRear];
            mCount--;
            return a;
         } else
            throw new InvalidOperationException ("Queue is empty");
      }

      /// <summary>Method will double the size of que if the count exceeds the capacity</summary>
      private void ResizeArray () {
         for (int i = 0; i < (mCount - mFront); i++) {
            for (int j = 0; j < Capacity - 1; j++)
               (mTQueue[0], mTQueue[j + 1]) = (mTQueue[j + 1], mTQueue[0]);
         }
         Array.Resize (ref mTQueue, Capacity * 2);
         (mFront, mRear) = (0, mCount);
      }
      #endregion
   }
   #endregion
}