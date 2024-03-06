namespace OperatorOverloadingInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4
            ////////////////////////
            ///Postfix increment operator

            int i = 3;
            Console.WriteLine(i);   // output: 3
            //The increment operator is supported in two forms: 
            //    the postfix increment operator, x++, and 
            //    the prefix increment operator, ++x.
            //The result of x++ is the value of x before the operation,
            //as the following example shows:
            Console.WriteLine(i++); // output: 3  //print then add
            Console.WriteLine(i);   // output: 4


            //Prefix increment operator
            int x = 3;
            Console.WriteLine(x);
            //The result of ++x is the value of x after the operation, as the following example shows:
            Console.WriteLine(++x);//add then print = 4
            Console.WriteLine(x); //4
            //Decrement operator --
            //Postfix decrement operator
            int w = 4;
            Console.WriteLine(w);//4
            Console.WriteLine(w--);// operation after will print 4
            Console.WriteLine(w);//3

            //Prefix decrement operator
            int z = 4;
            Console.WriteLine(z);//4
            Console.WriteLine(--z);// operation before will print 3
            Console.WriteLine(w);//3
        }
    }
    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.",
                    nameof(denominator));
            }
            num = numerator;
            den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);//(5/4) +(1/2)=>4/4+5+(2*1)/4

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}";
    }


}