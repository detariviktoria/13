using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_06_Solitaire
{
    internal class AllapotTer
    {
        // szélességi keresést (BFS) végez
        //(a megoldást a legkevesebb lépéssel találja meg)
        public Allapot KezdoAllapot { get; }

        public AllapotTer(string utvonal)
        {
            int[,] palya = PalyaFajlbol(utvonal);
            if (palya != null)
            {
                KezdoAllapot = new Allapot(palya, null, GolyokSzama(palya));
            }
        }

        private int GolyokSzama(int[,] palya)
        {
            int db = 0;
            for (int i = 0; i < palya.GetLength(0); i++)
            {
                for (int j = 0; j < palya.GetLength(1); j++)
                {
                    if (palya[i, j] == 1) db++;
                }
            }
            return db;
        }

        private int[,] PalyaFajlbol(string utvonal, int n = 7)
        {
            int[,] palya = new int[n,n];

            try
            {
                //using (StreamReader sr = new StreamReader(utvonal))
                //{}
                StreamReader f = new StreamReader(utvonal);
                int i = 0;
                while (!f.EndOfStream)
                {
                    string sor = f.ReadLine();
                    for (int j = 0; j < n; j++)
                    {
                        palya[i, j] = sor[j] == '1' ? 1 : sor[j] == '0' ? 0 : 3;
                    }
                    i++;
                }
                f.Close();
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return palya;
        }

        /// <summary>
        /// Ez a függvény összegyűjti a lépéssorozatot a megtalált végállapottól visszafelé a kezdőállapotig.
        /// </summary>
        /// <returns></returns>
        public List<Allapot> MegoldasKeresese()
        {
            List<Allapot> megoldas = new List<Allapot>();

            Allapot akt = VegallapotKereses();

            do
            {
                megoldas.Add(akt);
                akt = akt.Szulo;
            } while (akt != null);

            return megoldas;           
        }


        /// <summary>
        /// Ez egy DFS:
        /// mindig a legutóbb hozzáadott állapottal folytatja,
        /// új lehetséges lépéseket generál(UjAllapotok()),
        /// ha megtalálja a végállapotot(1 golyó), leáll.
        /// </summary>
        /// <returns></returns>
        private Allapot VegallapotKereses()
        {
            Queue<Allapot> allapotok = new Queue<Allapot>();
            allapotok.Enqueue(KezdoAllapot);
            Allapot akt;
            do
            {
                akt = allapotok.Dequeue();
                UjAllapotok(akt, allapotok);
                //Console.WriteLine(akt.ToString()+" ");
            } while (allapotok.Count > 0 && !akt.VegallapotE);
            return akt;
        }

        private void UjAllapotok(Allapot akt, Queue<Allapot> allapotok)
        {
            int[,] p = akt.Palya;
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i, j] == 1)
                    {
                        List<Allapot> ujAllapotok = Ugrik(akt, i, j);
                        if (ujAllapotok.Count>0)
                        {
                            ujAllapotok.ForEach(c=>allapotok.Enqueue(c));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ez a függvény új táblákat (állapotokat) hoz létre minden lehetséges ugrás irányába:
        ///jobbra
        ///balra
        ///lefelé
        ///felfelé
        ///Minden új állapot az előzőből(akt) származik, és eggyeI kevesebb golyót tartalmaz.
        /// </summary>
        /// <param name="akt"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private List<Allapot> Ugrik(Allapot akt, int i, int j)
        {
            List<Allapot> ujAllapotok = new List<Allapot>();
            int[,] p = akt.Palya;
            if (j + 2 < p.GetLength(1) && p[i, j + 1] != 3 && p[i, j + 1] == 1 && p[i, j + 2] == 0)
            {
                int[,] ujp = (int[,]) p.Clone();
                ujp[i, j] = 0;
                ujp[i, j + 1] = 0;
                ujp[i, j + 2] = 1;
                ujAllapotok.Add(new Allapot(ujp, akt, akt.golyokszama-1));
            }
            if (j - 2 >=0 && p[i, j - 1] != 3 && p[i, j - 1] == 1 && p[i, j - 2] == 0)
            {
                int[,] ujp = (int[,])p.Clone();
                ujp[i, j] = 0;
                ujp[i, j - 1] = 0;
                ujp[i, j - 2] = 1;
                ujAllapotok.Add(new Allapot(ujp, akt, akt.golyokszama - 1));
            }
            if (i + 2 < p.GetLength(0) && p[i + 1, j] != 3 && p[i + 1, j] == 1 && p[i + 2, j] == 0)
            {
                int[,] ujp = (int[,])p.Clone();
                ujp[i, j] = 0;
                ujp[i + 1, j] = 0;
                ujp[i + 2, j] = 1;
                ujAllapotok.Add(new Allapot(ujp, akt, akt.golyokszama - 1));
            }
            if (i - 2 >= 0 && p[i - 1, j] != 3 && p[i - 1, j] == 1 && p[i - 2, j] == 0)
            {
                int[,] ujp = (int[,])p.Clone();
                ujp[i, j] = 0;
                ujp[i - 1, j] = 0;
                ujp[i - 2, j] = 1;
                ujAllapotok.Add(new Allapot(ujp, akt, akt.golyokszama - 1));
            }
            
            return ujAllapotok;
        }

        //private int[,] Clone(int[,] p)
        //{
        //    int[,] t = new int
        //}
    }
}
