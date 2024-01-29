using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      Training.FileParser fp = new ();

      [TestMethod]
      public void PassTest () {
         Assert.AreEqual ("C:\\Work\\dineshn\\words.txt", fp.Parse ("C:\\Work\\dineshn\\words.txt"));
         Assert.AreEqual ("C:\\Work\\dineshn\\words.txt", fp.Parse ("C:/Work/dineshn/words.txt"));
         Assert.AreEqual ("C:\\Work\\input.txt", fp.Parse ("C:/Work/input.txt"));
         if (fp.TryFileParse ("C:/Work/dineshn/words.txt", out (string drive, string path, string filename, string extension) f))
            Assert.AreEqual (("C", "C:\\Work\\dineshn", "words", ".txt"), f);
      }

      [TestMethod]
      public void FailTest () {
         string[] FailArray = { "C//Work.txt", "c:\\work\\input.pdf", "C:\\work\\inputpdf", "C:\\work\\input.PDF",
                "C:\\work//input.pdf", ":\\Work\\input.pdf","C:@work\\input.pdf","C:\\work\\input.pdf#"};
         int j = FailArray.Length;
         for (int i = 0; i < j; i++)
            Assert.ThrowsException<ArgumentException> (() => fp.Parse (FailArray[i]));
      }
   }
}