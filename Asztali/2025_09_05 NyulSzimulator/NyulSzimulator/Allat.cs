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
        public Nem Nem { get; } // 0 - hím, 1 - nőstény
        protected int energia { get;  set; }



        public abstract bool ElE { get; }
        //public bool ElE { get { return true; } }


        //Konstruktor
        public Allat(int energia,Nem nem)
        {
            Eletkor = 0;
            Nem = nem;
            energia = this.energia;
        }

        public abstract bool SzaporodikE();
        public abstract void Szimulacioslepes(IEloleny[,] racs, int sor, int oszlop);
        public void NovelEnergia()
        {
            energia++;
        }
        public void CsokkentEnergia()
        {
            energia--;
        }

        public void Noveleletkor()
        {
            Eletkor++;
        }

    }
}
