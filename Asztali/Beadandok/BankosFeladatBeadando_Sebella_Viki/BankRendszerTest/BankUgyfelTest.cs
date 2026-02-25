using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankosFeladatBeadando;

namespace BankRendszerTest
{
    [TestClass]
    public class BankUgyfelTest
    {
        // új számla hozzáadásával nő a számlák száma
        [TestMethod]
        public void AddAccount_UjSzamla_NoveliSzamlakSzamat()
        {
            var ugyfel = new Ugyfel(1, "Kiss Béla", "Budapest", DateTime.Now.AddYears(-30), "0612345678");
            var szamla = new Szamla("123", 1, "Megtakarítás", 1000, DateTime.Now);

            ugyfel.AddAccount(szamla);

            Assert.AreEqual(1, ugyfel.Szamlak.Count);
        }

        // nem engedi a duplikált számlaszámot
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAccount_DuplikaltSzamla_KiveteltDob()
        {
            var ugyfel = new Ugyfel(1, "Kiss Béla", "Budapest", DateTime.Now.AddYears(-30), "0612345678");
            var szamla = new Szamla("123", 1, "Megtakarítás", 1000, DateTime.Now);

            ugyfel.AddAccount(szamla);
            ugyfel.AddAccount(szamla); // duplikált
        }

        // összeadja a számlák egyenlegét
        [TestMethod]
        public void GetTotalBalance_TobbSzamla_Osszeg()
        {
            var ugyfel = new Ugyfel(1, "Kiss Béla", "Budapest", DateTime.Now.AddYears(-30), "0612345678");
            var szamla1 = new Szamla("123", 1, "Megtakarítás", 1000, DateTime.Now);
            var szamla2 = new Szamla("124", 1, "Megtakarítás", 3000, DateTime.Now);

            ugyfel.AddAccount(szamla1);
            ugyfel.AddAccount(szamla2);

            Assert.AreEqual(4000, ugyfel.GetTotalBalance());
        }
    }
}
