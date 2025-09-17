using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Mezo
    {
        public int Szelesseg { get; }
        public int Magassag { get; }
        public IEloleny[,] racs;
        private int nyulSzuletesiEsely = 70;
        Random r = new Random();


        public Mezo(int szelesseg, int magassag, int nyulSzuletesiEsely = 70)
        {
            Szelesseg = szelesseg;
            Magassag = magassag;
            racs =  new IEloleny[szelesseg, magassag];
            this.nyulSzuletesiEsely = nyulSzuletesiEsely;
        }

        


        public void RacsFeltoltes()
        {
            for (int i = 0; i < racs.GetLength(0); i++)
            {
                for (int j = 0; j < racs.GetLength(1); j++)
                {
                    if (r.Next(100) < nyulSzuletesiEsely)
                    {
                        racs[i, j] = new Nyul((Nem)r.Next(2));
                    }
                }
            }
        }

        public void Leptetes()
        {
            List<(int, int, IEloleny)> ujElolenyek = new List<(int, int, IEloleny)>();
            SzuletesNelkuliLeptetes(ujElolenyek);
            UjElolenyKipakolasa(ujElolenyek);
            //HalottElolenyTorlese();
        }

        private void SzuletesNelkuliLeptetes(List<(int, int, IEloleny)> ujElolenyek)
        {
            for (int i = 0; i < Szelesseg; i++)
            {
                for (int j = 0; j < Magassag; j++)
                {
                    if (racs[i, j] != null)
                    {
                        racs[i, j].SzimulaciosLepes(racs, i, j);
                        if (racs[i, j].UjEloleny.Count > 0)
                        {
                            ujElolenyek.InsertRange(0,racs[i, j].UjEloleny);
                        }
                    }
                }
            }
        }

        private void UjElolenyKipakolasa(List<(int, int, IEloleny)> ujElolenyek)
        {
            foreach (var ujeloleny in ujElolenyek)
            {
                racs[ujeloleny.Item1, ujeloleny.Item2] = ujeloleny.Item3;
            }
        }
    }
}
