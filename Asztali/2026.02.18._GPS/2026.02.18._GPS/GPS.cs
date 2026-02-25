using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2026._02._18._GPS
{
    internal class GPS
    {
        List<Varosok> varosLista = new List<Varosok>();

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Keresd meg a helysegek.txt fájlt beolvasásra!");

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text fájl|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var sor in File.ReadAllLines(ofd.FileName))
                {
                    string[] adat = sor.Split(';');

                    Varosok v = new Varosok(
                        adat[0],
                        adat[1],
                        adat[2],
                        adat[3]
                    );

                    varosLista.Add(v);
                }
            }

            MegyekBetoltese();
        }

        private void MegyekBetoltese()
        {
            var megyek = varosLista
                .Select(x => x.Megye)
                .Distinct()
                .OrderBy(x => x);

            foreach (var m in megyek)
                megyeComboBox.Items.Add(m);
        }


        private void megyeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            varosListBox.Items.Clear();

            foreach (var v in varosLista)
            {
                if (v.Megye == megyeComboBox.Text)
                    varosListBox.Items.Add(v.Nev);
            }
        }


        private void nevTextBox_TextChanged(object sender, EventArgs e)
        {
            varosListBox.Items.Clear();

            foreach (var v in varosLista)
            {
                if (v.Nev.ToLower().Contains(nevTextBox.Text.ToLower()))
                    varosListBox.Items.Add(v.Nev);
            }
        }
        private void varosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            adatokListBox.Items.Clear();

            var kivalasztott = varosLista
                .FirstOrDefault(x => x.Nev == varosListBox.Text);

            if (kivalasztott != null)
            {
                foreach (var adat in kivalasztott.Adatok())
                    adatokListBox.Items.Add(adat);
            }
        }
        private void mentesButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text fájl|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(
                    sfd.FileName,
                    adatokListBox.Items.Cast<string>()
                );
            }
        }

    }
}
