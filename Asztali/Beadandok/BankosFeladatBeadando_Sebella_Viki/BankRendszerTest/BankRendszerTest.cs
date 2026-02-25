using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankiAlkalmazas;
using BankosFeladatBeadando;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankRendszerTest
{
    [TestClass]
    public class BankRendszerTeszt
    {
        [TestMethod]
        public void FindCustomerById_LetezoVisszaadjaUgyfelt()
        {
            var rendszer = new BankRendszer();
            var ugyfel = new Ugyfel(123, "Kiss Béla", "Bp", DateTime.Now.AddYears(-30), "0612345678");
            rendszer.UjUgyfel(ugyfel);

            var talalt = rendszer.GetUgyfelek().FirstOrDefault(u => u.UgyfelId == 123);

            Assert.IsNotNull(talalt);
            Assert.AreEqual(123, talalt.UgyfelId);
        }

        [TestMethod]
        public void FindCustomerById_NemLetezo_Null()
        {
            var rendszer = new BankRendszer();

            var talalt = rendszer.GetUgyfelek().FirstOrDefault(u => u.UgyfelId == 999);

            Assert.IsNull(talalt);
        }

        [TestMethod]
        public void NegativSzamlak_VisszaadjaNegativEgyenlegeket()
        {
            var rendszer = new BankRendszer();
            rendszer.UjSzamla(new Szamla("S1", 1, "Megtakarítás", 1000, DateTime.Now));
            rendszer.UjSzamla(new Szamla("S2", 1, "Megtakarítás", -200, DateTime.Now));
            rendszer.UjSzamla(new Szamla("S3", 1, "Megtakarítás", 300, DateTime.Now));
            rendszer.UjSzamla(new Szamla("S4", 1, "Megtakarítás", -50, DateTime.Now));

            var negativ = rendszer.NegativSzamlak();

            Assert.AreEqual(2, negativ.Count);
            CollectionAssert.AreEquivalent(new decimal[] { -200, -50 }, negativ.Select(s => s.Egyenleg).ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindAccountByNumber_RosszFormatum_Kivetel()
        {
            var rendszer = new BankRendszer();
            string rosszSzamla = "";

            var szamla = rendszer.GetSzamlak().FirstOrDefault(s => s.Szamlaszam == rosszSzamla);
            if (szamla == null) throw new ArgumentException("Hibás számlaszám!");
        }
    }
}
