using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_13_LightsOut
{
    internal class Allapot
    {
        public bool[,] Palya { get; private set; }
        public Allapot Szulo { get; }
        public bool VegallapotE => FenyekSzama() == 0 ;
        public int Szint { get;  }

        public Allapot(bool[,] palya, Allapot szulo)
        { 
            Palya = palya;
            Szulo = szulo;
            if (szulo == null) Szint = 0;
            else Szint = szulo.Szint + 1;
        }

        public int FenyekSzama()
        {
            int db = 0;
            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    if (!Palya[i, j]) db++;
                }
            }
            return db;
        }

        public void AllapotValtozas(int s, int o)
        {
            if (s > 0) Palya[s - 1, o] = !Palya[s - 1, o];
            if (s + 1 < Palya.GetLength(0)) Palya[s + 1, o] = !Palya[s + 1, o];
            if (o > 0) Palya[s, o - 1] = !Palya[s, o - 1];
            if (o + 1 < Palya.GetLength(1)) Palya[s, o + 1] = !Palya[s, o + 1];
            Palya[s, o] = !Palya[s, o];
        }

        public override string ToString()
        {
            string ki = "";
            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    ki += Palya[i, j] ? "." : "B";
                }
                ki+="\n";
            }
            ki += "\n";

            return ki;
        }
    }
}
