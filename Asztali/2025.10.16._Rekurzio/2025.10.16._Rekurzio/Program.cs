using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._16._Rekurzio
{
    internal class Program
    {
        static int n = 20;
        static char[,] matrix = new char[n, n];
        static Random rand = new Random();
        //static private int n;
        static void Main(string[] args)
        {
            //Rekurziok();
            // Generáljon ki x-et és o-t 75%-os valószínűséggel!
            // Egy 20x20-as mátrixban!
            // Számolja ki a kialakult szigetek számát!
            // Rekurcióval

            MatrixGeneralas();
            KiirMatrix();

        }

        private static void KiirMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void MatrixGeneralas()
        {
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int r = rand.Next(0, 100);
                    if (r < 75)
                        matrix[i, j] = 'x';
                    else
                        matrix[i, j] = 'o';
                }
            }
        }

        private static void Rekurziok()
        {
            //n = 0;
            //RekurzioEljaras();
            //int a = 7;
            //RekurzioEljaras2(a);
            //int c = RekurzioFuggveny(7);
            //int fib = Fibonacci(7);
        }
        

        //private static int Fibonacci(int k)
        //{
        //    if(k == 0) { return 0; }
        //    if (k == 1) { return 1; }

        //}

        //private static int RekurzioFuggveny(int k)
        //{
        //    if (k <= 1) return 1;
        //    return k = RekurzioFuggveny(k - 1);
        //}

        //private static void RekurzioEljaras2(int a)
        //{
        //    if (a <= 0) return;
        //    Console.WriteLine("körte");
        //    RekurzioEljaras2(a-1);
        //}

        //private static void RekurzioEljaras()
        //{
        //    if (n == 10)
        //        return;
        //    Console.WriteLine("alma");
        //    n++;
        //    RekurzioEljaras();
        //}
    }
}
