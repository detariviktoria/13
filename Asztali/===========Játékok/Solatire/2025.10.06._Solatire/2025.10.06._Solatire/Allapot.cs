using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._06._Solatire
{
    internal class Allapot
    {
        public int[,] Palya { get; }
        public bool Vegallapot => GolyokSzama() == 1;

        public Allapot Szulo { get; }

        public Allapot(int[,] palya, Allapot szulo)
        {
            Palya = palya;
            Szulo = szulo;
        }

        private int GolyokSzama()
        {
            int db = 0;
            // ... Egyéni megoldás
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    if (Palya[i, j] == 1) db++;
            return db;
        }
        public void Kiir()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Palya[i, j] == -1) Console.Write("  ");
                    else if (Palya[i, j] == 1) Console.Write("● ");
                    else Console.Write("○ ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public List<Allapot> KovetkezoAllapotok()
        {
            List<Allapot> ujAllapotok = new List<Allapot>();
            int[,] iranyok = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (Palya[i, j] == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            int dx = iranyok[k, 0];
                            int dy = iranyok[k, 1];
                            int koztiX = i + dx;
                            int koztiY = j + dy;
                            int celX = i + 2 * dx;
                            int celY = j + 2 * dy;

                            if (celX >= 0 && celX < 7 && celY >= 0 && celY < 7)
                            {
                                if (Palya[koztiX, koztiY] == 1 && Palya[celX, celY] == 0)
                                {
                                    int[,] uj = (int[,])Palya.Clone();
                                    uj[i, j] = 0;
                                    uj[koztiX, koztiY] = 0;
                                    uj[celX, celY] = 1;
                                    ujAllapotok.Add(new Allapot(uj, this));
                                }
                            }
                        }
                    }
                }
            }
            return ujAllapotok;
        }
    }
}
