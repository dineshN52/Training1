// -----------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// -----------------------------------------------------------------------------------------------------------------------
// Program.cs
// Creating a custom stack
// Includes creation of all properties like count, capacity,IsEmpty and methods like Push(), Pop(), Peek().
// Create test method for all properties and methods
// Custom stack method should also be able to throw exception whenever necesaary
// Like Poping an element from the stack which is empty should produce Inavalidoperation Exception.
// Similarly, method should throw Invalidoperation Exception when try to peek() and element from a stack which is empty().
// -----------------------------------------------------------------------------------------------------------------------
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

   #region class TStack----------------
   /// <summary>Method to create a custom Stack</summary>
   /// <typeparam name="T"></typeparam>
   public class TStack<T> {

      #region Private Data------
      int mCount;
      int mCapacity;
      T[] mTStack;
      #endregion ---------------

      #region Constructor---------
      public TStack () {
         mCount = 0;
         mCapacity = 4;
         mTStack = new T[mCapacity];
      }
      #endregion

      #region Properties-------------------
      /// <summary>Method gives current number of elements in the list</summary>
      public int Count => mCount;

      /// <summary>Method gives maximum limit of elements in the list</summary>
      public int Capacity => mCapacity;

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
      /// <summary>Method pushes or add the element to the stack</summary>
      /// <param name="a">Element to be pushed</param>
      public void Push (T a) {
         if (mCount == mCapacity)
            ResizeArray ();
         mTStack[mCount++] = a;
      }

      /// <summary>Method used to remove last element of the stack and also to get the element</summary>
      /// <returns>Return the final element</returns>
      public T Pop () {
         if (mCount > 0)
            return mTStack[--mCount];
         else
            throw new InvalidOperationException ("Stack is empty");
      }


      /// <summary>Method used to view fisrt element in the stack</summary>
      /// <returns>Return the first element of stack</returns>
      public T Peek () {
         if (mCount > 0)
            return mTStack[mCount - 1];
         else
            throw new InvalidOperationException ("Stack is empty");
      }

      /// <summary>Method will double the size of stack if the count exceeds the capacity</summary>
      private void ResizeArray () {
         mCapacity *= 2;
         Array.Resize (ref mTStack, mCapacity);
      }
      #endregion
   }
   #endregion
}