using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._01._Utodok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int szam = random.Next(0, 101);

            (int, int) szamok = Gyerekek(szam);
            

            int szam1 = BalGyerek(1);
            int szam2 = JobbGyerek(1);

            Console.WriteLine($"Ennek a számnak ezek az utódai: {szam1}, {szam2}");
            Console.WriteLine($"Ennek a számnak ezek az utódai({szam}): {szamok}");

            List<int> szulok = OsszesSzulo(7);

            Console.WriteLine($"A szám szülei:");
            foreach (int szulo in szulok)
            {
                Console.Write(szulo + " ");
            }
            Console.WriteLine();


            Console.ReadKey();

            
        }

        private static List<int> OsszesSzulo(int n)
        {
            List<int> szulok = new List<int>();

            while (n != 0)
            {
                n = Szulo(n);  
                szulok.Add(n);
            }

            return szulok;
        }

        private static int Szulo(int n)
        {
            return (n - 1) / 2;
        }

        private static int BalGyerek(int n)
        {
            return 2 * n + 1;
        }

        private static int JobbGyerek(int n)
        {
            return 2 * n + 2;
        }


        private static (int, int) Gyerekek(int v)
        {
            int szam1 = v + (v + 1);
            int szam2 = szam1 + 1;

            return (szam1, szam2);
        }
    }
}
