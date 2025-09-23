using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Mezo
    {
        // Properties
        public int Szelesseg { get; }
        public int Magassag { get; }

        //Fields
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

        public void Leptetes()
        {
            List<(int, int, IEloleny)> ujElolenyek = new List<(int, int, IEloleny)>();
            SzuletesNelkuliLeptetes(ujElolenyek);
            UjElolenyKipakolasa(ujElolenyek);
            //HalottElolenyTorlese();
        }



        public void RacsFeltoltes()
        {
            Random r = new Random();

            for (int i = 0; i < Szelesseg; i++)
            {
                for (int j = 0; j < Magassag; j++)
                {
                    int szam = r.Next(100); // 0-99

                    if (szam < 30)
                    {
                        // Nyúl
                        racs[i, j] = new Nyul((Nem)r.Next(2));
                    }
                    else if (szam < 50) // 30..49
                    {
                        // Róka
                        racs[i, j] = new Roka(energia: 5, nem: (Nem)r.Next(2), szaporodasiEsely: 40);
                    }
                    else if (szam < 85) // 50..84
                    {
                        // Lucerna
                        racs[i, j] = new Lucerna(i, j, new List<IEloleny>());
                    }
                    else // 85..99
                    {
                        // Repa
                        racs[i, j] = new Repa(i, j, new List<IEloleny>());
                    }
                }
            }
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

        
    }
}
