using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;        // BL katmanını kullanmak için ekledim.
using Entity;    // Entity katmanını kullanmak için ekledim.

namespace FinalProjeAsli
{
    public partial class OgrenciIslemForm : Form
    {
        public OgrenciIslemForm()
        {
            InitializeComponent();
        }

        private void OgrenciIslemForm_Load(object sender, EventArgs e)            //OgrenciForm u açılır açılmaz yapılması gereken işlemleri yazdım.
        {
            ogrenciListe.DataSource = OgrenciBL.liste();         // BL katmanının OgrenciBL classının liste() fonksiyonunu çağırdım ve ogrenciListe datagridview ine listeledim. Yani kayıtlı tüm öğrencileri listeledim.
            
            ogrenciListe.Columns[0].HeaderText = "Id";           //ogrenciListe datagridview inin 1. sütununun başlığını ID yaptım.
            ogrenciListe.Columns[1].HeaderText = "Ad";           //ogrenciListe datagridview inin 2. sütununun başlığını Ad yaptım.
            ogrenciListe.Columns[2].HeaderText = "Soyad";        //ogrenciListe datagridview inin 3. sütununun başlığını Soyad yaptım.
            ogrenciListe.Columns[3].HeaderText = "Okul NO";      //ogrenciListe datagridview inin 4. sütununun başlığını Okul NO yaptım.
            ogrenciListe.Columns[4].HeaderText = "Sifre";        //ogrenciListe datagridview inin 5. sütununun başlığını Sifre yaptım.
            ogrenciListe.Columns[5].HeaderText = "Cinsiyet";     //ogrenciListe datagridview inin 6. sütununun başlığını Cinsiyet yaptım.
            ogrenciListe.Columns[6].HeaderText = "Ceza";         //ogrenciListe datagridview inin 7. sütununun başlığını Ceza yaptım.

            
            id = 0;                           // Form açıldığında global id nin değerini 0 yaptım.
            txt_gAd.Text = "";                // Form açıldığında guncelleme kısmındaki txt_gAd textboxı temizledim.
            txt_gSoyad.Text = "";             // Form açıldığında guncelleme kısmındaki txt_gSoyad textboxı temizledim.
            txt_gNo.Text = "";                // Form açıldığında guncelleme kısmındaki txt_gNo textboxı temizledim.
            txt_gSifre.Text = "";             // Form açıldığında guncelleme kısmındaki txt_gSifre textboxı temizledim.
            comboBox_gCinsiyet.Text = "";     // Form açıldığında guncelleme kısmındaki comboBox_gCinsiyet combobox ının içini temizledim.
        }

