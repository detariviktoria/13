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

        public abstract bool SzaporodikE();
        public abstract void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop);
        public abstract void Szaporodik(List<IEloleny> nyulSzomszedok, IEloleny[,] racs, int sor, int oszlop);

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



    }
}
