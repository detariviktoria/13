using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankosFeladatBeadando
{
    public class Ugyfel
    {
        public int UgyfelId { get; set; }
        public string Nev { get; set; }
        public string Lakcim { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public string Telefonszam { get; set; }

        public Ugyfel(int ugyfelId, string nev, string lakcim, DateTime szuletesiDatum, string telefonszam)
        {
            UgyfelId = ugyfelId;
            Nev = nev;
            Lakcim = lakcim;
            SzuletesiDatum = szuletesiDatum;
            Telefonszam = telefonszam;
        }

        public override string ToString()
        {
            return $"{UgyfelId} - {Nev} ({Telefonszam})";
        }
    }
}