        private void btnEkle_Click(object sender, EventArgs e)           //btnEkle butonuna tıklandığında öğrenci ekleme işlemini gerçekleştirdim.
        {
            
            if (txtAd.Text != "" && txtSoyad.Text != "" && txtNo.Text != "" && txtSifre.Text != "" && comboBoxCinsiyet.Text != "")  //Eğer txtAd, txtSoyad, txtNo, txtSifre textbox ları ve comboBoxCinsiyet combobox u boş değil ise
            {
                
                OgrenciVeri ogrenci = new OgrenciVeri()      //Entity katmanındaki OgrenciVeri class ından ogrenci nesnesini oluşturdum.
                {
                    OgrenciAd = txtAd.Text,                      //ogrenci nesnesinin ogrenciAd değişkenine txtAd TextBox ının metnini Set metodu ile atadım.
                    OgrenciSoyad = txtSoyad.Text,                //ogrenci nesnesinin ogrenciSoyad değişkenine txtSoyad TextBox ının metnini Set metodu ile atadım.
                    OgrenciNo = txtNo.Text,                      //ogrenci nesnesinin ogrenciNo değişkenine txtNo TextBox ının metnini Set metodu ile atadım.
                    OgrenciSifre = txtSifre.Text,                //ogrenci nesnesinin ogrenciSifre değişkenine txtSifre TextBox ının metnini Set metodu ile atadım.
                    OgrenciCinsiyet = comboBoxCinsiyet.Text      //ogrenci nesnesinin ogrenciCinsiyet değişkenine comboBoxCinsiyet combobox ının metnini Set metodu ile atadım.
                };
                if (OgrenciBL.ogrenciOkulNoKOntrol(ogrenci) == true)   // BL katmanının OgrenciBL classının ogrenciOkulNoKOntrol() fonksiyonuna ogrenci nesnesini parametre göndererek çağırdım ve 
                                                                       // okul numarasının daha önce kayıtlı olup olmadığını kontrol ettim. Eğer numara kayıtlı değil ise true değeri döndü ise
                {

                    OgrenciBL.ogrenciEkle(ogrenci);                  // BL katmanının OgrenciBL classının ogrenciEkle() fonksiyonunu ogrenci nesnesi ile çağırdım ve ogrenciyi veritabanına kaydettirdim.
                    MessageBox.Show("Eklendi");                      //Ekrana 'Eklendi' mesajını yazdırdım.
                    ogrenciListe.DataSource = OgrenciBL.liste();     // Öğrenci eklendikten sonra listenin son halini ogrenciListe DataGridView ine listeletmek için BL katmanının OgrenciBL class ının liste() fonksiyonunu çağırdım.

                }

                else         //Eğer numara kayıtlı değil ise true değeri döndü ise
                {
                    MessageBox.Show("Girilen okul numarasına ait farklı bir öğrenci mevcut, lütfen girilen okul numarasını değiştiriniz!");      //Ekrana 'Girilen okul numarasına ait farklı bir öğrenci mevcut, lütfen girilen okul numarasını değiştiriniz!' mesajını yazdırdım.
                }

                
                txtAd.Text = "";                 // Ekleme işlemi bittikten sonra txtAd textboxı temizledim.
                txtSoyad.Text = "";              // Ekleme işlemi bittikten sonra txtSoyad textboxı temizledim.
                txtNo.Text = "";                 // Ekleme işlemi bittikten sonra txtNo textboxı temizledim.
                txtSifre.Text = "";              // Ekleme işlemi bittikten sonra txtSifre textboxı temizledim.
                comboBoxCinsiyet.Text = null;    // Ekleme işlemi bittikten sonra comboBoxCinsiyet comboboxunu temizledim.

            }

            else       //Eğer txt_gAd, txtSoyad, txtNo, txtSifre textbox ları ve comboBoxCinsiyet combobox u boş ise
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz");        //Ekrana 'Lütfen gerekli alanları doldurunuz' mesajını yazdırdım.
            }

        }

        private void btnSil_Click(object sender, EventArgs e)     //btnSil butonuna tıklandığında öğrenci silme işlemini gerçekleştirdim.
        {
            
            if (txt_IdSil.Text != "")       //txt_IdSil textinin içi boş değil ise
            {
                //Entity katmanındaki OgrenciId değişkenine textboxtaki veriyi aktardık
                OgrenciVeri ogrenci = new OgrenciVeri()     //Entity katmanındaki OgrenciVeri class ından ogrenci nesnesini oluşturdum.
                {
                    OgrenciId = int.Parse(txt_IdSil.Text)   //ogrenci nesnesinin ogrenciId değişkenine txt_IdSil TextBox ının metnini Set metodu ile atadım.
                };

                //Girilen id ye ait ogrenci kontrol edildi
                if (OgrenciBL.ogrenciSorgu_BL(ogrenci) == true)     // BL katmanının OgrenciBL classının ogrenciSorgu_BL() fonksiyonunu ogrenci nesnesi ile çağırdım ve öğrencinin veritabanında kayıtlı olup olmadığını kontrol ettirdim.
                                                                    // Eğer fonksiyondan true dönerse yani öğrenci varsa
                {
                    OgrenciBL.ogrenciSil(ogrenci);  // BL katmanının OgrenciBL classının ogrenciSil() fonksiyonunu ogrenci nesnesi ile çağırdım ve ogrenciyi veritabanından sildim.
                    MessageBox.Show("Silindi");      //Ekrana 'Silindi' mesajını yazdırdım.
                    ogrenciListe.DataSource = OgrenciBL.liste(); // Öğrenci silindikten sonra listenin son halini ogrenciListe DataGridView ine listeletmek için BL katmanının OgrenciBL class ının liste() fonksiyonunu çağırdım.
                    txt_IdSil.Text = "";        // Silme işleminden txt_IdSil textboxunun içini temizledim.
                }

                else      // Eğer fonksiyondan false dönerse yani öğrenci yoksa
                    MessageBox.Show("Geçersiz Id !");      //Ekrana 'Geçersiz Id !' mesajını yazdırdım.

            }
            else             //txt_IdSil textinin içi boş ise
                MessageBox.Show("Gerekli alanları doldurunuz!");        //Ekrana 'Gerekli alanları doldurunuz!' mesajını yazdırdım.
        }

