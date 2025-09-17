using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{
    // A Nyul osztály az Állatból származik, konkrét megvalósítás nyúl számára.
    
    internal class Nyul : Allat
    {
        // Statikus, minden nyúlra érvényes maximális élettartam (pl. 7 év)
        public override int MaxEletkor { get; } = 7;

        // Szaporodási esély százalékban (0-100 között)
        public double SzaporodasiEsely { get; }

        // Konstruktor: neme és szaporodási esélye beállítható
        public Nyul(Nem nem, double szaporodasiEsely) : base(nem)
        {
            SzaporodasiEsely = szaporodasiEsely;
        }

        // Megvalósítja a szaporodik-e metódust
        public override bool SzaporodikE()
        {
            // Véletlenszerűen dönt: szaporodik-e most
            Random r = new Random();
            return r.NextDouble() < (SzaporodasiEsely / 100.0);
        }

    }
    } 
