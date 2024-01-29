// --------------------------------------------------------------------------------------------------------------------
// Training~A training program for new joinees at metamation,Batch-July 2023
// Copyright(c) Metamation India
// --------------------------------------------------------------------------------------------------------------------
// Program.cs
// Custom file parser
// A custom class called FileParser is created along with methods like TryFileParse and Parse to get path of file 
// Any valuable string with the file path format will be parsed and a tuple named filePath with drive,path,filename,
// extension will be stored 
// For example,the "C:/dineshn/words.txt" will have output of filepath(C,C:\dineshn,words,.txt) for TryFileParse method
// And will have "C:\\dineshn\\words.txt" as output for Parse method
// --------------------------------------------------------------------------------------------------------------------
namespace Training {
   internal class Program {
      /// <summary>Method which gets input path from user and TryFileParse it,
      /// if it is correct format,will display Drive,path, file name,extension
      /// </summary>
      public static void Main () {
         Console.WriteLine ("Enter the file path or directory");
         string input = Console.ReadLine ();
         FileParser fp = new ();
         if (fp.TryFileParse (input, out (string drive, string path, string filename, string extension) f))
            Console.WriteLine ($"Drive:{f.drive}\nPath:{f.path}\nFileName:{f.filename}\nExtension:{f.extension}");
      }
   }

   /// <summary>Class which holds the methods to parse a file</summary>
   public class FileParser {
      /// <summary>Method which check whether give file path is in correct format with proper extension</summary>
      /// <param name="input">Input file path as string</param>
      /// <param name="filePath">filepath tuple which holds drive, path, filename and extension of the file</param>
      /// <returns>Returns the filepath tuple</returns>
      public bool TryFileParse (string input, out (string drive, string path, string fileName, string extension) filePath) {
         EState s = EState.A;
         Action none = () => { }, todo;
         string drive = null, path = null, fileName = null, extension = null;
         foreach (var ch in input.Trim () + "^") {
            (s, todo) = (s, ch) switch {
               (EState.A, >= 'A' and <= 'Z') => (EState.B, () => drive += ch),
               (EState.B, ':') => (EState.C, none),
               (EState.C or EState.E, '\\' or '/') => (EState.D, () => path += ch),
               (EState.D or EState.E, (>= 'A' and <= 'Z') or (>= 'a' and <= 'z')) => (EState.E, () => path += ch),
               (EState.E, '.') => (EState.F, none),
               (EState.F or EState.G, >= 'a' and <= 'z') => (EState.G, () => extension += ch),
               (EState.G, '^') => (EState.H, none),
               _ => (EState.X, none),
            };
            todo ();
         }
         if (s == EState.H) {
            path = string.Join ("", path.Replace ("/", "\\"));
            string[] parts = path.Split ('\\');
            fileName = parts[^1];
            path = drive + ':' + string.Join ("\\", parts.SkipLast (1));
            extension = "." + extension;
            filePath = (drive, path, fileName, extension);
            return true;
         }
         filePath = ("", "", "", "");
         return false;
      }

      /// <summary>Method to return filepath along with filename</summary>
      /// <returns>If input is in correct format,returns the whole path of file along with file name</returns>
      /// <exception cref="ArgumentException">If input string is not in correct format it throws Argumentexception</exception>
      public string Parse (string input) {
         if (TryFileParse (input, out (string drive, string path, string fileName, string extension) f)) {
            (_, string path, string fileName, string extension) = f;
            return path + '\\' + fileName + extension;
         }
         throw new ArgumentException ("Input is not in valid format");
      }

      /// <summary>Enumerator to store states of the function</summary>
      /// State Diagram image: File://W://Training//StateDiagram.jpg
      enum EState { A, B, C, D, E, F, G, H, X };
   }
}