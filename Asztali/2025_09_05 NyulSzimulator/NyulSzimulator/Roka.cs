using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Roka : Allat
    {
        const int maximumEletkor = 10;
        const int szaporodasiEsely = 30;
        Random r = new Random();

        //Konstruktor
        public Roka(int energia, Nem nem) : base(5, nem)
        { }

        public override bool SzaporodikE()
        {
            return r.Next(100) < szaporodasiEsely;
        }

        public override bool ElE => Eletkor <= maximumEletkor && energia > 0;

        public override void Szimulacioslepes(IEloleny[,] racs, int sor, int oszlop)
        {
            Noveleletkor();

            // 1. Nyulak száma körülötte
            var nyulPoziciok = new List<(int, int)>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int x = sor + i;
                    int y = oszlop + j;
                    if (x >= 0 && y >= 0 && x < racs.GetLength(0) && y < racs.GetLength(1))
                    {
                        if (racs[x, y] is Nyul)
                            nyulPoziciok.Add((x, y));
                    }
                }
            }

            // 2. Energia nő, ha legalább 3 nyúl van körülötte
            if (nyulPoziciok.Count >= 3)
                NovelEnergia();

            // 3. Véletlenszerűen kiválasztott nyulat megeszi
            if (nyulPoziciok.Count > 0)
            {
                var idx = r.Next(nyulPoziciok.Count);
                var (nx, ny) = nyulPoziciok[idx];
                racs[nx, ny] = null; // "megette" a nyulat
            }
        
        //minden nyulnal legyen az energia 5
        //vizsgalom h a nyul korul nincsenek baratok akkor fogyjon egyel


    }

    }
}
