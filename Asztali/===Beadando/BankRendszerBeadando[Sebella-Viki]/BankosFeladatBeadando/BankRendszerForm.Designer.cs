namespace BankosFeladatBeadando
{
    partial class BankRendszerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.GroupBox groupBoxUgyfel;
        private System.Windows.Forms.Label labelNev;
        private System.Windows.Forms.Label labelLakcim;
        private System.Windows.Forms.Label labelSzul;
        private System.Windows.Forms.Label labelTelefonszam;
        private System.Windows.Forms.TextBox txtNev;
        private System.Windows.Forms.TextBox txtLakcim;
        private System.Windows.Forms.TextBox txtSzul;
        private System.Windows.Forms.TextBox txtTelefonsz;
        private System.Windows.Forms.Button btnUjUgyfel;

        private System.Windows.Forms.GroupBox groupBoxSzamla;
        private System.Windows.Forms.Label labelSzamlaszam;
        private System.Windows.Forms.Label labelSzamlaTipus;
        private System.Windows.Forms.TextBox txtSzamlaszam;
        private System.Windows.Forms.TextBox txtSzamlaTipus;
        private System.Windows.Forms.Button btnUjSzamla;

        private System.Windows.Forms.GroupBox groupBoxTranzakcio;
        private System.Windows.Forms.Label labelTranzSzamlaszam;
        private System.Windows.Forms.Label labelTranz;
        private System.Windows.Forms.Label labelTranzTipus;
        private System.Windows.Forms.Label labelTranzOsszeg;
        private System.Windows.Forms.Label labelTranzDatum;
        private System.Windows.Forms.Label labelPartner;
        private System.Windows.Forms.TextBox txtTranzSzamlaszam;
        private System.Windows.Forms.TextBox txtTranzTipus;
        private System.Windows.Forms.TextBox txtTranzOsszeg;
        private System.Windows.Forms.TextBox txtTranzDatum;
        private System.Windows.Forms.TextBox txtPartnerSzamlaszam;
        private System.Windows.Forms.Button btnUjTranzakcio;

        private System.Windows.Forms.GroupBox groupBoxSzures;
        private System.Windows.Forms.Label labelSzamlaTipusSzures;
        private System.Windows.Forms.TextBox txtSzamlaTipusSzures;
        private System.Windows.Forms.Label labelSzamlaMin;
        private System.Windows.Forms.TextBox txtSzamlaMin;
        private System.Windows.Forms.Label labelSzamlaMax;
        private System.Windows.Forms.TextBox txtSzamlaMax;
        private System.Windows.Forms.Button btnSzamlaSzures;

        private System.Windows.Forms.Label labelTranzTol;
        private System.Windows.Forms.TextBox txtTranzTolDatum;
        private System.Windows.Forms.Label labelTranzIg;
        private System.Windows.Forms.TextBox txtTranzIgDatum;
        private System.Windows.Forms.Button btnTranzSzures;

        private System.Windows.Forms.Button btnNegativSzamlak;
        private System.Windows.Forms.Button btnLegnagyobbForgalom;
        private System.Windows.Forms.Label labelOsszesTol;
        private System.Windows.Forms.TextBox txtOsszesTol;
        private System.Windows.Forms.Label labelOsszesIg;
        private System.Windows.Forms.TextBox txtOsszesIg;
        private System.Windows.Forms.Button btnOsszesBefizetes;

        private System.Windows.Forms.ListBox listBoxUgyfelek;
        private System.Windows.Forms.ListBox listBoxSzamlak;
        private System.Windows.Forms.ListBox listBoxTranzakciok;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxUgyfel = new System.Windows.Forms.GroupBox();
            this.labelNev = new System.Windows.Forms.Label();
            this.txtNev = new System.Windows.Forms.TextBox();
            this.labelLakcim = new System.Windows.Forms.Label();
            this.txtLakcim = new System.Windows.Forms.TextBox();
            this.labelSzul = new System.Windows.Forms.Label();
            this.txtSzul = new System.Windows.Forms.TextBox();
            this.labelTelefonszam = new System.Windows.Forms.Label();
            this.txtTelefonsz = new System.Windows.Forms.TextBox();
            this.btnUjUgyfel = new System.Windows.Forms.Button();
            this.groupBoxSzamla = new System.Windows.Forms.GroupBox();
            this.labelSzamlaszam = new System.Windows.Forms.Label();
            this.txtSzamlaszam = new System.Windows.Forms.TextBox();
            this.labelSzamlaTipus = new System.Windows.Forms.Label();
            this.txtSzamlaTipus = new System.Windows.Forms.TextBox();
            this.btnUjSzamla = new System.Windows.Forms.Button();
            this.groupBoxTranzakcio = new System.Windows.Forms.GroupBox();
            this.labelTranzSzamlaszam = new System.Windows.Forms.Label();
            this.txtTranzSzamlaszam = new System.Windows.Forms.TextBox();
            this.labelTranzTipus = new System.Windows.Forms.Label();
            this.txtTranzTipus = new System.Windows.Forms.TextBox();
            this.labelTranzOsszeg = new System.Windows.Forms.Label();
            this.txtTranzOsszeg = new System.Windows.Forms.TextBox();
            this.labelTranzDatum = new System.Windows.Forms.Label();
            this.txtTranzDatum = new System.Windows.Forms.TextBox();
            this.labelPartner = new System.Windows.Forms.Label();
            this.txtPartnerSzamlaszam = new System.Windows.Forms.TextBox();
            this.btnUjTranzakcio = new System.Windows.Forms.Button();
            this.listBoxUgyfelek = new System.Windows.Forms.ListBox();
            this.listBoxSzamlak = new System.Windows.Forms.ListBox();
            this.listBoxTranzakciok = new System.Windows.Forms.ListBox();
            this.groupBoxUgyfel.SuspendLayout();
            this.groupBoxSzamla.SuspendLayout();
            this.groupBoxTranzakcio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUgyfel
            // 
            this.groupBoxUgyfel.Controls.Add(this.labelNev);
            this.groupBoxUgyfel.Controls.Add(this.txtNev);
            this.groupBoxUgyfel.Controls.Add(this.labelLakcim);
            this.groupBoxUgyfel.Controls.Add(this.txtLakcim);
            this.groupBoxUgyfel.Controls.Add(this.labelSzul);
            this.groupBoxUgyfel.Controls.Add(this.txtSzul);
            this.groupBoxUgyfel.Controls.Add(this.labelTelefonszam);
            this.groupBoxUgyfel.Controls.Add(this.txtTelefonsz);
            this.groupBoxUgyfel.Controls.Add(this.btnUjUgyfel);
            this.groupBoxUgyfel.Location = new System.Drawing.Point(10, 10);
            this.groupBoxUgyfel.Name = "groupBoxUgyfel";
            this.groupBoxUgyfel.Size = new System.Drawing.Size(300, 150);
            this.groupBoxUgyfel.TabIndex = 0;
            this.groupBoxUgyfel.TabStop = false;
            this.groupBoxUgyfel.Text = "Ügyfél felvitele";
            // 
            // labelNev
            // 
            this.labelNev.Location = new System.Drawing.Point(10, 25);
            this.labelNev.Name = "labelNev";
            this.labelNev.Size = new System.Drawing.Size(100, 23);
            this.labelNev.TabIndex = 0;
            this.labelNev.Text = "Név:";
            // 
            // txtNev
            // 
            this.txtNev.Location = new System.Drawing.Point(120, 22);
            this.txtNev.Name = "txtNev";
            this.txtNev.Size = new System.Drawing.Size(100, 20);
            this.txtNev.TabIndex = 1;
            // 
            // labelLakcim
            // 
            this.labelLakcim.Location = new System.Drawing.Point(10, 50);
            this.labelLakcim.Name = "labelLakcim";
            this.labelLakcim.Size = new System.Drawing.Size(100, 23);
            this.labelLakcim.TabIndex = 2;
            this.labelLakcim.Text = "Lakcím:";
            // 
            // txtLakcim
            // 
            this.txtLakcim.Location = new System.Drawing.Point(120, 47);
            this.txtLakcim.Name = "txtLakcim";
            this.txtLakcim.Size = new System.Drawing.Size(100, 20);
            this.txtLakcim.TabIndex = 3;
            // 
            // labelSzul
            // 
            this.labelSzul.Location = new System.Drawing.Point(10, 75);
            this.labelSzul.Name = "labelSzul";
            this.labelSzul.Size = new System.Drawing.Size(100, 23);
            this.labelSzul.TabIndex = 4;
            this.labelSzul.Text = "Szül. dátum:";
            // 
            // txtSzul
            // 
            this.txtSzul.Location = new System.Drawing.Point(120, 72);
            this.txtSzul.Name = "txtSzul";
            this.txtSzul.Size = new System.Drawing.Size(100, 20);
            this.txtSzul.TabIndex = 5;
            // 
            // labelTelefonszam
            // 
            this.labelTelefonszam.Location = new System.Drawing.Point(10, 100);
            this.labelTelefonszam.Name = "labelTelefonszam";
            this.labelTelefonszam.Size = new System.Drawing.Size(100, 23);
            this.labelTelefonszam.TabIndex = 6;
            this.labelTelefonszam.Text = "Telefonszám:";
            // 
            // txtTelefonsz
            // 
            this.txtTelefonsz.Location = new System.Drawing.Point(120, 97);
            this.txtTelefonsz.Name = "txtTelefonsz";
            this.txtTelefonsz.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonsz.TabIndex = 7;
            // 
            // btnUjUgyfel
            // 
            this.btnUjUgyfel.Location = new System.Drawing.Point(80, 120);
            this.btnUjUgyfel.Name = "btnUjUgyfel";
            this.btnUjUgyfel.Size = new System.Drawing.Size(120, 25);
            this.btnUjUgyfel.TabIndex = 8;
            this.btnUjUgyfel.Text = "Új ügyfél felvitele";
            this.btnUjUgyfel.Click += new System.EventHandler(this.BtnUjUgyfel_Click);
            // 
            // groupBoxSzamla
            // 
            this.groupBoxSzamla.Controls.Add(this.labelSzamlaszam);
            this.groupBoxSzamla.Controls.Add(this.txtSzamlaszam);
            this.groupBoxSzamla.Controls.Add(this.labelSzamlaTipus);
            this.groupBoxSzamla.Controls.Add(this.txtSzamlaTipus);
            this.groupBoxSzamla.Controls.Add(this.btnUjSzamla);
            this.groupBoxSzamla.Location = new System.Drawing.Point(10, 170);
            this.groupBoxSzamla.Name = "groupBoxSzamla";
            this.groupBoxSzamla.Size = new System.Drawing.Size(300, 120);
            this.groupBoxSzamla.TabIndex = 1;
            this.groupBoxSzamla.TabStop = false;
            this.groupBoxSzamla.Text = "Számla felvitele";
            // 
            // labelSzamlaszam
            // 
            this.labelSzamlaszam.Location = new System.Drawing.Point(10, 25);
            this.labelSzamlaszam.Name = "labelSzamlaszam";
            this.labelSzamlaszam.Size = new System.Drawing.Size(100, 23);
            this.labelSzamlaszam.TabIndex = 0;
            this.labelSzamlaszam.Text = "Számlaszám:";
            // 
            // txtSzamlaszam
            // 
            this.txtSzamlaszam.Location = new System.Drawing.Point(120, 22);
            this.txtSzamlaszam.Name = "txtSzamlaszam";
            this.txtSzamlaszam.Size = new System.Drawing.Size(100, 20);
            this.txtSzamlaszam.TabIndex = 1;
            // 
            // labelSzamlaTipus
            // 
            this.labelSzamlaTipus.Location = new System.Drawing.Point(10, 50);
            this.labelSzamlaTipus.Name = "labelSzamlaTipus";
            this.labelSzamlaTipus.Size = new System.Drawing.Size(100, 23);
            this.labelSzamlaTipus.TabIndex = 2;
            this.labelSzamlaTipus.Text = "Típus:";
            // 
            // txtSzamlaTipus
            // 
            this.txtSzamlaTipus.Location = new System.Drawing.Point(120, 47);
            this.txtSzamlaTipus.Name = "txtSzamlaTipus";
            this.txtSzamlaTipus.Size = new System.Drawing.Size(100, 20);
            this.txtSzamlaTipus.TabIndex = 3;
            // 
            // btnUjSzamla
            // 
            this.btnUjSzamla.Location = new System.Drawing.Point(80, 75);
            this.btnUjSzamla.Name = "btnUjSzamla";
            this.btnUjSzamla.Size = new System.Drawing.Size(120, 25);
            this.btnUjSzamla.TabIndex = 4;
            this.btnUjSzamla.Text = "Új számla felvétele";
            this.btnUjSzamla.Click += new System.EventHandler(this.BtnUjSzamla_Click);
            // 
            // groupBoxTranzakcio
            // 
            this.groupBoxTranzakcio.Controls.Add(this.labelTranzSzamlaszam);
            this.groupBoxTranzakcio.Controls.Add(this.txtTranzSzamlaszam);
            this.groupBoxTranzakcio.Controls.Add(this.labelTranzTipus);
            this.groupBoxTranzakcio.Controls.Add(this.txtTranzTipus);
            this.groupBoxTranzakcio.Controls.Add(this.labelTranzOsszeg);
            this.groupBoxTranzakcio.Controls.Add(this.txtTranzOsszeg);
            this.groupBoxTranzakcio.Controls.Add(this.labelTranzDatum);
            this.groupBoxTranzakcio.Controls.Add(this.txtTranzDatum);
            this.groupBoxTranzakcio.Controls.Add(this.labelPartner);
            this.groupBoxTranzakcio.Controls.Add(this.txtPartnerSzamlaszam);
            this.groupBoxTranzakcio.Controls.Add(this.btnUjTranzakcio);
            this.groupBoxTranzakcio.Location = new System.Drawing.Point(10, 300);
            this.groupBoxTranzakcio.Name = "groupBoxTranzakcio";
            this.groupBoxTranzakcio.Size = new System.Drawing.Size(300, 180);
            this.groupBoxTranzakcio.TabIndex = 2;
            this.groupBoxTranzakcio.TabStop = false;
            this.groupBoxTranzakcio.Text = "Tranzakció felvitele";
            // 
            // labelTranzSzamlaszam
            // 
            this.labelTranzSzamlaszam.Location = new System.Drawing.Point(10, 25);
            this.labelTranzSzamlaszam.Name = "labelTranzSzamlaszam";
            this.labelTranzSzamlaszam.Size = new System.Drawing.Size(100, 23);
            this.labelTranzSzamlaszam.TabIndex = 0;
            this.labelTranzSzamlaszam.Text = "Számlaszám:";
            // 
            // txtTranzSzamlaszam
            // 
            this.txtTranzSzamlaszam.Location = new System.Drawing.Point(120, 22);
            this.txtTranzSzamlaszam.Name = "txtTranzSzamlaszam";
            this.txtTranzSzamlaszam.Size = new System.Drawing.Size(100, 20);
            this.txtTranzSzamlaszam.TabIndex = 1;
            // 
            // labelTranzTipus
            // 
            this.labelTranzTipus.Location = new System.Drawing.Point(10, 50);
            this.labelTranzTipus.Name = "labelTranzTipus";
            this.labelTranzTipus.Size = new System.Drawing.Size(100, 23);
            this.labelTranzTipus.TabIndex = 2;
            this.labelTranzTipus.Text = "Típus:";
            // 
            // txtTranzTipus
            // 
            this.txtTranzTipus.Location = new System.Drawing.Point(120, 47);
            this.txtTranzTipus.Name = "txtTranzTipus";
            this.txtTranzTipus.Size = new System.Drawing.Size(100, 20);
            this.txtTranzTipus.TabIndex = 3;
            // 
            // labelTranzOsszeg
            // 
            this.labelTranzOsszeg.Location = new System.Drawing.Point(10, 75);
            this.labelTranzOsszeg.Name = "labelTranzOsszeg";
            this.labelTranzOsszeg.Size = new System.Drawing.Size(100, 23);
            this.labelTranzOsszeg.TabIndex = 4;
            this.labelTranzOsszeg.Text = "Összeg:";
            // 
            // txtTranzOsszeg
            // 
            this.txtTranzOsszeg.Location = new System.Drawing.Point(120, 72);
            this.txtTranzOsszeg.Name = "txtTranzOsszeg";
            this.txtTranzOsszeg.Size = new System.Drawing.Size(100, 20);
            this.txtTranzOsszeg.TabIndex = 5;
            // 
            // labelTranzDatum
            // 
            this.labelTranzDatum.Location = new System.Drawing.Point(10, 100);
            this.labelTranzDatum.Name = "labelTranzDatum";
            this.labelTranzDatum.Size = new System.Drawing.Size(100, 23);
            this.labelTranzDatum.TabIndex = 6;
            this.labelTranzDatum.Text = "Dátum:";
            // 
            // txtTranzDatum
            // 
            this.txtTranzDatum.Location = new System.Drawing.Point(120, 97);
            this.txtTranzDatum.Name = "txtTranzDatum";
            this.txtTranzDatum.Size = new System.Drawing.Size(100, 20);
            this.txtTranzDatum.TabIndex = 7;
            // 
            // labelPartner
            // 
            this.labelPartner.Location = new System.Drawing.Point(10, 125);
            this.labelPartner.Name = "labelPartner";
            this.labelPartner.Size = new System.Drawing.Size(100, 23);
            this.labelPartner.TabIndex = 8;
            this.labelPartner.Text = "Partner számlaszám:";
            // 
            // txtPartnerSzamlaszam
            // 
            this.txtPartnerSzamlaszam.Location = new System.Drawing.Point(120, 122);
            this.txtPartnerSzamlaszam.Name = "txtPartnerSzamlaszam";
            this.txtPartnerSzamlaszam.Size = new System.Drawing.Size(100, 20);
            this.txtPartnerSzamlaszam.TabIndex = 9;
            // 
            // btnUjTranzakcio
            // 
            this.btnUjTranzakcio.Location = new System.Drawing.Point(80, 150);
            this.btnUjTranzakcio.Name = "btnUjTranzakcio";
            this.btnUjTranzakcio.Size = new System.Drawing.Size(120, 25);
            this.btnUjTranzakcio.TabIndex = 10;
            this.btnUjTranzakcio.Text = "Tranzakció rögzítése";
            this.btnUjTranzakcio.Click += new System.EventHandler(this.BtnUjTranzakcio_Click);
            // 
            // listBoxUgyfelek
            // 
            this.listBoxUgyfelek.Location = new System.Drawing.Point(330, 20);
            this.listBoxUgyfelek.Name = "listBoxUgyfelek";
            this.listBoxUgyfelek.Size = new System.Drawing.Size(250, 147);
            this.listBoxUgyfelek.TabIndex = 3;
            // 
            // listBoxSzamlak
            // 
            this.listBoxSzamlak.Location = new System.Drawing.Point(330, 190);
            this.listBoxSzamlak.Name = "listBoxSzamlak";
            this.listBoxSzamlak.Size = new System.Drawing.Size(250, 147);
            this.listBoxSzamlak.TabIndex = 4;
            // 
            // listBoxTranzakciok
            // 
            this.listBoxTranzakciok.Location = new System.Drawing.Point(330, 360);
            this.listBoxTranzakciok.Name = "listBoxTranzakciok";
            this.listBoxTranzakciok.Size = new System.Drawing.Size(250, 147);
            this.listBoxTranzakciok.TabIndex = 5;
            // 
            // BankRendszerForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 530);
            this.Controls.Add(this.groupBoxUgyfel);
            this.Controls.Add(this.groupBoxSzamla);
            this.Controls.Add(this.groupBoxTranzakcio);
            this.Controls.Add(this.listBoxUgyfelek);
            this.Controls.Add(this.listBoxSzamlak);
            this.Controls.Add(this.listBoxTranzakciok);
            this.Name = "BankRendszerForm";
            this.Text = "BankRendszer";
            this.groupBoxUgyfel.ResumeLayout(false);
            this.groupBoxUgyfel.PerformLayout();
            this.groupBoxSzamla.ResumeLayout(false);
            this.groupBoxSzamla.PerformLayout();
            this.groupBoxTranzakcio.ResumeLayout(false);
            this.groupBoxTranzakcio.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
