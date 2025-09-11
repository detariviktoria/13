using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{
    internal abstract class Allat : IEloleny
    {
        public int Eletkor { get; } // lekérni letudom az értéket, de módosítani nem
        public Nem Nem { get; }
        public bool ElE =>  true;
        //public bool ElE { get { return true; } }

        public Allat(Nem nem) {
            Eletkor = 0;
            Nem = nem;
        }

        public abstract bool SzaporodikE();

        public abstract bool Ele(int Eletkor);
       
    }
}
