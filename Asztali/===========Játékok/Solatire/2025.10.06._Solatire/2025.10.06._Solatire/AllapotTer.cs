using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._06._Solatire
{
    internal class AllapotTer
    {
        public Allapot KezdoAllapot { get; }

        public AllapotTer(string utvonal)
        {

            int[,] palya = PalyaFajlbol(utvonal);
            if (palya != null)
            {
                KezdoAllapot = new Allapot(palya, null);
            }
        }

        private int[,] PalyaFajlbol(string utvonal)
        {
            int[,] palya = new int[7, 7];

            List<string> sorLista = new List<string>();
            StreamReader f = new StreamReader(utvonal);

            while (!f.EndOfStream)
            {
                string sor = f.ReadLine();
                if (!string.IsNullOrWhiteSpace(sor))
                    sorLista.Add(sor);
            }
            f.Close();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (sorLista[i][j] == ' ') palya[i, j] = -1;
                    else if (sorLista[i][j] == '1') palya[i, j] = 1;
                    else palya[i, j] = 0;
                }
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
            }
            while (akt.Szulo != null);
            

            return megoldas;
        }

        private Allapot VegallapotKereses()
        {
            Queue<Allapot> allapotok = new Queue<Allapot>();
            allapotok.Enqueue(KezdoAllapot);
            Allapot akt;
            do
            {
                akt = allapotok.Dequeue();
                UjAllapotok(akt, allapotok);
            } while (!akt.Vegallapot);
            return akt;
        }


        private void UjAllapotok(Allapot akt, Queue<Allapot> allapotok)
        {
            int[,] p = akt.Palya;
            for(int i  = 0; i < p.GetLength(0); i++)
            {
                for(int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i, j] == 1)
                    {
                        Allapot ujAllapot = Ugrik(p, i, j);
                        if (ujAllapot != null)
                        {
                            allapotok.Enqueue(ujAllapot);
                        }
                    }
                }
            }
        }

        private Allapot Ugrik(Allapot akt, int i, int j)
        {
            Allapot ujAllapot;
            int[,] p = akt.Palya;
            if (j+2 < p.GetLength(1) && p[i,j+1] !=3 && p[i, j+1] == 1 && p[i, j+2] == 0)
            {
                int[,] ujp = p;
                ujp[i, j] = 0;
                ujp[i, j + 1] = 0;
                ujp[i, j + 2] = 1;
            }
                ujAllapot = new Allapot(ujp, akt);
        }

        

        public  void KiirKezdoAllapot()
        {
            Console.WriteLine("Beolvasott tábla:\n");
            KezdoAllapot.Kiir();
        }
    }
}
