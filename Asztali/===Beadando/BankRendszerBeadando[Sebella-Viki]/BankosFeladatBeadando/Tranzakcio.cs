using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankosFeladatBeadando
{
    public class Tranzakcio
    {
        public int TranzakcioId { get; set; }
        public int UgyfelId { get; set; }
        public string ErintettSzamlaszam { get; set; }
        public string Tipus { get; set; }
        public decimal Osszeg { get; set; }
        public DateTime Datum { get; set; }
        public string PartnerSzamlaszam { get; set; } // opcionális

        public Tranzakcio(int tranzakcioId, int ugyfelId, string erintettSzamlaszam, string tipus, decimal osszeg, DateTime datum, string partnerSzamlaszam = null)
        {
            TranzakcioId = tranzakcioId;
            UgyfelId = ugyfelId;
            ErintettSzamlaszam = erintettSzamlaszam;
            Tipus = tipus;
            Osszeg = osszeg;
            Datum = datum;
            PartnerSzamlaszam = partnerSzamlaszam;
        }

        public override string ToString()
        {
            return $"{TranzakcioId} - {Tipus} - {Osszeg} Ft - {Datum.ToShortDateString()}";
        }
    }
}
