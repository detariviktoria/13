using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal abstract class Allat : IEloleny
    {
        public int Eletkor { get; private set; }
        public Nem Nem { get; } 
        public int Energia { get; private set; }

        public abstract bool ElE { get; }
        public abstract List<(int, int, IEloleny)> UjEloleny { get; protected set; }


        //Konstruktor
        public Allat(int energia, Nem nem)
        {
            Eletkor = 0;
            Nem = nem;
            Energia = energia;
        }

        public abstract void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop);
        

        public void NovelEnergia()
        {
            Energia++;
        }
        public void CsokkentEnergia()
        {
            Energia--;
        }
        public void NovelEletkor()
        {
            Eletkor++;
        }

        public bool VanEUresMezoKorulotte(IEloleny[,] racs, int sor, int oszlop)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (sor + i > -1 && oszlop + j > -1 && sor + i < racs.GetLength(0) && oszlop + j < racs.GetLength(1))
                    {
                        if (racs[sor + i, oszlop + j] == null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public bool ElE => Eletkor <= MaximumEletkor && Energia > 0;

    }
}
