
namespace _2025_10_16_Rekurzio
{
    internal class Program
    {
        static private int n;
        static void Main(string[] args)
        {
            //Rekurziok();
            // Generáljon ki x-et és o-t. o-t 75%-os valószínűséggel egy 20x20-as mátrixban!
            // Számolja meg a kialakult szigetek számát!


        }

        private static void Rekurziok()
        {
            n = 0;
            RekurzioEljaras();

            int a = 7;
            RekurzioEljaras2(a);

            //7! = 7 * 6 * 5 * 4 * 3 * 2 * 1
            int c = RekurzioFuggveny(7);
            Console.WriteLine(c);

            // Fibonacci sorozat 
            // a(0), a(1), a(n) = a(n-1) + a(n-2)
            //int fibr = FibonacciRek(50);
            //Console.WriteLine(fibr);

            int fibi = FibonacciIteracio(1000);
            Console.WriteLine(fibi);
        }

        private static int FibonacciIteracio(int k)
        {
            int a = 0;
            int b = 1;
            int c = 0;
            for (int i = 0; i < k; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return a;
        }

        private static int FibonacciRek(int k)
        {
            if (k == 0) return 0;
            if(k == 1) return 1;
            return FibonacciRek(k - 1) + FibonacciRek(k - 2);
        }

        private static int RekurzioFuggveny(int k)
        {
            if (k <= 1) return 1;
            return k * RekurzioFuggveny(k - 1);
        }

        private static void RekurzioEljaras2(int a)
        {
            if (a <= 0) return;
            RekurzioEljaras2(a - 1);
            Console.WriteLine("körte");
        }

        private static void RekurzioEljaras()
        {
            if (n == 10) return;
            Console.WriteLine(n+". alma");
            n++;
            RekurzioEljaras();
        }
    }
}
