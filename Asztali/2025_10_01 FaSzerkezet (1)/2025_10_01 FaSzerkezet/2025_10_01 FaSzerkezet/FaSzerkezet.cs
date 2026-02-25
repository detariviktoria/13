using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_01_FaSzerkezet
{
    // Van-e 13-al osztható szám?
    // Szélességi
    // Mélységi
    internal class FaSzerkezet
    {
        public Csomopont Kezdo;
        private Queue<Csomopont> sor = new Queue<Csomopont>();
        private List<Csomopont> csomopontok = new List<Csomopont>();
        private Random r = new Random();

        public FaSzerkezet()
        {
            Kezdo = new Csomopont(r.Next(10, 100), 0, null);
            csomopontok.Add(Kezdo);
        }

        public void Feltoltes()
        {
            sor.Enqueue(Kezdo);

            int i = 0;
            while (i < 12)
            {
                Csomopont akt = sor.Dequeue();
                UtodHozzaadas(akt);
                i += akt.utodok.Count;
                if (sor.Count == 0 && i != 12) sor.Enqueue(akt);
            }
            sor.Clear();
        }

        private void UtodHozzaadas(Csomopont akt)
        {
            int n = r.Next(0, 4);
            for (int i = 0; i < n; i++)
            {
                Csomopont u = new Csomopont(r.Next(10, 100), akt.Szint + 1, akt);
                akt.utodok.Add(u);
                sor.Enqueue(u);
                csomopontok.Add(u);
            }

            //Csomopont u1 = new Csomopont(r.Next(10, 100), akt.Szint + 1, akt);
            //Csomopont u2 = new Csomopont(r.Next(10, 100), akt.Szint + 1, akt);
            //akt.utodok.Add(u1);
            //akt.utodok.Add(u2);
            //sor.Enqueue(u1);
            //sor.Enqueue(u2);
            //csomopontok.Add(u1);
            //csomopontok.Add(u2);
        }

        public void KiiratasVerem()
        {
            Stack<Csomopont> verem = new Stack<Csomopont>();
            verem.Push(Kezdo);

            while (verem.Count > 0)
            {
                Csomopont cs = verem.Pop();
                Console.Write($"{cs.Ertek}({(cs.Szulo != null ? cs.Szulo.Ertek : 0 )}) " );
                for (int i = 0; i < cs.utodok.Count; i++)
                {
                    verem.Push(cs.utodok[i]);
                }
                if (verem.Count > 0 && cs.Szint < verem.Peek().Szint)
                    Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public void KiiratasSor()
        {
            Queue<Csomopont> sor = new Queue<Csomopont>();
            sor.Enqueue(Kezdo);

            while (sor.Count > 0)
            {
                Csomopont cs = sor.Dequeue();
                Console.Write($"{cs.Ertek}({(cs.Szulo != null ? cs.Szulo.Ertek : 0)}) ");
                for (int i = 0; i < cs.utodok.Count; i++)
                {
                    sor.Enqueue(cs.utodok[i]);
                }
                if (sor.Count > 0 && cs.Szint < sor.Peek().Szint)
                    Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public Csomopont CsomopontKivalasztRnd()
        {
            return csomopontok[r.Next(csomopontok.Count)];
        }

        public void ElemVisszafejtes(Csomopont cs)
        {
            Csomopont akt = cs;
            while (akt.Szulo != null)
            {
                Console.Write(akt.Ertek + " ");
                akt = akt.Szulo;
            }
            Console.WriteLine(akt.Ertek);
        }
    }
}
