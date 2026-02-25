using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_06_Solitaire
{
    internal class Allapot2
    {
        public int[,] Palya { get;}
        public bool VegAllapotE => Golyokszama() == 1;
        public Allapot2 Szulo { get; }

        public Allapot2(int[,] palya, Allapot2 szulo)
        { 
            Palya = palya;
            Szulo = szulo;
        }

        private int Golyokszama()
        {
            int db = 0;
            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    if (Palya[i, j] == 1) db++;
                }
            }
            return db;
        }
    }
}
