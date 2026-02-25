using BankiAlkalmazas;
using System;
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

            bankRendszer = new BankRendszer();
            bankRendszer.BetoltesFajlbol();

            FrissitUgyfelLista();
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

                // ---- ELLENŐRZÉS: létezik-e már ilyen ügyfél ----
                if (bankRendszer.GetUgyfelek().Any(u =>
                    u.Nev == nev &&
                    u.Lakcim == lakcim &&
                    u.SzuletesiDatum.ToString("yyyy-MM-dd") == szulDatum &&
                    u.Telefonszam == telefonszam))
                {
                    MessageBox.Show("Ilyen ügyfél már létezik!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Új ügyfél felvétele
                bankRendszer.UjUgyfelFelvetel(nev, lakcim, szulDatum, telefonszam);

                FrissitUgyfelLista();

                txtNev.Clear();
                txtLakcim.Clear();
                txtSzul.Clear();
                txtTelefonsz.Clear();

                bankRendszer.MentesFajlba();

                MessageBox.Show("Új ügyfél sikeresen felvéve!", "Siker",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrissitUgyfelLista()
        {
            listBoxUgyfelek.Items.Clear();
            foreach (var ugyfel in bankRendszer.GetUgyfelek())
                listBoxUgyfelek.Items.Add(ugyfel);
        }

        // ---------------------------
        // Új számla felvitele
        // ---------------------------
        private void BtnUjSzamla_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxUgyfelek.SelectedItem == null)
                {
                    MessageBox.Show("Válassz ki egy ügyfelet!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string szamlaszam = txtSzamlaszam.Text.Trim();
                string tip = txtSzamlaTipus.Text.Trim();

                if (string.IsNullOrWhiteSpace(szamlaszam) || string.IsNullOrWhiteSpace(tip))
                {
                    MessageBox.Show("Töltsd ki a számla mezőket!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ---- ELLENŐRZÉS: létezik-e már ilyen számlaszám ----
                if (bankRendszer.GetSzamlak().Any(s => s.Szamlaszam == szamlaszam))
                {
                    MessageBox.Show("Ilyen számlaszám már létezik!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ugyfel kiválasztottUgyfel = (Ugyfel)listBoxUgyfelek.SelectedItem;

                Szamla ujSzamla = new Szamla(szamlaszam, kiválasztottUgyfel.UgyfelId, tip, 0m, DateTime.Now);
                bankRendszer.UjSzamla(ujSzamla);
                bankRendszer.MentesFajlba();

                MessageBox.Show("Új számla felvéve!", "Siker",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSzamlaszam.Clear();
                txtSzamlaTipus.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Válassz ki egy ügyfelet!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Töltsd ki a tranzakció mezőket!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(osszegStr, out decimal osszeg))
                {
                    MessageBox.Show("Az összeg nem megfelelő formátum!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(datumStr, out DateTime datum))
                {
                    MessageBox.Show("A dátum nem megfelelő formátum!", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ugyfel kiválasztottUgyfel = (Ugyfel)listBoxUgyfelek.SelectedItem;

                Tranzakcio uj = new Tranzakcio(
                    bankRendszer.GetTranzakciok().Count + 1,
                    kiválasztottUgyfel.UgyfelId,
                    szamlaszam,
                    tipus,
                    osszeg,
                    datum,
                    partner
                );

                bankRendszer.UjTranzakcio(uj);
                bankRendszer.MentesFajlba();

                MessageBox.Show("Tranzakció rögzítve!", "Siker",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTranzSzamlaszam.Clear();
                txtTranzTipus.Clear();
                txtTranzOsszeg.Clear();
                txtTranzDatum.Clear();
                txtPartnerSzamlaszam.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------
        // Segédfüggvények
        // ---------------------------

        // Negatív egyenlegű számlák
        private void BtnNegativSzamlak_Click(object sender, EventArgs e)
        {
            var negativ = bankRendszer.NegativSzamlak();
            listBoxUgyfelek.Items.Clear();
            foreach (var s in negativ)
                listBoxUgyfelek.Items.Add(s);
        }

        // Tranzakciók szűrése dátum alapján
        private void BtnTranzSzures_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtTranzTolDatum.Text.Trim(), out DateTime tol) ||
                !DateTime.TryParse(txtTranzIgDatum.Text.Trim(), out DateTime ig))
            {
                MessageBox.Show("Hibás dátum formátum!");
                return;
            }

            var szures = bankRendszer.TranzakcioSzures(tol, ig);
            listBoxUgyfelek.Items.Clear();
            foreach (var t in szures)
                listBoxUgyfelek.Items.Add(t);
        }

        // Számlák szűrése típus és egyenleg alapján
        private void BtnSzamlaSzures_Click(object sender, EventArgs e)
        {
            string tipus = txtSzamlaTipusSzures.Text.Trim();
            decimal.TryParse(txtSzamlaMin.Text.Trim(), out decimal min);
            decimal.TryParse(txtSzamlaMax.Text.Trim(), out decimal max);

            var szures = bankRendszer.GetSzamlak()
                         .Where(s => (string.IsNullOrEmpty(tipus) || s.SzamlaTipus == tipus) &&
                                     s.Egyenleg >= min && s.Egyenleg <= max)
                         .ToList();

            listBoxUgyfelek.Items.Clear();
            foreach (var s in szures)
                listBoxUgyfelek.Items.Add(s);
        }

        // Legnagyobb forgalmú ügyfél
        private void BtnLegnagyobbForgalom_Click(object sender, EventArgs e)
        {
            var ugyfelek = bankRendszer.GetUgyfelek();
            var tranzakciok = bankRendszer.GetTranzakciok();

            int maxUgyfelId = -1;
            decimal maxOsszeg = 0;

            foreach (var u in ugyfelek)
            {
                decimal osszeg = tranzakciok
                                 .Where(t => bankRendszer.SzamlaTranzakcioi(t.ErintettSzamlaszam)
                                             .Any(s => s.UgyfelId == u.UgyfelId))
                                 .Sum(t => t.Osszeg);

                if (osszeg > maxOsszeg)
                {
                    maxOsszeg = osszeg;
                    maxUgyfelId = u.UgyfelId;
                }
            }

            var legnagyobb = ugyfelek.FirstOrDefault(u => u.UgyfelId == maxUgyfelId);
            MessageBox.Show(legnagyobb != null ? $"Legnagyobb forgalmú ügyfél: {legnagyobb.Nev} ({maxOsszeg} Ft)" : "Nincs adat");
        }

        // Összes befizetés/kivét adott időszakban
        private void BtnOsszesBefizetes_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtOsszesTol.Text.Trim(), out DateTime tol) ||
                !DateTime.TryParse(txtOsszesIg.Text.Trim(), out DateTime ig))
            {
                MessageBox.Show("Hibás dátum formátum!");
                return;
            }

            var tranzakciok = bankRendszer.TranzakcioSzures(tol, ig);
            decimal osszesBefiz = tranzakciok.Where(t => t.Tipus == "befizetés").Sum(t => t.Osszeg);
            decimal osszesKivet = tranzakciok.Where(t => t.Tipus == "kivét").Sum(t => t.Osszeg);

            MessageBox.Show($"Összes befizetés: {osszesBefiz} Ft\nÖsszes kivét: {osszesKivet} Ft");
        }

        
    }
}