        private void btnGuncelle_Click(object sender, EventArgs e)   //btnGuncelle butonuna tıklandığında öğrenci bilgisi güncelleme işlemini gerçekleştirdim.   
        {
            
            if (txt_gAd.Text != "" && txt_gSoyad.Text != "" && txt_gNo.Text != "" && txt_gSifre.Text != "" && comboBox_gCinsiyet.Text != "")   //Eğer txt_gAd, txt_gSoyad, txt_gNo, txt_gSifre textbox ları ve comboBox_gCinsiyet combobox u boş değil ise
            {

                OgrenciVeri ogrenci = new OgrenciVeri()      //Entity katmanındaki OgrenciVeri class ından ogrenci nesnesini oluşturdum.
                {
                    OgrenciAd = txt_gAd.Text,             //ogrenci nesnesinin ogrenciAd değişkenine txt_gAd TextBox ının metnini Set metodu ile atadım.
                    OgrenciSoyad = txt_gSoyad.Text,       //ogrenci nesnesinin ogrenciSoyad değişkenine txt_gSoyad TextBox ının metnini Set metodu ile atadım.
                    OgrenciNo = txt_gNo.Text,             //ogrenci nesnesinin ogrenciNo değişkenine txt_gNo TextBox ının metnini Set metodu ile atadım.
                    OgrenciSifre = txt_gSifre.Text,       //ogrenci nesnesinin ogrenciSifre değişkenine txt_gNo TextBox ının metnini Set metodu ile atadım.
                    OgrenciCinsiyet = comboBox_gCinsiyet.Text,  //ogrenci nesnesinin ogrenciCinsiyet değişkenine comboBox_gCinsiyet combobox ının metnini Set metodu ile atadım.
                    OgrenciId = id              //ogrenci nesnesinin OgrenciId değişkenine global id değişkenini atadım.
                };

                
                if (OgrenciBL.ogrenciSorgu_BL(ogrenci) == true)  // BL katmanının OgrenciBL classının ogrenciSorgu_BL() fonksiyonunu ogrenci nesnesi ile çağırdım ve öğrencinin veritabanında kayıtlı olup olmadığını kontrol ettirdim.
                                                                 // Eğer fonksiyondan true dönerse yani öğrenci varsa
                {
                    if (OgrenciBL.ogrenciOkulNoKOntrol(ogrenci) == true || ilkNo == ogrenci.OgrenciNo.ToString())  // BL katmanının OgrenciBL classının ogrenciOkulNoKOntrol() fonksiyonuna 
                        //ogrenci nesnesini parametre göndererek çağırdım ve okul numarasının daha önce kayıtlı olup olmadığını kontrol ettim. Eğer numara kayıtlı değil ise yani true döndü ise ve 
                        //global ilkNo değişkeni ogrenci nesnesinin ogrenciNo değişkenine eşit ise
                    {
                        OgrenciBL.ogrenciGuncelle(ogrenci); // BL katmanının OgrenciBL classının ogrenciGuncelle() fonksiyonunu ogrenci nesnesi ile çağırdım ve ogrenci nesnesinin değişkenşerine göre kaydı güncelledim..
                        MessageBox.Show("Guncellendi");        //Ekrana 'Guncellendi' mesajını yazdırdım.
                        ogrenciListe.DataSource = OgrenciBL.liste();// Öğrenci güncelledikten sonra listenin son halini ogrenciListe DataGridView ine listeletmek için BL katmanının OgrenciBL class ının liste() fonksiyonunu çağırdım.
                                                                   
                        txt_gAd.Text = "";          // Güncelleme işlemi bittikten sonra txt_gAd textboxı temizledim.
                        txt_gSoyad.Text = "";       // Güncelleme işlemi bittikten sonra txt_gSoyad textboxı temizledim.
                        txt_gNo.Text = "";            // Güncelleme işlemi bittikten sonra txt_gNo textboxı temizledim.
                        txt_gSifre.Text = "";        // Güncelleme işlemi bittikten sonra txt_gSifre textboxı temizledim.
                        comboBox_gCinsiyet.Text = "";      // Güncelleme işlemi bittikten sonra comboBoxCinsiyet comboboxunu temizledim.
                    }
                    else //Eğer numara kayıtlı ise yani false döndü ise ve 
                         //global ilkNo değişkeni ogrenci nesnesinin ogrenciNo değişkenine eşit değil ise
                    {
                        MessageBox.Show("Güncellemek istediğiniz okul numarasına ait öğrenci mevcut, lütfen girilen okul numarasını değiştiriniz!");   //Ekrana 'Güncellemek istediğiniz okul numarasına ait öğrenci mevcut, lütfen girilen okul numarasını değiştiriniz!' mesajını yazdırdım.
                    }

                }

                else   // Eğer fonksiyondan false dönerse yani öğrenci yoksa
                    MessageBox.Show("Lütfen listeden seçim yaptıktan sonra değerleri doldurunuz !");    //Ekrana 'Lütfen listeden seçim yaptıktan sonra değerleri doldurunuz !' mesajını yazdırdım.
            }

            else   //Eğer txt_gAd, txt_gSoyad, txt_gNo, txt_gSifre textbox ları ve comboBox_gCinsiyet combobox u boş ise
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz");            //Ekrana 'Lütfen gerekli alanları doldurunuz' mesajını yazdırdım.
            }

        }

        int id;         //integer tipinde id adında global değişken tanımladım.
        string ilkNo;   //string tipinde ilkNo adında global değişken tanımladım.

        private void ogrenciListe_SelectionChanged(object sender, EventArgs e)    //ogrenciListe datagridview inde alan seçildiğinde seçilen alanı güncelleme textboxlarına yazdırdım
        {
            
            id = int.Parse(ogrenciListe.CurrentRow.Cells[0].Value.ToString());    //ogrenciListe datagridview 1. sütununu integer türüne çevirip global id değişkenine atadım.
            txt_gAd.Text = ogrenciListe.CurrentRow.Cells[1].Value.ToString();     //ogrenciListe datagridview 2. sütununu txt_gAd textboxunun textine atadım.
            txt_gSoyad.Text = ogrenciListe.CurrentRow.Cells[2].Value.ToString();  //ogrenciListe datagridview 3. sütununu txt_gSoyad textboxunun textine atadım.
            txt_gNo.Text = ogrenciListe.CurrentRow.Cells[3].Value.ToString();     //ogrenciListe datagridview 4. sütununu txt_gNo textboxunun textine atadım.
            txt_gSifre.Text = ogrenciListe.CurrentRow.Cells[4].Value.ToString();  //ogrenciListe datagridview 5. sütununu txt_gSifre textboxunun textine atadım.
            comboBox_gCinsiyet.Text = ogrenciListe.CurrentRow.Cells[5].Value.ToString();    //ogrenciListe datagridview 6. sütununu txt_gAd textboxunun textine atadım.
            ilkNo = txt_gNo.Text;     //txt_gNo textboxunun textini global ilkNo değişkenine atadım.
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)  //txtNo texboxına harf girişini engelledim.
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_IdSil_KeyPress(object sender, KeyPressEventArgs e)              //txt_IdSil texboxına harf girişini engelledim.
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_gNo_KeyPress(object sender, KeyPressEventArgs e)     //txt_gNo texboxına harf girişini engelledim.
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)      //Sol üst köşedeki geri butonuna tıklandığında OgrenciIslemForm unu kapattırıp bir önceki sayfa olan GorevliGecisForm unu açtırdım.
        {
            GorevliGecisForm gorevli = new GorevliGecisForm();  //GorevliGecisForm undan gorevli nesnesini oluşturdum.
            this.Hide();                                        //Butona tıklandıktan sonra KitapIslemForm formununu kapattırdım.  
            gorevli.Show();                                     //gorevli nesnesinden yeni form açtırdım.

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
