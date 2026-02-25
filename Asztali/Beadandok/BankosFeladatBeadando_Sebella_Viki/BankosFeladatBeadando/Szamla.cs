using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankosFeladatBeadando
{
    public class Szamla
    {
        public string Szamlaszam { get; set; }
        public int UgyfelId { get; set; }
        public string SzamlaTipus { get; set; }
        public decimal Egyenleg { get; set; }
        public DateTime SzamlaNyitasDatuma { get; set; }

        public Szamla(string szamlaszam, int ugyfelId, string szamlaTipus, decimal egyenleg, DateTime szamlaNyitasDatuma)
        {
            Szamlaszam = szamlaszam;
            UgyfelId = ugyfelId;
            SzamlaTipus = szamlaTipus;
            Egyenleg = egyenleg;
            SzamlaNyitasDatuma = szamlaNyitasDatuma;
        }

        public override string ToString()
        {
            return $"{Szamlaszam} - {SzamlaTipus} - {Egyenleg} Ft";
        }

        public void Deposit(decimal osszeg)
        {
            if (osszeg <= 0) throw new ArgumentException("Befizetés összege pozitív kell legyen.");
            Egyenleg += osszeg;
        }

        public void Withdraw(decimal osszeg)
        {
            if (osszeg <= 0) throw new ArgumentException("Kivét összege pozitív kell legyen.");
            if (Egyenleg < osszeg) throw new InvalidOperationException("Nincs elég pénz a számlán.");
            Egyenleg -= osszeg;
        }

        public bool HasSufficientFunds(decimal osszeg)
        {
            return Egyenleg >= osszeg;
        }

        public decimal GetBalance()
        {
            return Egyenleg;
        }

        public void TransferTo(Szamla target, decimal osszeg)
        {
            if (!HasSufficientFunds(osszeg)) throw new InvalidOperationException("Nincs elég pénz az átutaláshoz.");
            this.Withdraw(osszeg);
            target.Deposit(osszeg);
        }

    }
}
