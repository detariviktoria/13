using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_01_FaSzerkezet
{
    internal class Csomopont //Node
    {
        public int Ertek { get; }
        public List<Csomopont> utodok = new List<Csomopont>();
        public int Szint { get; }
        public Csomopont Szulo { get; }

        public Csomopont(int ertek, int szint, Csomopont szulo)
        { 
            Ertek = ertek;
            Szint = szint;
            Szulo = szulo;
        }
    }
}
