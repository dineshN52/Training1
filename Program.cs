// --------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------
// Program.cs
// Choclate for wrappers
// For given values of total money,price of choclate and wrappers need to be excahged to buy choclate again
// It should produce,Number of choclates purchased,remaining money,remaining wrappers
// For Example,if input(X=15, P=4, W=3),output should be (C=4, X=3, W=1)
// --------------------------------------------------------------------------------------------------------
namespace Chocwrap {
   #region class Program--------------------------
   /// <summary>Choclate for wrappers</summary>
   internal class Program {
      #region Methods-------------------------
      /// <summary>Method gets input for Money,Price of choclate and wrappers need for exchange
      /// And produce output value for Choclates purchased, Remaining money, remaining wrappers</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter the available money, price of each choclate,wrappers need to be exchaged to buy choclate." +
             "\n (Note:Enter each value separated by a space.Always wrapper value should be greater than 1.");
         while (true) {
            string s = Console.ReadLine ();
            string[] Inputs = s.Split (' ');
            if (uint.TryParse (Inputs[0], out uint X) && uint.TryParse (Inputs[1], out uint P)
                && uint.TryParse (Inputs[2], out uint W) && W > 1) {
               uint temp = X / P;
               uint choc = temp;
               X %= P;
               while (temp >= W) {
                  choc += (temp / W);
                  temp = (temp / W) + (temp % W);
               }
               Console.WriteLine ($"C={choc} X={X} W={temp}");
               break;
            } else
               Console.WriteLine ("Enter proper values for money, price and wrappers");
         }
         Console.ReadKey ();
      }
      #endregion
   }
   #endregion
}