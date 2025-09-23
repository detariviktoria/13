using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal abstract class Noveny : IEloleny
    {

        public int Sor { get; }
        public int Oszlop { get; }

        public int Energia { get; private set; }
        public List<IEloleny> Szomszedok { get; };

        public Noveny(int sor, int oszlop, List<IEloleny> szomszedok)
        {
            Sor = sor;
            Oszlop = oszlop;
            Energia = 5; // induló érték
            Szomszedok = szomszedok;
        }


        public abstract void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop);
        public bool ElE
        {
            
                if (Energia <= 0)
                    return false;

                // Ha minden szomszéd nyúl → elpusztul
                int nyulakSzama = Szomszedok.Count(e => e is Nyul);
                if ( nyulakSzama == Szomszedok.Count)
                    return false;
            
          return true;
        }

        public void NovelEnergia()
        {
            Energia++;
        }
        public void CsokkentEnergia()
        {
            Energia--;
        }

        
        
    }
}
