
namespace FinalProjeAsli
{
    partial class KitapIslemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapIslemForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSil = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_IdSil = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_gTur = new System.Windows.Forms.ComboBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxTur = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.txtSayfa = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_gYazar = new System.Windows.Forms.TextBox();
            this.txt_gSayfa = new System.Windows.Forms.TextBox();
            this.txt_gAd = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBilgilendirme = new System.Windows.Forms.Label();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.pictureBoxKitapBilgi = new System.Windows.Forms.PictureBox();
            this.lblIade = new System.Windows.Forms.Label();
            this.pictureBoxIadeBilgi = new System.Windows.Forms.PictureBox();
            this.kitapListe = new System.Windows.Forms.DataGridView();
            this.lblListe = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblOgrenci = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKitapBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIadeBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitapListe)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txt_IdSil);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.Location = new System.Drawing.Point(30, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 123);
            this.panel2.TabIndex = 41;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FloralWhite;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(297, 64);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 24);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(19, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "Kitap Id : ";
            // 
            // txt_IdSil
            // 
            this.txt_IdSil.Location = new System.Drawing.Point(152, 64);
            this.txt_IdSil.Name = "txt_IdSil";
            this.txt_IdSil.Size = new System.Drawing.Size(100, 27);
            this.txt_IdSil.TabIndex = 2;
            this.txt_IdSil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_IdSil_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.LimeGreen;
            this.label7.Location = new System.Drawing.Point(147, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "KİTAP SİL";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(40, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(681, 63);
            this.label13.TabIndex = 29;
            this.label13.Text = "Not: Güncellemek istediğiniz kitabın listeden üzerine tıklayınız .\r\n \r\n\r\n";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Cyan;
            this.label12.Location = new System.Drawing.Point(637, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 24);
            this.label12.TabIndex = 28;
            this.label12.Text = "Yazar ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Cyan;
            this.label10.Location = new System.Drawing.Point(466, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "Sayfa ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(303, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Tür";
            // 
            // comboBox_gTur
            // 
            this.comboBox_gTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gTur.FormattingEnabled = true;
            this.comboBox_gTur.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox_gTur.Items.AddRange(new object[] {
            "Roman",
            "Tarih",
            "Bilim",
            "Oyku",
            "Siir"});
            this.comboBox_gTur.Location = new System.Drawing.Point(275, 74);
            this.comboBox_gTur.Name = "comboBox_gTur";
            this.comboBox_gTur.Size = new System.Drawing.Size(100, 27);
            this.comboBox_gTur.TabIndex = 25;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.White;
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(339, 128);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(119, 31);
            this.btnGuncelle.TabIndex = 24;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Cyan;
            this.label11.Location = new System.Drawing.Point(133, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "Ad ";
            // 
            // comboBoxTur
            // 
            this.comboBoxTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTur.FormattingEnabled = true;
            this.comboBoxTur.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxTur.Items.AddRange(new object[] {
            "Roman",
            "Tarih",
            "Bilim",
            "Oyku",
            "Siir"});
            this.comboBoxTur.Location = new System.Drawing.Point(154, 119);
            this.comboBoxTur.Name = "comboBoxTur";
            this.comboBoxTur.Size = new System.Drawing.Size(100, 27);
            this.comboBoxTur.TabIndex = 26;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.White;
            this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(154, 267);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 27);
            this.btnEkle.TabIndex = 11;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(154, 215);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(100, 27);
            this.txtYazar.TabIndex = 9;
            // 
            // txtSayfa
            // 
            this.txtSayfa.Location = new System.Drawing.Point(154, 167);
            this.txtSayfa.Name = "txtSayfa";
            this.txtSayfa.Size = new System.Drawing.Size(100, 27);
            this.txtSayfa.TabIndex = 8;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(154, 71);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(100, 27);
            this.txtAd.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(60, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Yazar :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(63, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sayfa :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(81, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tür :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.comboBoxTur);
            this.panel1.Controls.Add(this.btnEkle);
            this.panel1.Controls.Add(this.txtYazar);
            this.panel1.Controls.Add(this.txtSayfa);
            this.panel1.Controls.Add(this.txtAd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(97, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 316);
            this.panel1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(87, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ad :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(86, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "KİTAP EKLE";
            // 
            // txt_gYazar
            // 
            this.txt_gYazar.Location = new System.Drawing.Point(621, 76);
            this.txt_gYazar.Name = "txt_gYazar";
            this.txt_gYazar.Size = new System.Drawing.Size(100, 27);
            this.txt_gYazar.TabIndex = 16;
            // 
            // txt_gSayfa
            // 
            this.txt_gSayfa.Location = new System.Drawing.Point(447, 76);
            this.txt_gSayfa.Name = "txt_gSayfa";
            this.txt_gSayfa.Size = new System.Drawing.Size(100, 27);
            this.txt_gSayfa.TabIndex = 15;
            this.txt_gSayfa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_gSayfa_KeyPress);
            // 
            // txt_gAd
            // 
            this.txt_gAd.Location = new System.Drawing.Point(102, 76);
            this.txt_gAd.Name = "txt_gAd";
            this.txt_gAd.Size = new System.Drawing.Size(100, 27);
            this.txt_gAd.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox_gTur);
            this.panel3.Controls.Add(this.btnGuncelle);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txt_gYazar);
            this.panel3.Controls.Add(this.txt_gSayfa);
            this.panel3.Controls.Add(this.txt_gAd);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel3.Location = new System.Drawing.Point(453, 472);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 243);
            this.panel3.TabIndex = 42;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.LimeGreen;
            this.label9.Location = new System.Drawing.Point(316, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(230, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "KİTAP GÜNCELLE";
            // 
            // lblBilgilendirme
            // 
            this.lblBilgilendirme.BackColor = System.Drawing.Color.Transparent;
            this.lblBilgilendirme.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgilendirme.ForeColor = System.Drawing.Color.White;
            this.lblBilgilendirme.Location = new System.Drawing.Point(29, 273);
            this.lblBilgilendirme.Name = "lblBilgilendirme";
            this.lblBilgilendirme.Size = new System.Drawing.Size(736, 55);
            this.lblBilgilendirme.TabIndex = 0;
            this.lblBilgilendirme.Text = "Not: İade bilgisini öğrenmek istediğiniz kitabın listeden üzerine tıklayıp iade b" +
    "ilgisi butonuna basınız.";
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.BackColor = System.Drawing.Color.Transparent;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.ForeColor = System.Drawing.Color.Cyan;
            this.lblBilgi.Location = new System.Drawing.Point(63, 58);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(96, 18);
            this.lblBilgi.TabIndex = 6;
            this.lblBilgi.Text = "Kitap Bilgisi";
            // 
            // pictureBoxKitapBilgi
            // 
            this.pictureBoxKitapBilgi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxKitapBilgi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxKitapBilgi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxKitapBilgi.Image")));
            this.pictureBoxKitapBilgi.Location = new System.Drawing.Point(84, 17);
            this.pictureBoxKitapBilgi.Name = "pictureBoxKitapBilgi";
            this.pictureBoxKitapBilgi.Size = new System.Drawing.Size(41, 37);
            this.pictureBoxKitapBilgi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxKitapBilgi.TabIndex = 5;
            this.pictureBoxKitapBilgi.TabStop = false;
            this.pictureBoxKitapBilgi.Click += new System.EventHandler(this.pictureBoxKitapBilgi_Click);
            // 
            // lblIade
            // 
            this.lblIade.AutoSize = true;
            this.lblIade.BackColor = System.Drawing.Color.Transparent;
            this.lblIade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIade.ForeColor = System.Drawing.Color.Cyan;
            this.lblIade.Location = new System.Drawing.Point(638, 58);
            this.lblIade.Name = "lblIade";
            this.lblIade.Size = new System.Drawing.Size(89, 18);
            this.lblIade.TabIndex = 4;
            this.lblIade.Text = "İade Bilgisi";
            // 
            // pictureBoxIadeBilgi
            // 
            this.pictureBoxIadeBilgi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIadeBilgi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIadeBilgi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIadeBilgi.Image")));
            this.pictureBoxIadeBilgi.Location = new System.Drawing.Point(659, 17);
            this.pictureBoxIadeBilgi.Name = "pictureBoxIadeBilgi";
            this.pictureBoxIadeBilgi.Size = new System.Drawing.Size(41, 37);
            this.pictureBoxIadeBilgi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIadeBilgi.TabIndex = 3;
            this.pictureBoxIadeBilgi.TabStop = false;
            this.pictureBoxIadeBilgi.Click += new System.EventHandler(this.pictureBoxIadeBilgi_Click);
            // 
            // kitapListe
            // 
            this.kitapListe.AllowUserToAddRows = false;
            this.kitapListe.AllowUserToDeleteRows = false;
            this.kitapListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kitapListe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.kitapListe.BackgroundColor = System.Drawing.Color.White;
            this.kitapListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kitapListe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kitapListe.Location = new System.Drawing.Point(10, 100);
            this.kitapListe.Name = "kitapListe";
            this.kitapListe.ReadOnly = true;
            this.kitapListe.RowHeadersWidth = 51;
            this.kitapListe.RowTemplate.Height = 24;
            this.kitapListe.Size = new System.Drawing.Size(758, 152);
            this.kitapListe.TabIndex = 2;
            this.kitapListe.SelectionChanged += new System.EventHandler(this.kitapListe_SelectionChanged);
            // 
            // lblListe
            // 
            this.lblListe.AutoSize = true;
            this.lblListe.BackColor = System.Drawing.Color.Transparent;
            this.lblListe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblListe.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblListe.Location = new System.Drawing.Point(270, 42);
            this.lblListe.Name = "lblListe";
            this.lblListe.Size = new System.Drawing.Size(261, 29);
            this.lblListe.TabIndex = 1;
            this.lblListe.Text = "KİTAP BİLGİ LİSTESİ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Controls.Add(this.lblBilgilendirme);
            this.panel4.Controls.Add(this.lblBilgi);
            this.panel4.Controls.Add(this.pictureBoxKitapBilgi);
            this.panel4.Controls.Add(this.lblIade);
            this.panel4.Controls.Add(this.pictureBoxIadeBilgi);
            this.panel4.Controls.Add(this.kitapListe);
            this.panel4.Controls.Add(this.lblListe);
            this.panel4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel4.Location = new System.Drawing.Point(453, 114);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(799, 352);
            this.panel4.TabIndex = 43;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(1282, 53);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 54);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.ImageKey = "reply.png";
            this.button2.Location = new System.Drawing.Point(3, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 54);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.AutoSize = true;
            this.lblOgrenci.BackColor = System.Drawing.Color.Transparent;
            this.lblOgrenci.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOgrenci.ForeColor = System.Drawing.Color.Firebrick;
            this.lblOgrenci.Location = new System.Drawing.Point(479, 40);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(366, 46);
            this.lblOgrenci.TabIndex = 37;
            this.lblOgrenci.Text = "KİTAP  İŞLEMLERİ";
            // 
            // KitapIslemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1338, 727);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblOgrenci);
            this.Name = "KitapIslemForm";
            this.Text = "KitapIslemForm";
            this.Load += new System.EventHandler(this.KitapIslemForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKitapBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIadeBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitapListe)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_IdSil;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_gTur;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxTur;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.TextBox txtSayfa;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_gYazar;
        private System.Windows.Forms.TextBox txt_gSayfa;
        private System.Windows.Forms.TextBox txt_gAd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBilgilendirme;
        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.PictureBox pictureBoxKitapBilgi;
        private System.Windows.Forms.Label lblIade;
        private System.Windows.Forms.PictureBox pictureBoxIadeBilgi;
        private System.Windows.Forms.DataGridView kitapListe;
        private System.Windows.Forms.Label lblListe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblOgrenci;
    }
}