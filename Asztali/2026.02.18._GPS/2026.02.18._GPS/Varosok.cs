using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2026._02._18._GPS
{
    internal class Varosok
    {
        public string Nev { get; set; }
        public string Megye { get; set; }

        public int SzelesFok, SzelesPerc, SzelesSec, HosszFok, HosszPerc, HosszSec;

        public Varosok(string Nev, string Szelessegi, string Hosszusagi, string Megye)
        {
            this.Nev = Nev;
            this.Megye = Megye;
            string[] szel = Szelessegi.Split(':');
            SzelesFok = int.Parse(szel[0]);

            int[] percSec = TeljesPercbolSzogmasodperc(szel[1]);
            SzelesPerc = percSec[0];
            SzelesSec = percSec[1];

            string[] hossz = Hosszusagi.Split(':');
            HosszFok = int.Parse(hossz[0]);

            int[] percSec2 = TeljesPercbolSzogmasodperc(hossz[1]);
            HosszPerc = percSec2[0];
            HosszSec = percSec2[1];

        }

        private int[] TeljesPercbolSzogmasodperc(string Perc)
        {
            double teljes = double.Parse(Perc.Replace('.', ','));

            int perc = (int)teljes;
            double tort = teljes - perc;

            int sec = (int)(tort * 60);

            return new int[] { perc, sec };
        }

        public string[] Adatok()
        {
            return new string[]
            {
                Nev,
                $"{SzelesFok}:{SzelesPerc}:{SzelesSec}",
                $"{HosszFok}:{HosszPerc}:{HosszSec}",
                Megye
            };
        }
    }
}
