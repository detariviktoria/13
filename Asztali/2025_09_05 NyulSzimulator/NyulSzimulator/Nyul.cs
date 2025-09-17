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
        const int szaporodasiEsely = 50;
        public override List<(int, int, IEloleny)> UjEloleny { get; protected set; }
        Random r = new Random();

        //---------------------------------------------

        public Nyul(Nem nem, int energia = 5) : base(energia,nem)
        {
            UjEloleny = new List<(int, int, IEloleny)>();
        }

        //---------------------------------------------

        public override bool SzaporodikE()
        {
            return r.Next(100) < szaporodasiEsely;
        }

        public override bool ElE => Eletkor <= maximumEletkor && Energia > 0;

        public override void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop)
        {
            NovelEletkor();
            List<IEloleny> nyulSzomszedok = NyulSzomszedok(racs, sor, oszlop);
            if (nyulSzomszedok.Count == 0)
            {
                CsokkentEnergia();
            }
            else
            { 
                Szaporodik(nyulSzomszedok, racs, sor,oszlop);
            }

        }

        public override void Szaporodik(List<IEloleny> nyulSzomszedok, IEloleny[,] racs, int sor, int oszlop)
        {
            (int x, int y) = VanEUresMezoKorulotte(racs, sor, oszlop);
            if (r.Next(100)<szaporodasiEsely && nyulSzomszedok.Any(c => ((Nyul)c).Nem != ((Nyul)racs[sor, oszlop]).Nem) && x>-1)
            {
                UjEloleny.Add((x, y, new Nyul((Nem)r.Next(2))));
            }
        }

        //---------------------------------------------

        public List<IEloleny> NyulSzomszedok(IEloleny[,] racs, int sor, int oszlop)
        {
            List<IEloleny> nyulSzomszedok = new List<IEloleny>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (sor + i > -1 && oszlop + j > -1 && sor + i < racs.GetLength(0) && oszlop + j < racs.GetLength(1))
                    {
                        //if (racs[sor + i, oszlop + j]!=null && racs[sor + i, oszlop + j].GetType() == typeof(Nyul))
                        if (racs[sor + i, oszlop + j] is Nyul)
                        {
                            nyulSzomszedok.Add((Nyul)racs[sor+i, oszlop+j]);
                        }
                    }
                }
            }
            return nyulSzomszedok;
        }

        private (int, int) VanEUresMezoKorulotte(IEloleny[,] racs, int sor, int oszlop)
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
                            return (sor+i, oszlop +j);
                        }
                    }
                }
            }
            return (-1, -1);
        }

        public void Etetes(Fu fu)
        { 
            //Etetes

        }

        public void Taplalkozik(Mezo m, int x, int y)
        {
            // Ha ezen a mezőn van Fű, megeszi és energiát nyer
            if (m.racs[x, y] is Fu)
            {
                Energia +=2;
                m.racs[x, y] = null; // a fű elfogy
            }
        }
    }
}
