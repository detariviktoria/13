using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Nyul : Allat
    {
        const int maximumEletkor = 10;
        const int szaporodasiEsely = 30;
        Random r = new Random();

        //Konstruktor
        public Nyul(int energia, Nem nem) : base(5, nem)
        { }

        public override bool SzaporodikE()
        {
            return r.Next(100) < szaporodasiEsely;
        }

        public override bool ElE => Eletkor <= maximumEletkor && energia > 0;
        //public override bool ElE()
        //{
        //    return Eletkor <= maximumEletkor;
        //}

        public override void Szimulacioslepes(IEloleny[,] racs, int sor, int oszlop)
        {
            Noveleletkor();

            // Nyúl megnézi, van-e alatta fű
            if (racs[sor, oszlop] is Fu fu && fu.ElE)
            {
                EgyelFu(fu);
            }

            if (Nyulszomszedokszama(racs, sor, oszlop) == 0)
                CsokkentEnergia();
        }

        public int Nyulszomszedokszama(IEloleny[,] racs, int sor, int oszlop)
        {
            int db = 0;
            for(int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (sor + i > -1 && oszlop + j > -1 && sor + i < racs.GetLength(0) && oszlop + j < racs.GetLength(1))
                    {
                        if (racs[sor + i, oszlop + j] != null && racs[sor + i, oszlop + j].GetType() == typeof(Nyul))
                        {
                            db++;
                        }
                    } 

                    //HF PROGRAMBAN IRNI EG FUGGVENYT AMI KIIRATJA A DARABSZAMOKAT 
                    
                }
            }
            return db;
        }

        public void EgyelFu(Fu fu)
        {
            if (fu.ElE)
            {
                energia += fu.TapErtek;
                fu.Kiszarad(); // miután megette, lehet, hogy kiszárad
            }
        }

        
    }
}
