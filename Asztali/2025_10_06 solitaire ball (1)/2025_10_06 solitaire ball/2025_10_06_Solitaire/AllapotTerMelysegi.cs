using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_06_Solitaire
{
    internal class AllapotTerMelysegi
    {
        // mélységi keresést (DFS) végez
        //(gyorsabban talál megoldást, de nem biztos, hogy a legrövidebbet)
        public Allapot KezdoAllapot { get; }

        public AllapotTerMelysegi(string utvonal)
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
            int[,] palya = new int[n, n];

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return palya;
        }

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

        private Allapot VegallapotKereses()
        {
            Stack<Allapot> allapotok = new Stack<Allapot>();
            allapotok.Push(KezdoAllapot);
            Allapot akt;
            do
            {
                akt = allapotok.Pop();
                UjAllapotok(akt, allapotok);
            } while (allapotok.Count > 0 && !akt.VegallapotE);
            return akt;
        }

        private void UjAllapotok(Allapot akt, Stack<Allapot> allapotok)
        {
            int[,] p = akt.Palya;
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i, j] == 1)
                    {
                        List<Allapot> ujAllapotok = Ugrik(akt, i, j);
                        if (ujAllapotok.Count > 0)
                        {
                            ujAllapotok.ForEach(c => allapotok.Push(c));
                        }
                    }
                }
            }
        }

        private List<Allapot> Ugrik(Allapot akt, int i, int j)
        {
            List<Allapot> ujAllapotok = new List<Allapot>();
            int[,] p = akt.Palya;
            if (j + 2 < p.GetLength(1) && p[i, j + 1] != 3 && p[i, j + 1] == 1 && p[i, j + 2] == 0)
            {
                int[,] ujp = (int[,])p.Clone();
                ujp[i, j] = 0;
                ujp[i, j + 1] = 0;
                ujp[i, j + 2] = 1;
                ujAllapotok.Add(new Allapot(ujp, akt, akt.golyokszama - 1));
            }
            if (j - 2 >= 0 && p[i, j - 1] != 3 && p[i, j - 1] == 1 && p[i, j - 2] == 0)
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
    }
}
