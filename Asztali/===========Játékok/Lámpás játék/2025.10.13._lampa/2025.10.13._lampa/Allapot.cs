using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._13._lampa
{
    internal class Allapot
    {
        public bool[,] Palya { get; }
        public Allapot Szulo { get; }
        public int Szint { get; }
        public bool Vegallapot => FenyekSzama() == 0;
        public int Szint { get; }

        public Allapot(bool[,] palya, Allapot szulo)
        {
            Palya = palya;
            Szulo = szulo;
            Szint = szulo.Szint + 1;
        }

        public int FenyekSzama()
        {
            int db = 0;
            for (int i = 0; i < Palya.GetLength(0); i++)
            {
                for (int j = 0; j < Palya.GetLength(1); j++)
                {
                    if (Palya[i, j]) db++;
                }
            }
            return db;
        }

        public void AllapotValtozas(int s, int o)
        {
            
            if (s> 0) Palya[s-1, o] = !Palya[s-1,o];
            if(s+1 < Palya.GetLength(0)) Palya[s+1,o] = !Palya[s+1,o];
            if (o > 0) Palya[s, o - 1] = !Palya[s, o - 1];
            if(o+1 < Palya.GetLength(1)) Palya[s, o+1] = !Palya[s, o+1];
            Palya[s, o] = !Palya[s, o];
        }

       
    }
}
