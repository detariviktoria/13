using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{

    // Az Állat absztrakt osztály minden állat (pl. nyúl, róka) közös tulajdonságait és viselkedését tartalmazza.
    // Megvalósítja az IEloleny interfészt.
    internal abstract class Allat : IEloleny
    {
        // Az állat életkora (csak lekérdezhető)
        public int Eletkor { get; protected set; }

        // Az állat neme (Nőstény vagy Hím)
        public Nem Nem { get; }

        // Maximális élettartam (leszármazott határozza meg)
        public abstract int MaxEletkor { get; }

        // Az állat életben van-e (ha még nem érte el a maximális életkort)
        public bool ElE => Eletkor < MaxEletkor;

        // Konstruktor: kezdetben 0 éves, neme beállítható
        public Allat(Nem nem)
        {
            Eletkor = 0;
            Nem = nem;
        }

        // Metódus az életkor növelésére
        public void NoveleEletkor()
        {
            Eletkor++;
        }

        // IEloleny metódus: szaporodik-e (absztrakt, leszármazott határozza meg)
        public abstract bool SzaporodikE();

        // Szimulációs lépés: minden körben öregszik
        public void Lepes()
        {
            NoveleEletkor();
        }

    }
}
