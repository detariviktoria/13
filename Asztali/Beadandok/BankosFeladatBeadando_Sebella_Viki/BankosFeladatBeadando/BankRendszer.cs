using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BankosFeladatBeadando;

namespace BankiAlkalmazas
{
    public class BankRendszer
    {
        private List<Ugyfel> ugyfelek = new List<Ugyfel>();
        private List<Szamla> szamlak = new List<Szamla>();
        private List<Tranzakcio> tranzakciok = new List<Tranzakcio>();

        // ==========================
        // Alap műveletek
        // ==========================
        public void UjUgyfel(Ugyfel ugyfel) => ugyfelek.Add(ugyfel);

        public void UjUgyfelFelvetel(string nev, string lakcim, string szuletesiDatumStr, string telefonszam)
        {
            if (string.IsNullOrWhiteSpace(nev) ||
                string.IsNullOrWhiteSpace(lakcim) ||
                string.IsNullOrWhiteSpace(telefonszam))
                throw new Exception("Minden mezőt ki kell tölteni!");

            if (telefonszam.Length < 6)
                throw new Exception("A telefonszám túl rövid!");

            if (!DateTime.TryParse(szuletesiDatumStr, out DateTime szuletesiDatum))
                throw new Exception("Hibás dátumformátum!");
            // Telefonszám egyediség ellenőrzése
            if (ugyfelek.Any(u => u.Telefonszam == telefonszam))
                throw new Exception("Ezzel a telefonszámmal már létezik ügyfél!");

            // Név + születési dátum kombináció ellenőrzése (opcionális)
            if (ugyfelek.Any(u => u.Nev == nev && u.SzuletesiDatum == szuletesiDatum))
                throw new Exception("Ugyanezzel a névvel és születési dátummal már szerepel ügyfél!");
            int ujId = ugyfelek.Count == 0 ? 1 : ugyfelek.Max(u => u.UgyfelId) + 1;
            Ugyfel uj = new Ugyfel(ujId, nev, lakcim, szuletesiDatum, telefonszam);
            ugyfelek.Add(uj);
        }

        public void UjSzamla(Szamla szamla) => szamlak.Add(szamla);

        public void UjTranzakcio(Tranzakcio t)
        {
            tranzakciok.Add(t);

            var szamla = szamlak.FirstOrDefault(s => s.Szamlaszam == t.ErintettSzamlaszam);
            if (szamla != null)
            {
                if (t.Tipus == "befizetés")
                    szamla.Egyenleg += t.Osszeg;
                else if (t.Tipus == "kivét" || t.Tipus == "kivet")
                    szamla.Egyenleg -= t.Osszeg;
                else if (t.Tipus == "átutalás" || t.Tipus == "atutalas")
                {
                    szamla.Egyenleg -= t.Osszeg;
                    if (!string.IsNullOrWhiteSpace(t.PartnerSzamlaszam))
                    {
                        var partner = szamlak.FirstOrDefault(s => s.Szamlaszam == t.PartnerSzamlaszam);
                        if (partner != null)
                            partner.Egyenleg += t.Osszeg;
                    }
                }
            }
        }

        // ==========================
        // Mentés/Betöltés (konzisztens formátum)
        // Mezőrend minden tranzakciónál: 
        // TranzakcioId;UgyfelId;ErintettSzamlaszam;Tipus;Osszeg;Datum;PartnerSzamlaszam
        // ==========================
        public void MentesFajlba()
        {
            File.WriteAllLines("ugyfelek.txt",
                ugyfelek.Select(u => $"{u.UgyfelId};{u.Nev};{u.Lakcim};{u.SzuletesiDatum:O};{u.Telefonszam}"));

            File.WriteAllLines("szamlak.txt",
                szamlak.Select(s => $"{s.Szamlaszam};{s.UgyfelId};{s.SzamlaTipus};{s.Egyenleg};{s.SzamlaNyitasDatuma:O}"));

            File.WriteAllLines("tranzakciok.txt",
                tranzakciok.Select(t =>
                    $"{t.TranzakcioId};{t.UgyfelId};{t.ErintettSzamlaszam};{t.Tipus};{t.Osszeg};{t.Datum:O};{(t.PartnerSzamlaszam ?? "")}"));
        }

        public void BetoltesFajlbol()
        {
            if (File.Exists("ugyfelek.txt"))
            {
                ugyfelek = File.ReadAllLines("ugyfelek.txt")
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line =>
                    {
                        var d = line.Split(';');
                        return new Ugyfel(
                            int.Parse(d[0]),
                            d[1],
                            d[2],
                            DateTime.Parse(d[3]),
                            d[4]);
                    }).ToList();
            }

            if (File.Exists("szamlak.txt"))
            {
                szamlak = File.ReadAllLines("szamlak.txt")
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line =>
                    {
                        var d = line.Split(';');
                        return new Szamla(
                            d[0],
                            int.Parse(d[1]),
                            d[2],
                            decimal.Parse(d[3]),
                            DateTime.Parse(d[4]));
                    }).ToList();
            }

