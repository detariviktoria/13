using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_VizsgaForm
{
    internal class Varosok
    {
        public string Nev;
        public string Megye;

        public int SzelesFok;
        public int SzelesPerc;
        public int SzelesSec;

        public int HosszFok;
        public int HosszPerc;
        public int HosszSec;

        public Varosok(string nev, string szelessegi, string hosszusagi, string megye)
        {
            Nev = nev;
            Megye = megye;

            // Szélesség feldolgozása (pl. 18:31.29)
            string[] szel = szelessegi.Split(':');
            SzelesFok = int.Parse(szel[0]);

            int[] szPercSec = TeljesPercbolSzogmasodperc(szel[1]);
            SzelesPerc = szPercSec[0];
            SzelesSec = szPercSec[1];

            // Hosszúság feldolgozása (pl. 47:02.4)
            string[] hossz = hosszusagi.Split(':');
            HosszFok = int.Parse(hossz[0]);

            int[] hPercSec = TeljesPercbolSzogmasodperc(hossz[1]);
            HosszPerc = hPercSec[0];
            HosszSec = hPercSec[1];
        }


        private int[] TeljesPercbolSzogmasodperc(string perc)
        {
            // pl: "25.15"
            double p = double.Parse(perc.Replace('.', ','));
            int egeszPerc = (int)p;
            double tort = p - egeszPerc;

            int masodperc = (int)(tort * 60);

            return new int[] { egeszPerc, masodperc };
        }

    }
}
