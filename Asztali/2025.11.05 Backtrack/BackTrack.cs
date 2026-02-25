using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Backtrack
{
    internal class BackTrackRun
    {
        private List<List<Cella>> labirintus = new List<List<Cella>>();
        private int n, m;
        private Cella Start;

        public BackTrackRun(string utvonal)
        {
            Fajlbeolvas(utvonal);
            n = labirintus.Count;
            m = labirintus[0].Count;
        }

        /// <summary>
        /// Adatok kinézete minden egyes jelölőt egy szóköz válasszon el!
        /// </summary>
        /// <param name="utvonal"> a fájl útvonala</param>
        private void Fajlbeolvas(string utvonal)
        {
            using (StreamReader sr = new StreamReader(utvonal))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    LabirintushozAdas(sor);
                }
            }
        }

        private void LabirintushozAdas(string sor)
        {
            List<Cella> sorlista = new List<Cella>();
            for (int i = 0; i < sor.Length; i+=2)
            {
                sorlista.Add(new Cella(sor[i],labirintus.Count,i/2));
                if (sor[i] == 'S') Start = sorlista.Last();
            }
            labirintus.Add(sorlista);
        }

        public void Run()
        {
            int sor = Start.S;
            int oszlop = Start.O;
            Cella end = EndKeresese(sor, oszlop);
            LabirintusKiiratas();
        }

        private void EndKeresese(int s, int o)
        {
            LabirintusKiiratas();
            Thread.Sleep(1000);
            Console.Clear();
            labirintus[s][o].Jel = '.';
            Cella akt = labirintus[s][o];
            if (akt.Jel == 'E')
            {
                Console.WriteLine("Megtaláltuk!");
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int irany = akt.LehetosegValaszt();
                switch (irany)
                {
                    case 0:
                        if (o + 1 < m && labirintus[s][o + 1].Ute)
                        {
                            EndKeresese(s, o + 1);
                        }
                        break;
                    case 1:
                        if (s + 1 < n && labirintus[s + 1][o].Ute)
                        {
                            EndKeresese(s + 1, o);
                        }
                        break;
                    case 2:
                        if (o - 1 >= 0 && labirintus[s][o - 1].Ute)
                        {
                            EndKeresese(s, o - 1);
                        }
                        break;
                    case 3:
                        if (s - 1 >= 0 && labirintus[s - 1][o].Ute)
                        {
                            EndKeresese(s - 1, o);
                        }
                        break;
                }
            }
        }

        public void LabirintusKiiratas()
        {
            for (int i = 0; i < labirintus.Count; i++)
            {
                for (int j = 0; j < labirintus[i].Count; j++)
                {
                    Console.Write(labirintus[i][j].Jel);
                }
                Console.WriteLine();
            }
        }
    }
}
