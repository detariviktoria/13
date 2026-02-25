using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankosFeladatBeadando;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankRendszerTest
{
    [TestClass] // jelzi, hogy ez egy teszt osztály
    public class BankSzamlaTeszt
    {
        // Itt lesznek a teszt metódusok
        // Deposit pozitív összeg
        [TestMethod]
        public void Befizetes_PozitivOsszeg_NoveliEgyenleget()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 1000, DateTime.Now);
            szamla.Deposit(500);

            Assert.AreEqual(1500, szamla.GetBalance());
        }
        //Deposit negatív összeg(kivétel)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Befizetes_NegativOsszeg_KiveteltDob()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 1000, DateTime.Now);
            szamla.Deposit(-200);
        }
        // Withdraw elegendő egyenleg esetén
        [TestMethod]
        public void Kivetel_ElegendoEgyenlegCsokkentiEgyenleget()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 2000, DateTime.Now);
            szamla.Withdraw(500);

            Assert.AreEqual(1500, szamla.GetBalance());
        }
        // Withdraw elégtelen egyenleg esetén (kivétel)
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Kivetel_ElegetlenEgyenlegKivetel_KiveteltDob()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 300, DateTime.Now);
            szamla.Withdraw(1000);
        }
        // HasSufficientFunds – van elég pénz
        [TestMethod]
        public void VanElegPenz_ElofeltetelIgaz()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 5000, DateTime.Now);
            Assert.IsTrue(szamla.HasSufficientFunds(4999));
        }
        // HasSufficientFunds – nincs elég pénz
        [TestMethod]
        public void NincsElegPenz_ElofeltetelHamis()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 200, DateTime.Now);
            Assert.IsFalse(szamla.HasSufficientFunds(201));
        }
        // TransferTo – sikeres átutalás
        [TestMethod]
        public void Atutalas_Sikeres()
        {
            var szamlaA = new Szamla("A123", 1, "Lakcim", 5000, DateTime.Now);
            var szamlaB = new Szamla("B123", 2, "Lakcim", 1000, DateTime.Now);

            szamlaA.TransferTo(szamlaB, 2000);

            Assert.AreEqual(3000, szamlaA.GetBalance());
            Assert.AreEqual(3000, szamlaB.GetBalance());
        }
        //TransferTo – nincs elég pénz(kivétel, állapot ne változzon)
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Atutalas_NemElofordulElofeltetel()
        {
            var szamlaA = new Szamla("A123", 1, "Lakcim", 1000, DateTime.Now);
            var szamlaB = new Szamla("B123", 2, "Lakcim", 1000, DateTime.Now);

            szamlaA.TransferTo(szamlaB, 5000);
        }
        // GetBalance – visszaadja az aktuális egyenleget
        [TestMethod]
        public void AktEgyenleg_PositiveErtek()
        {
            var szamla = new Szamla("123", 1, "Megtakarítás", 900, DateTime.Now);
            Assert.AreEqual(900, szamla.GetBalance());
        }

    }
}
