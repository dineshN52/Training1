using Training;
namespace Stacktest {
    [TestClass]
    public class UnitTest1 {
        Tstack<int> stack1 = new ();
        Stack<int> stack2 = new ();

        [TestMethod]
        public void Pushtest () {
            for (int i = 0; i < 4; i++) {
                stack1.Push (i);
                stack2.Push (i);
            }
            Assert.AreEqual (stack1.Count, stack2.Count);
            stack1.Push (4);
            Assert.AreEqual (8, stack1.Capacity);
        }

        [TestMethod]
        public void Poptest () {
            for (int i = 0; i < 4; i++) {
                stack1.Push (i);
                stack2.Push (i);
            }
            stack1.Pop (); stack2.Pop ();
            Assert.AreEqual (stack1.Count, stack2.Count);
            Assert.AreEqual (false, stack1.IsEmpty);
            for (int i = 0; i < 3; i++)
                stack1.Pop ();
            Assert.AreEqual (true, stack1.IsEmpty);
            Assert.ThrowsException<InvalidOperationException> (() => stack1.Pop (), "Stack is empty");
        }

        [TestMethod]
        public void Peektest () {
            for (int i = 0; i < 4; i++) {
                stack1.Push (i);
                stack2.Push (i);
            }
            Assert.AreEqual (stack1.Peek (), stack2.Peek ());
            for (int i = 0; i < 4; i++)
                stack1.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => stack1.Peek (), "Stack is empty");
        }
    }
}