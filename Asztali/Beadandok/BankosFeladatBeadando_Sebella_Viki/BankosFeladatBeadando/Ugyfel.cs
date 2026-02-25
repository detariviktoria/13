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

        public List<Szamla> Szamlak { get; private set; } = new List<Szamla>();

        public void AddAccount(Szamla szamla)
        {
            if (Szamlak.Exists(s => s.Szamlaszam == szamla.Szamlaszam))
                throw new InvalidOperationException("Ez a számla már létezik az ügyfélnél.");
            Szamlak.Add(szamla);
        }

        public decimal GetTotalBalance()
        {
            decimal osszeg = 0;
            foreach (var s in Szamlak)
                osszeg += s.Egyenleg;
            return osszeg;
        }

    }
}
