using BankiAlkalmazas;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BankosFeladatBeadando
{
    public partial class BankRendszerForm : Form
    {
        private BankRendszer bankRendszer;

        public BankRendszerForm()
        {
            InitializeComponent();

            // BankRendszer példányosítása
            bankRendszer = new BankRendszer();

            // Adatok betöltése fájlból (szinkron módon; van async változat is a BankRendszerben)
            try
            {
                bankRendszer.BetoltesFajlbol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az adatok betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // ListBox-ok frissítése
            FrissitUgyfelLista();
            FrissitSzamlaLista();
            FrissitTranzakcioLista();
        }

        // ---------------------------
        // Új ügyfél felvitel gomb
        // ---------------------------
        private void BtnUjUgyfel_Click(object sender, EventArgs e)
        {
            try
            {
                string nev = txtNev.Text.Trim();
                string lakcim = txtLakcim.Text.Trim();
                string szulDatum = txtSzul.Text.Trim();
                string telefonszam = txtTelefonsz.Text.Trim();

                // Új ügyfél felvétele a BankRendszer OOP metódusával
                bankRendszer.UjUgyfelFelvetel(nev, lakcim, szulDatum, telefonszam);

                FrissitUgyfelLista();

                txtNev.Clear();
                txtLakcim.Clear();
                txtSzul.Clear();
                txtTelefonsz.Clear();

                bankRendszer.MentesFajlba();

                MessageBox.Show("Új ügyfél sikeresen felvéve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrissitUgyfelLista()
        {
            listBoxUgyfelek.Items.Clear();
            foreach (var ugyfel in bankRendszer.GetUgyfelek())
            {
                listBoxUgyfelek.Items.Add(ugyfel);
            }
        }

        private void FrissitSzamlaLista()
        {
            if (listBoxSzamlak == null) return;
            listBoxSzamlak.Items.Clear();
            foreach (var sz in bankRendszer.GetSzamlak())
            {
                listBoxSzamlak.Items.Add(sz);
            }
        }

        private void FrissitTranzakcioLista()
        {
            if (listBoxTranzakciok == null) return;
            listBoxTranzakciok.Items.Clear();
            foreach (var t in bankRendszer.GetTranzakciok())
            {
                listBoxTranzakciok.Items.Add(t);
            }
        }

        // ---------------------------
        // Új számla felvitele
        // ---------------------------
        private void BtnUjSzamla_Click(object sender, EventArgs e)
        {
            try
            {
                // --- 1. Ügyfél kiválasztása ---
                if (listBoxUgyfelek.SelectedItem == null)
                {
                    MessageBox.Show("Válassz ki egy ügyfelet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ugyfel kivalasztottUgyfel = (Ugyfel)listBoxUgyfelek.SelectedItem;

                // --- 2. Számlaszám ellenőrzés ---
                string szamlaszam = txtSzamlaszam.Text.Trim();
                if (string.IsNullOrWhiteSpace(szamlaszam))
                {
                    MessageBox.Show("A számlaszám megadása kötelező!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ne engedjünk duplikált számlaszámot
                if (bankRendszer.GetSzamlak().Any(s => s.Szamlaszam == szamlaszam))
                {
                    MessageBox.Show("Ezzel a számlaszámmal már létezik számla!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- 3. Számlatípus kiválasztása ---
                if (comboSzamlaTipus.SelectedItem == null)
                {
                    MessageBox.Show("Válassz számlatípust!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tipus = comboSzamlaTipus.SelectedItem.ToString();

                // --- 4. Kezdő egyenleg ---
                decimal egyenleg = numericEgyenleg.Value;

                // --- 5. Számla létrehozása ---
                Szamla ujSzamla = new Szamla(
                    szamlaszam,
                    kivalasztottUgyfel.UgyfelId,
                    tipus,
                    egyenleg,
                    DateTime.Now
                );

                bankRendszer.UjSzamla(ujSzamla);
                bankRendszer.MentesFajlba();

                // --- 6. Visszajelzés ---
                MessageBox.Show("Új számla sikeresen létrehozva!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- 7. Mezők kiürítése ---
                txtSzamlaszam.Clear();
                numericEgyenleg.Value = 0;

                // ComboBox visszaállítása első elemre
                comboSzamlaTipus.SelectedIndex = 0;

                FrissitSzamlaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ---------------------------
        // Új tranzakció felvitele
        // ---------------------------
        private void BtnUjTranzakcio_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxUgyfelek.SelectedItem == null)
                {
                    MessageBox.Show("Válassz ki egy ügyfelet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string szamlaszam = txtTranzSzamlaszam.Text.Trim();
                string tipus = txtTranzTipus.Text.Trim();
                string osszegStr = txtTranzOsszeg.Text.Trim();
                string datumStr = txtTranzDatum.Text.Trim();
                string partner = string.IsNullOrWhiteSpace(txtPartnerSzamlaszam.Text) ? null : txtPartnerSzamlaszam.Text.Trim();

                if (string.IsNullOrWhiteSpace(szamlaszam) || string.IsNullOrWhiteSpace(tipus) ||
                    string.IsNullOrWhiteSpace(osszegStr) || string.IsNullOrWhiteSpace(datumStr))
                {
                    MessageBox.Show("Töltsd ki a tranzakció mezőket!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kulturafüggetlen parse
                if (!decimal.TryParse(osszegStr, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal osszeg))
                {
                    // próbáljuk helyi formátummal is, ha szükséges
                    if (!decimal.TryParse(osszegStr, out osszeg))
                    {
                        MessageBox.Show("Az összeg nem megfelelő formátum!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!DateTime.TryParse(datumStr, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime datum))
                {
                    if (!DateTime.TryParse(datumStr, out datum))
                    {
                        MessageBox.Show("A dátum nem megfelelő formátum!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Ugyfel kivalasztottUgyfel = (Ugyfel)listBoxUgyfelek.SelectedItem;

                // Auto ID helyett a BankRendszer is képes adni id-t, de itt egyszerűen növelem
                int newId = bankRendszer.GetTranzakciok().Count == 0 ? 1 : bankRendszer.GetTranzakciok().Max(t => t.TranzakcioId) + 1;

                Tranzakcio uj = new Tranzakcio(
                    newId,
                    kivalasztottUgyfel.UgyfelId,
                    szamlaszam,
                    tipus,
                    osszeg,
                    datum,
                    partner
                );

                bankRendszer.UjTranzakcio(uj);
                bankRendszer.MentesFajlba();

                MessageBox.Show("Tranzakció rögzítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTranzSzamlaszam.Clear();
                txtTranzTipus.Clear();
                txtTranzOsszeg.Clear();
                txtTranzDatum.Clear();
                txtPartnerSzamlaszam.Clear();

                // Frissítjük a listákat, hogy az egyenlegváltozás is látszódjon
                FrissitSzamlaLista();
                FrissitTranzakcioLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------
        // Segédfüggvények
        // ---------------------------

        // Negatív egyenlegű számlák - megjelenítés a számlalistában
        private void BtnNegativSzamlak_Click(object sender, EventArgs e)
        {
            try
            {
                var negativ = bankRendszer.NegativSzamlak();
                listBoxSzamlak.Items.Clear();
                foreach (var s in negativ)
                    listBoxSzamlak.Items.Add(s);

                // töröljük ügyfél és tranzakció listát, hogy ne legyen félrevezető
                listBoxUgyfelek.Items.Clear();
                listBoxTranzakciok.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tranzakciók szűrése dátum alapján -> tranzakciólistába kerülnek
        private void BtnTranzSzures_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(txtTranzTolDatum.Text.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tol) ||
                    !DateTime.TryParse(txtTranzIgDatum.Text.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ig))
                {
                    MessageBox.Show("Hibás dátum formátum! Használj pl. 2025-12-01", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var szures = bankRendszer.TranzakcioSzures(tol, ig);
                listBoxTranzakciok.Items.Clear();
                foreach (var t in szures)
                    listBoxTranzakciok.Items.Add(t);

                // opcionálisan töröljük más listákat
                listBoxUgyfelek.Items.Clear();
                listBoxSzamlak.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a szűrés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Számlák szűrése típus és egyenleg alapján
        private void BtnSzamlaSzures_Click(object sender, EventArgs e)
        {
            try
            {
                string tipus = txtSzamlaTipusSzures.Text.Trim();
                decimal.TryParse(txtSzamlaMin.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal min);
                decimal.TryParse(txtSzamlaMax.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal max);

                var szures = bankRendszer.GetSzamlak()
                             .Where(s => (string.IsNullOrEmpty(tipus) || s.SzamlaTipus.Equals(tipus, StringComparison.InvariantCultureIgnoreCase)) &&
                                         s.Egyenleg >= min && s.Egyenleg <= (max == 0m ? decimal.MaxValue : max))
                             .ToList();

                listBoxSzamlak.Items.Clear();
                foreach (var s in szures)
                    listBoxSzamlak.Items.Add(s);

                listBoxUgyfelek.Items.Clear();
                listBoxTranzakciok.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a számlaszűrés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Legnagyobb forgalmú ügyfél - a BankRendszer metódusát használjuk
        private void BtnLegnagyobbForgalom_Click(object sender, EventArgs e)
        {
            try
            {
                var leg = bankRendszer.LegnagyobbForgalmuUgyfel();
                if (leg == null)
                {
                    MessageBox.Show("Nincs elég adat a számításhoz.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Legnagyobb forgalmú ügyfél: {leg.Nev} (ID: {leg.UgyfelId})", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a számítás során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Összes befizetés/kivét adott időszakban
        private void BtnOsszesBefizetes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(txtOsszesTol.Text.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tol) ||
                    !DateTime.TryParse(txtOsszesIg.Text.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ig))
                {
                    MessageBox.Show("Hibás dátum formátum!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var tranzakciok = bankRendszer.TranzakcioSzures(tol, ig);
                decimal osszesBefiz = tranzakciok.Where(t => t.Tipus != null && t.Tipus.ToLowerInvariant().Contains("bef")).Sum(t => t.Osszeg);
                decimal osszesKivet = tranzakciok.Where(t => t.Tipus != null && (t.Tipus.ToLowerInvariant().Contains("kiv") || t.Tipus.ToLowerInvariant().Contains("k"))).Sum(t => t.Osszeg);

                MessageBox.Show($"Összes befizetés: {osszesBefiz.ToString(CultureInfo.InvariantCulture)} Ft\nÖsszes kivét: {osszesKivet.ToString(CultureInfo.InvariantCulture)} Ft");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a statisztika számításakor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}