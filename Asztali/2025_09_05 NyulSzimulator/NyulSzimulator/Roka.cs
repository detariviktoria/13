using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Roka : Allat
    {
        public int MaximumEletkor { get; }
        public int SzaporodasiEsely { get; }

        private static Random r = new Random();

        // Konstruktor
        public Roka(int energia, Nem nem, int szaporodasiEsely) : base(energia, nem)
        {
            MaximumEletkor = r.Next(5, 9); // [5;8]
            SzaporodasiEsely = szaporodasiEsely;
            UjEloleny = new List<(int, int, IEloleny)>();
        }

        

        // Szomszéd állatok számlálása
        public int AllatSzomszedok(IEloleny[,] racs, int sor, int oszlop, Type allat)
        {
            int db = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int ujSor = sor + i;
                    int ujOszlop = oszlop + j;

                    if (ujSor >= 0 && ujSor < racs.GetLength(0) &&
                        ujOszlop >= 0 && ujOszlop < racs.GetLength(1))
                    {
                        if (racs[ujSor, ujOszlop] != null &&
                            racs[ujSor, ujOszlop].GetType() == allat)
                        {
                            db++;
                        }
                    }
                }
            }
            return db;
        }


// Szimulációs lépés
public override void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop)
        {
            NovelEletkor();

            // +1 energia ha >= 3 nyúl van mellette
            int nyulak = AllatSzomszedok(racs, sor, oszlop, typeof(Nyul));
            if (nyulak >= 3)
                NovelEnergia();

            // -1 energia ha nincs üres mező
            if (!VanEUresMezoKorulotte(racs, sor, oszlop))
                CsokkentEnergia();
        }
    }
}
