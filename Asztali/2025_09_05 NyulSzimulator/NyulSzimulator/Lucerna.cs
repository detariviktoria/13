using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Lucerna : Noveny
    {
        public Lucerna(int sor, int oszlop, List<IEloleny> szomszedok)
            : base(sor, oszlop, szomszedok)
        {
        }

        public override void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop)
        {
            int lucernakSzama = Szomszedok.Count(e => e is Lucerna);
            if (lucernakSzama == 0) // nincs mellette Lucerna
            {
                CsokkentEnergia();
            }
        }
    }
}
