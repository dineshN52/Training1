using System.Text;
namespace Training {
   internal class Program {
      static void Main (string[] args) {
         ComplexNumber input1 = new (5, +3);
         ComplexNumber input2 = new (6, -8);
         ComplexNumber output1 = input1 + input2;
         ComplexNumber output2 = input1 - input2;
         ComplexNumber number = new ();
         number = number.Parse ("5+3i");
         Console.WriteLine (output1);
         Console.WriteLine (output2);
         Console.WriteLine (number);
      }
   }
   class ComplexNumber {
      public ComplexNumber () {
         realPart = 0;
         imaginaryPart = 0;
      }
      public ComplexNumber (int real, int imaginary) {
         realPart = real;
         imaginaryPart = imaginary;
      }

      public static ComplexNumber operator + (ComplexNumber c1, ComplexNumber c2) {
         int finalReal = c1.realPart + c2.realPart, finalImaginary = c1.imaginaryPart + c2.imaginaryPart;
         return new ComplexNumber (finalReal, finalImaginary);
      }

      public static ComplexNumber operator - (ComplexNumber c1, ComplexNumber c2) {
         int finalReal = c1.realPart - c2.realPart, finalImaginary = c1.imaginaryPart - c2.imaginaryPart;
         return new ComplexNumber (finalReal, finalImaginary);
      }

      public ComplexNumber Parse (string input) {
         StringBuilder real = new (), imaginary = new ();
         for (int i = 0; i < input.Length; i++) {
            if (i + 1 == input.Length) break;
            char currentDigit = input[i], nextDigit = input[i + 1];
            switch (currentDigit) {
               case var _ when (char.IsNumber (currentDigit) && (char.IsNumber (nextDigit) 
               || char.IsLetter (nextDigit)) && nextDigit == 'i'):
                  imaginary.Append (currentDigit);
                  break;
               case var _ when char.IsNumber (currentDigit):
                  real.Append (currentDigit);
                  break;
            }
         }
         int RealPart = int.Parse (real.ToString ()), ImaginaryPart = int.Parse (imaginary.ToString ());
         ComplexNumber n = new (RealPart, ImaginaryPart);
         return n;
      }

      public override string ToString () {
         if (imaginaryPart.ToString ().Contains ('-'))
            return this.realPart.ToString () + this.imaginaryPart.ToString () + "i";
         return this.realPart.ToString () + "+" + this.imaginaryPart.ToString () + "i";
      }

      public double Norm => Math.Sqrt (realPart * realPart + imaginaryPart * imaginaryPart);
      public int realPart { get; set; }
      public int imaginaryPart { get; set; }
   }
}