using BankosFeladatBeadando;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankosFeladatBeadando
{
    public class BankRendszer
    {
        private List<Ugyfel> ugyfelek = new List<Ugyfel>();
        private List<Szamla> szamlak = new List<Szamla>();
        private List<Tranzakcio> tranzakciok = new List<Tranzakcio>();


        // =====================================================================
        //  ALAP MŰVELETEK – ÜGYFELEK / SZÁMLÁK / TRANZAKCIÓK
        // =====================================================================

        // Új ügyfél létrehozása
        public void UjUgyfel(Ugyfel ugyfel)
        {
            ugyfelek.Add(ugyfel);
        }

        // Új ügyfél létrehozása egyszerű paraméterekkel
        public void UjUgyfelFelvetel(string nev, string lakcim, string szuletesiDatumStr, string telefonszam)
        {
            DateTime datum = DateTime.Parse(szuletesiDatumStr);

            // --- ELLENŐRZÉS: létezik-e már ugyanez a telefonszám vagy név+dátum ---
            if (ugyfelek.Any(u =>
                u.Nev == nev &&
                u.SzuletesiDatum == datum &&
                u.Telefonszam == telefonszam))
            {
                throw new Exception("Ilyen ügyfél már létezik!");
            }
            if (string.IsNullOrWhiteSpace(nev) ||
                string.IsNullOrWhiteSpace(lakcim) ||
                string.IsNullOrWhiteSpace(telefonszam))
                throw new Exception("Minden mezőt ki kell tölteni!");

            if (telefonszam.Length < 11)
                throw new Exception("A telefonszám túl rövid!");

            DateTime szuletesiDatum;
            if (!DateTime.TryParse(szuletesiDatumStr, out szuletesiDatum))
                throw new Exception("Hibás dátumformátum!");

            int ujId = ugyfelek.Count == 0 ? 1 : ugyfelek.Max(u => u.UgyfelId) + 1;

            Ugyfel uj = new Ugyfel(ujId, nev, lakcim, szuletesiDatum, telefonszam);
            ugyfelek.Add(uj);
        }


        // Új számla nyitása
        public void UjSzamla(Szamla szamla)
        {
            // --- ELLENŐRZÉS: létezik-e már ilyen számlaszám ---
            if (szamlak.Any(s => s.Szamlaszam == szamla.Szamlaszam))
            {
                throw new Exception("Ezzel a számlaszámmal már létezik számla!");
            }
            szamlak.Add(szamla);
        }


        // Új tranzakció rögzítése
        public void UjTranzakcio(Tranzakcio t)
        {
            if (!szamlak.Any(s => s.Szamlaszam == t.ErintettSzamlaszam))
                throw new Exception("A megadott számlaszám nem létezik!");
            tranzakciok.Add(t);

            var szamla = szamlak.FirstOrDefault(s => s.Szamlaszam == t.ErintettSzamlaszam);
            if (szamla != null)
            {
                if (t.Tipus == "befizetés")
                    szamla.Egyenleg += t.Osszeg;

                else if (t.Tipus == "kivét")
                    szamla.Egyenleg -= t.Osszeg;

                else if (t.Tipus == "átutalás")
                {
                    szamla.Egyenleg -= t.Osszeg;

                    var partner = szamlak.FirstOrDefault(s => s.Szamlaszam == t.PartnerSzamlaszam);
                    if (partner != null)
                        partner.Egyenleg += t.Osszeg;
                }
            }
        }



        // =====================================================================
        //  ADATMENTÉS / VISSZATÖLTÉS
        // =====================================================================

        public void MentesFajlba()
        {
            File.WriteAllLines("ugyfelek.txt",
                ugyfelek.Select(u => $"{u.UgyfelId};{u.Nev};{u.Lakcim};{u.SzuletesiDatum};{u.Telefonszam}"));

            File.WriteAllLines("szamlak.txt",
                szamlak.Select(s => $"{s.Szamlaszam};{s.UgyfelId};{s.SzamlaTipus};{s.Egyenleg};{s.SzamlaNyitasDatuma}"));

            File.WriteAllLines("tranzakciok.txt",
                tranzakciok.Select(t =>
                    $"{t.TranzakcioId};{t.ErintettSzamlaszam};{t.Tipus};{t.Osszeg};{t.Datum};{t.PartnerSzamlaszam}"));
        }

        public void BetoltesFajlbol()
        {
            if (File.Exists("ugyfelek.txt"))
            {
                ugyfelek = File.ReadAllLines("ugyfelek.txt").Select(line =>
                {
                    var d = line.Split(';');
                    return new Ugyfel(
                        int.Parse(d[0]), d[1], d[2], DateTime.Parse(d[3]), d[4]);
                }).ToList();
            }

            if (File.Exists("szamlak.txt"))
            {
                szamlak = File.ReadAllLines("szamlak.txt").Select(line =>
                {
                    var d = line.Split(';');
                    return new Szamla(
                        d[0], int.Parse(d[1]), d[2], decimal.Parse(d[3]), DateTime.Parse(d[4]));
                }).ToList();
            }

            if (File.Exists("tranzakciok.txt"))
            {
                tranzakciok = File.ReadAllLines("tranzakciok.txt").Select(line =>
                {
                    var d = line.Split(';');
                    return new Tranzakcio(
                        int.Parse(d[0]),           // TranzakcioId
                        int.Parse(d[1]),           // UgyfelId
                        d[2],                      // ErintettSzamlaszam
                        d[3],                      // Tipus
                        decimal.Parse(d[4]),       // Osszeg
                        DateTime.Parse(d[5]),      // Datum
                        d.Length > 6 ? d[6] : null // PartnerSzamlaszam (opcionális)
                    );
                }).ToList();
            }
        }


        // =====================================================================
        //  LEKÉRDEZÉSEK ÉS SZŰRÉSEK
        // =====================================================================

        public List<Ugyfel> GetUgyfelek() => ugyfelek;

        public List<Szamla> UgyfelSzamlai(int ugyfelId)
        {
            return szamlak.Where(s => s.UgyfelId == ugyfelId).ToList();
        }

        public List<Tranzakcio> SzamlaTranzakcioi(string szamlaszam)
        {
            return tranzakciok.Where(t =>
                t.ErintettSzamlaszam == szamlaszam ||
                t.PartnerSzamlaszam == szamlaszam).ToList();
        }

        public List<Szamla> NegativSzamlak()
        {
            return szamlak.Where(s => s.Egyenleg < 0).ToList();
        }

        public List<Tranzakcio> TranzakcioSzures(DateTime tol, DateTime ig)
        {
            return tranzakciok.Where(t => t.Datum >= tol && t.Datum <= ig).ToList();
        }



        // =====================================================================
        //  STATISZTIKÁK ÉS SPECIÁLIS LEKÉRDEZÉSEK
        // =====================================================================

        // Legnagyobb forgalmú ügyfél keresése
        public Ugyfel LegnagyobbForgalmuUgyfel()
        {
            var forgalmak = ugyfelek.Select(u =>
            {
                var uSzamlai = szamlak
                    .Where(s => s.UgyfelId == u.UgyfelId)
                    .Select(s => s.Szamlaszam);

                var osszForgalom = tranzakciok
                    .Where(t => uSzamlai.Contains(t.ErintettSzamlaszam) ||
                                uSzamlai.Contains(t.PartnerSzamlaszam))
                    .Sum(t => Math.Abs(t.Osszeg));

                return new { Ugyfel = u, Forgalom = osszForgalom };
            });

            return forgalmak.OrderByDescending(f => f.Forgalom).First().Ugyfel;
        }

        // Időszak teljes tranzakcióösszege
        public decimal OsszesTranzakcioOsszeg(DateTime tol, DateTime ig)
        {
            return tranzakciok
                .Where(t => t.Datum >= tol && t.Datum <= ig)
                .Sum(t => t.Osszeg);
        }

        // Befizetés/kivét statisztika
        public (decimal befizetes, decimal kivet) Statisztika(DateTime tol, DateTime ig)
        {
            decimal befiz = tranzakciok
                .Where(t => t.Tipus == "befizetés" && t.Datum >= tol && t.Datum <= ig)
                .Sum(t => t.Osszeg);

            decimal kiv = tranzakciok
                .Where(t => t.Tipus == "kivét" && t.Datum >= tol && t.Datum <= ig)
                .Sum(t => t.Osszeg);

            return (befiz, kiv);
        }



        // =====================================================================
        //  EXPORT / BACKUP
        // =====================================================================

        public void ExportTranzakciok(string fajlnev)
        {
            var sorok = tranzakciok.Select(t =>
                $"{t.TranzakcioId};{t.Tipus};{t.Osszeg};{t.Datum};{t.ErintettSzamlaszam};{t.PartnerSzamlaszam}");

            File.WriteAllLines(fajlnev, sorok);
        }

        public void BiztonsagiMentes(string mappa)
        {
            Directory.CreateDirectory(mappa);
            File.Copy("ugyfelek.txt", Path.Combine(mappa, "ugyfelek_backup.txt"), true);
            File.Copy("szamlak.txt", Path.Combine(mappa, "szamlak_backup.txt"), true);
            File.Copy("tranzakciok.txt", Path.Combine(mappa, "tranzakciok_backup.txt"), true);
        }

        public void BiztonsagiVisszaallitas(string mappa)
        {
            File.Copy(Path.Combine(mappa, "ugyfelek_backup.txt"), "ugyfelek.txt", true);
            File.Copy(Path.Combine(mappa, "szamlak_backup.txt"), "szamlak.txt", true);
            File.Copy(Path.Combine(mappa, "tranzakciok_backup.txt"), "tranzakciok.txt", true);
            BetoltesFajlbol();
        }



        // =====================================================================
        //  TÖBBSZÁLÚ MŰVELETEK (FELADAT MEGKÖVETELI)
        // =====================================================================

        // Adatbetöltés háttérszálon
        public async Task BetoltesAsync()
        {
            await Task.Run(() => BetoltesFajlbol());
        }

        // Adatmentés háttérszálon
        public async Task MentesAsync()
        {
            await Task.Run(() => MentesFajlba());
        }

        public List<Tranzakcio> GetTranzakciok()
        {
            return tranzakciok;
        }

        public List<Szamla> GetSzamlak()
        {
            return szamlak;
        }

        

    }
}