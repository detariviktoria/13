using BankosFeladatBeadando;
using System;
using System.Collections.Generic;
using Xunit;

namespace BankRendszerTests
{
    public class BankRendszerTeszt
    {
        // A BankRendszer példány, amit minden teszt használ
        private BankosFeladatBeadando.BankRendszer bank = new BankosFeladatBeadando.BankRendszer();

        [Fact]
        public void SzamlaBefizetes_NovelEgyenleget()
        {
            // Létrehozunk egy számlát
            var szamla = new Szamla("123", 1, "forint", 1000, DateTime.Now);
            bank.UjSzamla(szamla);

            // Tranzakció létrehozása: befizetés
            var tranz = new Tranzakcio(1, 1, "123", "befizetés", 500, DateTime.Now);
            bank.UjTranzakcio(tranz);

            // Ellenőrizzük az egyenleget
            Assert.Equal(1500, szamla.Egyenleg);
        }

        [Fact]
        public void SzamlaKivet_NemTobbMintEgyenleg()
        {
            var szamla = new Szamla("456", 1, "forint", 300, DateTime.Now);
            bank.UjSzamla(szamla);

            // Kivét tranzakció, ami túl nagy
            var tranz = new Tranzakcio(2, 1, "456", "kivét", 1000, DateTime.Now);

            // Kivét hibát kell, hogy dobjon, de mivel a BankRendszer nem dob kivételt automatikusan
            // (csak az ellenőrzés nincs implementálva), itt manuálisan ellenőrizhetjük:
            Assert.Throws<Exception>(() => bank.UjTranzakcio(tranz));
        }

        [Fact]
        public void Atutalas_Sikeres()
        {
            var szamlaA = new Szamla("A1", 1, "forint", 5000, DateTime.Now);
            var szamlaB = new Szamla("B1", 2, "forint", 1000, DateTime.Now);

            bank.UjSzamla(szamlaA);
            bank.UjSzamla(szamlaB);

            var tranz = new Tranzakcio(3, 1, "A1", "átutalás", 2000, DateTime.Now, "B1");
            bank.UjTranzakcio(tranz);

            Assert.Equal(3000, szamlaA.Egyenleg); // levonódott
            Assert.Equal(3000, szamlaB.Egyenleg); // hozzáadódott
        }

        [Fact]
        public void NegativSzamlaListazas()
        {
            var sz1 = new Szamla("S1", 1, "forint", 1000, DateTime.Now);
            var sz2 = new Szamla("S2", 1, "forint", -200, DateTime.Now);
            var sz3 = new Szamla("S3", 1, "forint", -50, DateTime.Now);

            bank.UjSzamla(sz1);
            bank.UjSzamla(sz2);
            bank.UjSzamla(sz3);

            var negativ = bank.NegativSzamlak();

            Assert.Contains(sz2, negativ);
            Assert.Contains(sz3, negativ);
            Assert.DoesNotContain(sz1, negativ);
        }

        [Fact]
        public void UjUgyfelFelvetel_DuplicaHibatDob()
        {
            // Létrehozunk egy ügyfelet
            bank.UjUgyfelFelvetel("Kiss János", "Budapest", "1980-01-01", "06123456789");

            // Ugyanilyen ismétlés hibát dob
            Assert.Throws<Exception>(() => bank.UjUgyfelFelvetel("Kiss János", "Budapest", "1980-01-01", "06123456789"));
        }

        [Fact]
        public void LegnagyobbForgalmuUgyfel()
        {
            var ugyfel1 = new Ugyfel(1, "A", "Budapest", DateTime.Now, "06123456789");
            var ugyfel2 = new Ugyfel(2, "B", "Budapest", DateTime.Now, "06987654321");

            bank.UjUgyfel(ugyfel1);
            bank.UjUgyfel(ugyfel2);

            var sz1 = new Szamla("111", 1, "forint", 1000, DateTime.Now);
            var sz2 = new Szamla("222", 2, "forint", 500, DateTime.Now);

            bank.UjSzamla(sz1);
            bank.UjSzamla(sz2);

            bank.UjTranzakcio(new Tranzakcio(1, 1, "111", "befizetés", 1000, DateTime.Now));
            bank.UjTranzakcio(new Tranzakcio(2, 2, "222", "befizetés", 300, DateTime.Now));

            var top = bank.LegnagyobbForgalmuUgyfel();

            Assert.Equal(ugyfel1, top);
        }
    }
}
