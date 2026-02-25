using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankosFeladatBeadando
{
    partial class BankRendszerForm
    {
        private System.ComponentModel.IContainer components = null;

        private SplitContainer splitContainerMain;

        // bal oldali navigáció
        private FlowLayoutPanel leftButtons;
        private Button btnTabUgyfel;
        private Button btnTabSzamla;
        private Button btnTabTranz;
        private Button btnTabSzures;

        // bal oldali tartalom panel (ide helyezzük a groupbox-okat, váltással láthatóvá tesszük)
        private Panel panelLeftContent;

        // Ügyfél controls
        private GroupBox groupBoxUgyfel;
        private Label labelNev;
        private Label labelLakcim;
        private Label labelSzul;
        private Label labelTelefonszam;
        private TextBox txtNev;
        private TextBox txtLakcim;
        private TextBox txtSzul;
        private TextBox txtTelefonsz;
        private Button btnUjUgyfel;

        // Számla controls
        private GroupBox groupBoxSzamla;
        private Label labelSzamlaszam;
        private Label labelSzamlaTipus;
        private TextBox txtSzamlaszam;
        private ComboBox comboSzamlaTipus;
        private NumericUpDown numericEgyenleg;
        private Button btnUjSzamla;

        // Tranzakció controls
        private GroupBox groupBoxTranzakcio;
        private Label labelTranzSzamlaszam;
        private Label labelTranzTipus;
        private Label labelTranzOsszeg;
        private Label labelTranzDatum;
        private Label labelPartner;
        private TextBox txtTranzSzamlaszam;
        private TextBox txtTranzTipus;
        private TextBox txtTranzOsszeg;
        private TextBox txtTranzDatum;
        private TextBox txtPartnerSzamlaszam;
        private Button btnUjTranzakcio;

        // Szűrés controls (bal oldali külön panel)
        private GroupBox groupBoxSzures;
        private Label labelSzamlaTipusSzures;
        private TextBox txtSzamlaTipusSzures;
        private Label labelSzamlaMin;
        private TextBox txtSzamlaMin;
        private Label labelSzamlaMax;
        private TextBox txtSzamlaMax;
        private Button btnSzamlaSzures;

        private Label labelTranzTol;
        private TextBox txtTranzTolDatum;
        private Label labelTranzIg;
        private TextBox txtTranzIgDatum;
        private Button btnTranzSzures;

        private Button btnNegativSzamlak;
        private Button btnLegnagyobbForgalom;
        private Label labelOsszesTol;
        private TextBox txtOsszesTol;
        private Label labelOsszesIg;
        private TextBox txtOsszesIg;
        private Button btnOsszesBefizetes;

        // jobb oldali TabControl (listák)
        private TabControl tabControlRight;
        private TabPage tabUgyfelek;
        private TabPage tabSzamlak;
        private TabPage tabTranzakciok;

        // ListBox-ok a jobb oldalon
        private ListBox listBoxUgyfelek;
        private ListBox listBoxSzamlak;
        private ListBox listBoxTranzakciok;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // SplitContainer
            this.splitContainerMain = new SplitContainer();
            this.splitContainerMain.Dock = DockStyle.Fill;
            this.splitContainerMain.Orientation = Orientation.Vertical;
            this.splitContainerMain.SplitterDistance = 220; // bal panel szélesség (navigációval)
            this.splitContainerMain.IsSplitterFixed = false;
            this.splitContainerMain.Panel1MinSize = 180;

            // -----------------------------
            // Bal oldali navigáció: FlowLayoutPanel gombokkal
            // -----------------------------
            this.leftButtons = new FlowLayoutPanel();
            this.leftButtons.FlowDirection = FlowDirection.TopDown;
            this.leftButtons.Dock = DockStyle.Left;
            this.leftButtons.Width = 160;
            this.leftButtons.Padding = new Padding(8);
            this.leftButtons.AutoScroll = true;

            this.btnTabUgyfel = new Button() { Text = "Ügyfél", Width = 140, Height = 44, Margin = new Padding(4) };
            this.btnTabSzamla = new Button() { Text = "Számla", Width = 140, Height = 44, Margin = new Padding(4) };
            this.btnTabTranz = new Button() { Text = "Tranzakció", Width = 140, Height = 44, Margin = new Padding(4) };
            this.btnTabSzures = new Button() { Text = "Szűrés / Egyéb", Width = 140, Height = 44, Margin = new Padding(4) };

            // A navigációs gombok viselkedése: a jobb oldali listák tabját is válthatjuk és a bal oldali tartalmat
            this.btnTabUgyfel.Click += (s, e) =>
            {
                // jobb oldali nézet: Ügyfelek
                if (this.tabControlRight != null) this.tabControlRight.SelectedIndex = 0;
                // bal oldali tartalom: csak Ügyfél group látható
                ShowLeftContent("ugyfel");
            };
            this.btnTabSzamla.Click += (s, e) =>
            {
                if (this.tabControlRight != null) this.tabControlRight.SelectedIndex = 1;
                ShowLeftContent("szamla");
            };
            this.btnTabTranz.Click += (s, e) =>
            {
                if (this.tabControlRight != null) this.tabControlRight.SelectedIndex = 2;
                ShowLeftContent("tranzakcio");
            };
            this.btnTabSzures.Click += (s, e) =>
            {
                if (this.tabControlRight != null) this.tabControlRight.SelectedIndex = 0;
                ShowLeftContent("szures");
            };

            this.leftButtons.Controls.AddRange(new Control[] { btnTabUgyfel, btnTabSzamla, btnTabTranz, btnTabSzures });

            // -----------------------------
            // Bal oldali tartalom panel (ide kerülnek a groupboxok, külön láthatóvá tesszük őket)
            // -----------------------------
            this.panelLeftContent = new Panel();
            this.panelLeftContent.Dock = DockStyle.Fill;
            this.panelLeftContent.Padding = new Padding(8);
            this.panelLeftContent.AutoScroll = true;

            // -----------------------------
            // Ügyfél groupbox és mezők
            // -----------------------------
            this.groupBoxUgyfel = new GroupBox();
            this.groupBoxUgyfel.Text = "Ügyfél felvitele";
            this.groupBoxUgyfel.Size = new Size(480, 220);
            this.groupBoxUgyfel.Location = new Point(0, 0);

            this.labelNev = new Label() { Text = "Név:", Location = new Point(10, 22), AutoSize = true };
            this.txtNev = new TextBox() { Location = new Point(120, 18), Width = 320 };
            this.labelLakcim = new Label() { Text = "Lakcím:", Location = new Point(10, 56), AutoSize = true };
            this.txtLakcim = new TextBox() { Location = new Point(120, 52), Width = 320 };
            this.labelSzul = new Label() { Text = "Szül. dátum:", Location = new Point(10, 90), AutoSize = true };
            this.txtSzul = new TextBox() { Location = new Point(120, 86), Width = 320 };
            this.labelTelefonszam = new Label() { Text = "Telefonszám:", Location = new Point(10, 124), AutoSize = true };
            this.txtTelefonsz = new TextBox() { Location = new Point(120, 120), Width = 320 };
            this.btnUjUgyfel = new Button() { Text = "Új ügyfél felvitele", Location = new Point(160, 160), Size = new Size(160, 34) };
            this.btnUjUgyfel.Click += new EventHandler(this.BtnUjUgyfel_Click);

            this.groupBoxUgyfel.Controls.AddRange(new Control[] {
                labelNev, txtNev, labelLakcim, txtLakcim, labelSzul, txtSzul, labelTelefonszam, txtTelefonsz, btnUjUgyfel
            });

            // -----------------------------
            // Számla groupbox és mezők
            // -----------------------------
            this.groupBoxSzamla = new GroupBox();
            this.groupBoxSzamla.Text = "Számla felvitele";
            this.groupBoxSzamla.Size = new Size(480, 160);
            this.groupBoxSzamla.Location = new Point(0, 0);

            this.labelSzamlaszam = new Label() { Text = "Számlaszám:", Location = new Point(10, 22), AutoSize = true };
            this.txtSzamlaszam = new TextBox() { Location = new Point(120, 18), Width = 320 };
            this.labelSzamlaTipus = new Label() { Text = "Típus:", Location = new Point(10, 56), AutoSize = true };
            this.comboSzamlaTipus = new ComboBox()
            {
                Location = new Point(120, 52),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Feltöltés számlatípusokkal
            this.comboSzamlaTipus.Items.AddRange(new string[]
            {
            "Fizetési számla",
            "Megtakarítási számla",
            "Diákszámla",
            "Devizaszámla",
            "Értékpapírszámla",
            "TBSZ (Tartós Befektetési Számla)"
            });
            this.comboSzamlaTipus.SelectedIndex = 0; // alapértelmezett érték

            // NumericUpDown az egyenleghez
            this.numericEgyenleg = new NumericUpDown()
            {
                Location = new Point(120, 86),  // a ComboBox alá igazítva
                Width = 120,
                DecimalPlaces = 2,
                Maximum = 1000000000,
                Minimum = 0,
                Value = 0
            };


            this.btnUjSzamla = new Button() { Text = "Új számla felvétele", Location = new Point(160, 90), Size = new Size(160, 34) };
            this.btnUjSzamla.Click += new EventHandler(this.BtnUjSzamla_Click);

            this.groupBoxSzamla.Controls.AddRange(new Control[] {
                labelSzamlaszam, txtSzamlaszam, labelSzamlaTipus, comboSzamlaTipus,numericEgyenleg, btnUjSzamla
            });

            // -----------------------------
            // Tranzakció groupbox és mezők
            // -----------------------------
            this.groupBoxTranzakcio = new GroupBox();
            this.groupBoxTranzakcio.Text = "Tranzakció felvitele";
            this.groupBoxTranzakcio.Size = new Size(480, 220);
            this.groupBoxTranzakcio.Location = new Point(0, 0);

            this.labelTranzSzamlaszam = new Label() { Text = "Számlaszám:", Location = new Point(10, 22), AutoSize = true };
            this.txtTranzSzamlaszam = new TextBox() { Location = new Point(140, 18), Width = 300 };
            this.labelTranzTipus = new Label() { Text = "Típus:", Location = new Point(10, 56), AutoSize = true };
            this.txtTranzTipus = new TextBox() { Location = new Point(140, 52), Width = 200 };
            this.labelTranzOsszeg = new Label() { Text = "Összeg:", Location = new Point(10, 90), AutoSize = true };
            this.txtTranzOsszeg = new TextBox() { Location = new Point(140, 86), Width = 200 };
            this.labelTranzDatum = new Label() { Text = "Dátum:", Location = new Point(10, 124), AutoSize = true };
            this.txtTranzDatum = new TextBox() { Location = new Point(140, 120), Width = 200 };
            this.labelPartner = new Label() { Text = "Partner számlaszám:", Location = new Point(10, 158), AutoSize = true };
            this.txtPartnerSzamlaszam = new TextBox() { Location = new Point(140, 154), Width = 200 };
            this.btnUjTranzakcio = new Button() { Text = "Tranzakció rögzítése", Location = new Point(160, 184), Size = new Size(160, 34) };
            this.btnUjTranzakcio.Click += new EventHandler(this.BtnUjTranzakcio_Click);

            this.groupBoxTranzakcio.Controls.AddRange(new Control[] {
                labelTranzSzamlaszam, txtTranzSzamlaszam, labelTranzTipus, txtTranzTipus,
                labelTranzOsszeg, txtTranzOsszeg, labelTranzDatum, txtTranzDatum,
                labelPartner, txtPartnerSzamlaszam, btnUjTranzakcio
            });

            // -----------------------------
            // Szűrés groupbox és mezők (bal oldali külön fül/gombbal elérhető)
            // -----------------------------
            this.groupBoxSzures = new GroupBox();
            this.groupBoxSzures.Text = "Szűrési beállítások";
            this.groupBoxSzures.Size = new Size(480, 280);
            this.groupBoxSzures.Location = new Point(0, 0);

            this.labelSzamlaTipusSzures = new Label() { Text = "Számlatípus:", Location = new Point(10, 22), AutoSize = true };
            this.txtSzamlaTipusSzures = new TextBox() { Location = new Point(120, 18), Width = 220 };
            this.labelSzamlaMin = new Label() { Text = "Min egyenleg:", Location = new Point(10, 56), AutoSize = true };
            this.txtSzamlaMin = new TextBox() { Location = new Point(120, 52), Width = 90 };
            this.labelSzamlaMax = new Label() { Text = "Max egyenleg:", Location = new Point(220, 56), AutoSize = true };
            this.txtSzamlaMax = new TextBox() { Location = new Point(300, 52), Width = 90 };
            this.btnSzamlaSzures = new Button() { Text = "Számla szűrés", Location = new Point(120, 86), Size = new Size(140, 30) };
            this.btnSzamlaSzures.Click += new EventHandler(this.BtnSzamlaSzures_Click);

            this.labelTranzTol = new Label() { Text = "Tranz. dátum tol:", Location = new Point(10, 130), AutoSize = true };
            this.txtTranzTolDatum = new TextBox() { Location = new Point(120, 126), Width = 130 };
            this.labelTranzIg = new Label() { Text = "Tranz. dátum ig:", Location = new Point(260, 130), AutoSize = true };
            this.txtTranzIgDatum = new TextBox() { Location = new Point(360, 126), Width = 130 };
            this.btnTranzSzures = new Button() { Text = "Tranzakció szűrés", Location = new Point(120, 162), Size = new Size(140, 30) };
            this.btnTranzSzures.Click += new EventHandler(this.BtnTranzSzures_Click);

            this.btnNegativSzamlak = new Button() { Text = "Negatív számlák", Location = new Point(10, 206), Size = new Size(120, 30) };
            this.btnNegativSzamlak.Click += new EventHandler(this.BtnNegativSzamlak_Click);
            this.btnLegnagyobbForgalom = new Button() { Text = "Legnagyobb forgalom", Location = new Point(140, 206), Size = new Size(160, 30) };
            this.btnLegnagyobbForgalom.Click += new EventHandler(this.BtnLegnagyobbForgalom_Click);

            this.labelOsszesTol = new Label() { Text = "Összes Tol:", Location = new Point(10, 246), AutoSize = true };
            this.txtOsszesTol = new TextBox() { Location = new Point(80, 242), Width = 120 };
            this.labelOsszesIg = new Label() { Text = "Ig:", Location = new Point(210, 246), AutoSize = true };
            this.txtOsszesIg = new TextBox() { Location = new Point(230, 242), Width = 120 };
            this.btnOsszesBefizetes = new Button() { Text = "Összes bef/kiv", Location = new Point(360, 240), Size = new Size(120, 30) };
            this.btnOsszesBefizetes.Click += new EventHandler(this.BtnOsszesBefizetes_Click);

            this.groupBoxSzures.Controls.AddRange(new Control[] {
                labelSzamlaTipusSzures, txtSzamlaTipusSzures, labelSzamlaMin, txtSzamlaMin, labelSzamlaMax, txtSzamlaMax, btnSzamlaSzures,
                labelTranzTol, txtTranzTolDatum, labelTranzIg, txtTranzIgDatum, btnTranzSzures,
                btnNegativSzamlak, btnLegnagyobbForgalom, labelOsszesTol, txtOsszesTol, labelOsszesIg, txtOsszesIg, btnOsszesBefizetes
            });

            // -----------------------------
            // Add groupboxes into left content panel (mind ott van, de csak az aktív lesz látható)
            // -----------------------------
            this.panelLeftContent.Controls.AddRange(new Control[] {
                groupBoxUgyfel, groupBoxSzamla, groupBoxTranzakcio, groupBoxSzures
            });

            // By default show the Ügyfél content
            SetGroupBoxesVisible("ugyfel");

            // Put leftButtons and panelLeftContent into splitContainer.Panel1
            // We'll add leftButtons docked left and panelLeftContent fill the remainder
            // To make layout work, create a container panel to host both
            var leftContainer = new Panel();
            leftContainer.Dock = DockStyle.Fill;
            leftContainer.Padding = new Padding(0);
            leftContainer.Controls.Add(panelLeftContent);
            leftContainer.Controls.Add(leftButtons); // leftButtons docked left, panel fills rest

            this.splitContainerMain.Panel1.Controls.Add(leftContainer);

            // -----------------------------
            // Jobb oldali TabControl (listák)
            // -----------------------------
            this.tabControlRight = new TabControl();
            this.tabControlRight.Dock = DockStyle.Fill;

            this.tabUgyfelek = new TabPage("Ügyfelek");
            this.tabSzamlak = new TabPage("Számlák");
            this.tabTranzakciok = new TabPage("Tranzakciók");

            this.listBoxUgyfelek = new ListBox() { Dock = DockStyle.Fill };
            this.listBoxSzamlak = new ListBox() { Dock = DockStyle.Fill };
            this.listBoxTranzakciok = new ListBox() { Dock = DockStyle.Fill };

            this.tabUgyfelek.Controls.Add(this.listBoxUgyfelek);
            this.tabSzamlak.Controls.Add(this.listBoxSzamlak);
            this.tabTranzakciok.Controls.Add(this.listBoxTranzakciok);

            this.tabControlRight.TabPages.AddRange(new TabPage[] {
                this.tabUgyfelek, this.tabSzamlak, this.tabTranzakciok
            });

            this.splitContainerMain.Panel2.Controls.Add(this.tabControlRight);

            // Add split container to form
            this.Controls.Add(this.splitContainerMain);

            // Form settings
            this.Text = "BankRendszer";
            this.ClientSize = new Size(1100, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Helper: set which groupbox is visible
        private void SetGroupBoxesVisible(string key)
        {
            if (groupBoxUgyfel == null) return;
            groupBoxUgyfel.Visible = false;
            groupBoxSzamla.Visible = false;
            groupBoxTranzakcio.Visible = false;
            groupBoxSzures.Visible = false;

            switch (key?.ToLowerInvariant())
            {
                case "szamla":
                    groupBoxSzamla.Visible = true;
                    break;
                case "tranzakcio":
                    groupBoxTranzakcio.Visible = true;
                    break;
                case "szures":
                    groupBoxSzures.Visible = true;
                    break;
                default:
                    groupBoxUgyfel.Visible = true;
                    break;
            }
        }

        // Exposed method used by nav button lambdas above
        private void ShowLeftContent(string key)
        {
            SetGroupBoxesVisible(key);
        }
    }
}