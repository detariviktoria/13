using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._29._Halmaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Töltson fel egy adatszerkezetet 50db [1,100] kzötti számmokkal!
            // Irassa  ki hány db egyedi szám van!
            // Csináld meg veremmel egy novekvő sorrendet 

            Random rnd = new Random();
            List<int> szamok = new List<int>();
            Stack<int> eredetiVerem = new Stack<int>();

            for (int i = 0; i < 50; i++)
            {
                int szam = rnd.Next(1, 101);
                eredetiVerem.Push(szam);
            }

            //var egyediSzamok = szamok.Distinct().ToList();

            //Console.WriteLine("Ennyi darab egyedi szám van: ", egyediSzamok.Count);

            Sorrend(eredetiVerem);
        }
        static Stack<int> Sorrend(Stack<int> verem)
        {
            Stack<int> segedverem = new Stack<int>();

            while (verem.Count > 0)
            {
                int current = verem.Pop();


                while (segedverem.Count > 0 && segedverem.Peek() > current)
                {
                    verem.Push(segedverem.Pop());
                }

                segedverem.Push(current);
            }
            return segedverem;
        }
    }
}
