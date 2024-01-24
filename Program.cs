using System.Text;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         ComplexNumber input1 = new ();
         input1=input1.ComplexNum ("5+3i");
         ComplexNumber input2 = new ();
         input2 = input2.ComplexNum ("6-8i");
         ComplexNumber output1 = ComplexNumber.Add (input1, input2);
         Console.WriteLine (output1);
      }
   }
   class ComplexNumber {
      public ComplexNumber () {
         realPart = 0;
         imaginaryPart = 0;
         sign = '+';
      }
      
      public static ComplexNumber Add (ComplexNumber c1, ComplexNumber c2) {
         int finalReal = c1.realPart + c2.realPart;
         int finalImaginary = c2.sign == '+' ? c1.imaginaryPart + c2.imaginaryPart : c1.imaginaryPart - c2.imaginaryPart;
         char sign = finalImaginary.ToString ().Contains ('-') ? '-' : '+';
         return ComplexNum (finalReal, finalImaginary, sign);
      }

      public static ComplexNumber Subtract(ComplexNumber c1, ComplexNumber c2) {
         int finalReal = c1.realPart - c2.realPart;
         int finalImaginary = c2.sign == '-' ? c1.imaginaryPart + c2.imaginaryPart : c1.imaginaryPart - c2.imaginaryPart;
         char sign = finalImaginary.ToString ().Contains ('-') ? '-' : '+';
         return ComplexNum (finalReal, finalImaginary, sign);
      }

      public static  ComplexNumber ComplexNum (int Real, int Imaginary, char sign) {
         ComplexNumber n = new () {
            realPart = Real,
            imaginaryPart = Imaginary,
            sign = sign
         };
         return n;
      }
      public ComplexNumber ComplexNum (string input) {
         StringBuilder real = new();
         StringBuilder imaginary = new ();
         char SignI='+';
         for(int i=0;i<input.Length;i++) {
            char currentDigit = input[i];
            if (i+1 == input.Length) break;
            char nextDigit = input[i+1];
            switch (currentDigit) {     
               case var expression when (char.IsNumber (currentDigit) && (char.IsNumber (nextDigit) || char.IsLetter (nextDigit)) && nextDigit == 'i'):
                  imaginary.Append (currentDigit);
                  break;
               case var expression when char.IsNumber (currentDigit):
                  real.Append (currentDigit);
                  break;
               case var expression when currentDigit is '+' or '-' && input.IndexOf (currentDigit) > 0:
                  SignI = currentDigit;
                  break;
            }
         }
         int RealPart = int.Parse (real.ToString ());
         int ImaginaryPart = int.Parse (imaginary.ToString ());
         ComplexNumber n = new () {
            realPart = RealPart,
            imaginaryPart = ImaginaryPart,
            sign = SignI
         };
         return n;
      }

      public override string ToString () {
         return this.realPart.ToString () + this.imaginaryPart.ToString () + "i";
      }

      int realPart { get; set; }
      int imaginaryPart { get; set; }
      char sign { get; set; }
   }
}