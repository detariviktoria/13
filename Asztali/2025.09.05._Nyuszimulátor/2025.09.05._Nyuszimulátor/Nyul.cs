using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{

    internal class Nyul : Allat
    {
        const int maximumEletkor = 10;
        const int szaporodasiEsely = 30;
        Random r = new Random();


        //Konstruktor
        public Nyul(Nem nem):base (nem) {
            

        }

        public override bool SzaporodikE()
        {
            return r.Next(100) < szaporodasiEsely;
        }

        public override bool Ele(int kor)
        {
            return maximumEletkor > kor;
        }
    }
}
