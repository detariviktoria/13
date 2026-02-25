using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyolcKiralyno
{
    internal class Allapot
    {
        public int[,] Palya { get; private set; }
        public Allapot Szulo { get; }
        public bool VegallapotE => KiralynokSzama() == 8;
        public int Szint { get; }

        public Allapot(int[,] palya, Allapot szulo)
        {
            Palya = palya;
            Szulo = szulo;
            if (szulo == null) Szint = 0;
            else Szint = szulo.Szint + 1;
        }

        public int KiralynokSzama()
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

        public override string ToString()
        {
            string ki = "";
            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    ki += Palya[i, j];
                }
                ki += "\n";
            }
            ki += "\n";

            return ki;
        }
    }
}
