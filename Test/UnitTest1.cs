using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {

      FileParser fp = new ();

      [TestMethod]
      public void PassTest () {
         Assert.AreEqual ("C:\\WORK\\DINESHN\\WORDS.TXT", fp.Parse ("C:\\Work\\dineshn\\words.txt"));
         Assert.AreEqual ("C:\\WORK\\DINESHN\\WORDS.TXT", fp.Parse ("C:/Work/dineshn/words.txt"));
         Assert.AreEqual ("C:\\WORK\\INPUT.TXT", fp.Parse ("C:/Work/input.txt"));
         if (FileParser.TryFileParse ("C:/Work/dineshn/words.txt", out (string drive, string path, string filename, string extension) f))
            Assert.AreEqual (("C", "C:\\WORK\\DINESHN", "WORDS", ".TXT"), f);
      }

      [TestMethod]
      public void FailTest () {
         string[] FailArray = { "C//Work.txt","C:\\work\\inputpdf","C:\\work//input.pdf",
            ":\\Work\\input.pdf","C:@work\\input.pdf","C:\\work\\input.pdf#"};
         int j = FailArray.Length;
         for (int i = 0; i < j; i++)
            Assert.ThrowsException<ArgumentException> (() => fp.Parse (FailArray[i]));
      }
   }
}