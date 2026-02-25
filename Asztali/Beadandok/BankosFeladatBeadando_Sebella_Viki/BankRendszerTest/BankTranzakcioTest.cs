using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankosFeladatBeadando;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankRendszerTest
{
    [TestClass]
    public class BankTranzakcioTeszt
    {
        // érvényesség ellenőrzés
        [TestMethod]
        public void IsValid_NegativOsszeg_False()
        {
            var t = new Tranzakcio(1, 1, "123", "befizetés", -500, DateTime.Now);
            Assert.IsFalse(t.IsValid());
        }

        [TestMethod]
        public void IsValid_HianyzoCelSzamla_False()
        {
            var t = new Tranzakcio(1, 1, "", "befizetés", 500, DateTime.Now);
            Assert.IsFalse(t.IsValid());
        }

        // tranzakció díj számítása
        [TestMethod]
        public void CalculateFee_EgySzazalek()
        {
            var t = new Tranzakcio(1, 1, "123", "átutalás", 10000, DateTime.Now);
            Assert.AreEqual(100, t.CalculateFee());
        }

        [TestMethod]
        public void CalculateFee_MinimumFee()
        {
            var t = new Tranzakcio(1, 1, "123", "átutalás", 100, DateTime.Now);
            Assert.AreEqual(100, t.CalculateFee());
        }
    }
}