            if (File.Exists("tranzakciok.txt"))
            {
                tranzakciok = File.ReadAllLines("tranzakciok.txt")
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line =>
                    {
                        var d = line.Split(';');
                        // védett olvasás: ha hiányoznak mezők, próbáljuk meg kiegészíteni
                        int tranzId = d.Length > 0 ? int.Parse(d[0]) : 0;
                        int ugyfelId = d.Length > 1 ? int.Parse(d[1]) : 0;
                        string erintett = d.Length > 2 ? d[2] : "";
                        string tipus = d.Length > 3 ? d[3] : "";
                        decimal osszeg = d.Length > 4 ? decimal.Parse(d[4]) : 0m;
                        DateTime datum = d.Length > 5 ? DateTime.Parse(d[5]) : DateTime.MinValue;
                        string partner = d.Length > 6 ? d[6] : null;

                        return new Tranzakcio(tranzId, ugyfelId, erintett, tipus, osszeg, datum, string.IsNullOrWhiteSpace(partner) ? null : partner);
                    }).ToList();
            }
        }

        // ==========================
        // Lekérdezések / szűrések
        // ==========================
        public List<Ugyfel> GetUgyfelek() => ugyfelek;
        public List<Szamla> UgyfelSzamlai(int ugyfelId) => szamlak.Where(s => s.UgyfelId == ugyfelId).ToList();
        public List<Tranzakcio> SzamlaTranzakcioi(string szamlaszam)
        {
            return tranzakciok.Where(t =>
                t.ErintettSzamlaszam == szamlaszam ||
                t.PartnerSzamlaszam == szamlaszam).ToList();
        }
        public List<Szamla> NegativSzamlak() => szamlak.Where(s => s.Egyenleg < 0).ToList();
        public List<Tranzakcio> TranzakcioSzures(DateTime tol, DateTime ig) => tranzakciok.Where(t => t.Datum >= tol && t.Datum <= ig).ToList();

        // ==========================
        // Statisztikák
        // ==========================
        public Ugyfel LegnagyobbForgalmuUgyfel()
        {
            if (!ugyfelek.Any()) return null;

            var forgalmak = ugyfelek.Select(u =>
            {
                var uSzamlai = szamlak.Where(s => s.UgyfelId == u.UgyfelId).Select(s => s.Szamlaszam).ToList();
                var osszForgalom = tranzakciok
                    .Where(t => uSzamlai.Contains(t.ErintettSzamlaszam) || uSzamlai.Contains(t.PartnerSzamlaszam))
                    .Sum(t => Math.Abs(t.Osszeg));
                return new { Ugyfel = u, Forgalom = osszForgalom };
            });

            var top = forgalmak.OrderByDescending(f => f.Forgalom).FirstOrDefault();
            return top?.Ugyfel;
        }

        public decimal OsszesTranzakcioOsszeg(DateTime tol, DateTime ig)
        {
            return tranzakciok.Where(t => t.Datum >= tol && t.Datum <= ig).Sum(t => t.Osszeg);
        }

        public (decimal befizetes, decimal kivet) Statisztika(DateTime tol, DateTime ig)
        {
            decimal befiz = tranzakciok.Where(t => t.Tipus == "befizetés" && t.Datum >= tol && t.Datum <= ig).Sum(t => t.Osszeg);
            decimal kiv = tranzakciok.Where(t => (t.Tipus == "kivét" || t.Tipus == "kivet") && t.Datum >= tol && t.Datum <= ig).Sum(t => t.Osszeg);
            return (befiz, kiv);
        }

        // ==========================
        // Export / backup
        // ==========================
        public void ExportTranzakciok(string fajlnev)
        {
            var sorok = tranzakciok.Select(t => $"{t.TranzakcioId};{t.UgyfelId};{t.ErintettSzamlaszam};{t.Tipus};{t.Osszeg};{t.Datum:O};{(t.PartnerSzamlaszam ?? "")}");
            File.WriteAllLines(fajlnev, sorok);
        }

        public void BiztonsagiMentes(string mappa)
        {
            Directory.CreateDirectory(mappa);
            if (File.Exists("ugyfelek.txt")) File.Copy("ugyfelek.txt", Path.Combine(mappa, "ugyfelek_backup.txt"), true);
            if (File.Exists("szamlak.txt")) File.Copy("szamlak.txt", Path.Combine(mappa, "szamlak_backup.txt"), true);
            if (File.Exists("tranzakciok.txt")) File.Copy("tranzakciok.txt", Path.Combine(mappa, "tranzakciok_backup.txt"), true);
        }

        public void BiztonsagiVisszaallitas(string mappa)
        {
            if (File.Exists(Path.Combine(mappa, "ugyfelek_backup.txt"))) File.Copy(Path.Combine(mappa, "ugyfelek_backup.txt"), "ugyfelek.txt", true);
            if (File.Exists(Path.Combine(mappa, "szamlak_backup.txt"))) File.Copy(Path.Combine(mappa, "szamlak_backup.txt"), "szamlak.txt", true);
            if (File.Exists(Path.Combine(mappa, "tranzakciok_backup.txt"))) File.Copy(Path.Combine(mappa, "tranzakciok_backup.txt"), "tranzakciok.txt", true);
            BetoltesFajlbol();
        }

        // ==========================
        // Async wrappers
        // ==========================
        public async Task BetoltesAsync() => await Task.Run(() => BetoltesFajlbol());
        public async Task MentesAsync() => await Task.Run(() => MentesFajlba());

        public List<Tranzakcio> GetTranzakciok() => tranzakciok;
        public List<Szamla> GetSzamlak() => szamlak;
    }
}
