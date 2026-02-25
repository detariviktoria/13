using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Repa : Noveny
    {

        public Repa(int sor, int oszlop, List<IEloleny> szomszedok)
            : base(sor, oszlop, szomszedok)
        {
        }

        public override void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop)
        {
            int nyulakSzama = Szomszedok.Count(e => e is Nyul);
            if (nyulakSzama > 0) // van legalább egy Nyúl
            {
                CsokkentEnergia();
            }
        }
    }
}
