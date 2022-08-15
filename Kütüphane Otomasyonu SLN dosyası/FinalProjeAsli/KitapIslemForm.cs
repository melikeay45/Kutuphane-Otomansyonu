using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;           // BL katmanını kullanmak için ekledim.
using Entity;       // Entity katmanını kullanmak için ekledim.

namespace FinalProjeAsli
{
    public partial class KitapIslemForm : Form
    {
        public KitapIslemForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)   //Sol üst köşedeki geri butonuna tıklandığında KitapIslemForm unu kapattırıp bir önceki sayfa olan GorevliGecisForm unu açtırdım.
        {
            GorevliGecisForm gorevli = new GorevliGecisForm();   //GorevliGecisForm undan gorevli nesnesini oluşturdum.
            this.Hide();                                         //Butona tıklandıktan sonra KitapIslemForm formununu kapattırdım.  
            gorevli.Show();                                      //gorevli nesnesinden yeni form açtırdım.

        }

        private void pictureBox3_Click(object sender, EventArgs e)   //pictureBox3 tıklandığında gerçekleşecek işlemleri yazdım.
        {

            System.Windows.Forms.Application.Exit();            // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.
        }

        private void btnEkle_Click(object sender, EventArgs e)     //btnEkle butonuna tıklandığında textxboxlardaki değerler ile yeni kitap eklendi.
        {

            if (txtAd.Text != "" && comboBoxTur.Text != "" && txtSayfa.Text != "" && txtYazar.Text != "")  //Eğer txtAd, comboBoxTur, txtSayfa, txtYazar textbox ları boş değil ise
            {

                KitapVeri kitap = new KitapVeri()   //Entity katmanındaki KitapVeri class ından kitap nesnesini oluşturdum.
                {
                    KitapAd = txtAd.Text,           //kitap nesnesinin KitapAd değişkenine txtAd TextBox ının metnini Set metodu ile atadım.
                    KitapTuru = comboBoxTur.Text,   //kitap nesnesinin KitapTuru değişkenine comboBoxTur combobox ının metnini Set metodu ile atadım.
                    KitapSayfa = txtSayfa.Text,     //kitap nesnesinin KitapSayfa değişkenine txtSayfa TextBox ının metnini Set metodu ile atadım.
                    KitapYazar = txtYazar.Text      //kitap nesnesinin KitapYazar değişkenine txtYazar TextBox ının metnini Set metodu ile atadım.
                };

                KitapBL.kitapEkle(kitap);           //BL katmanının KitapBl class ının kitapEkle() fonksiyonuna kitap nesnesini parametre olarak gönderip kitabı veritabanında kitap tablosuna kaydettirdim.
                MessageBox.Show("Eklendi");         //Ekrana 'Eklendi' mesajını yazdırdım.
                kitapListe.DataSource = KitapBL.kitapListe();  // Kitabı ekledikten sonra listenin son halini kitapListe DataGridView ine listeletmek için BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.


                txtAd.Text = "";                // Kitap eklendikten sonra txtAd textboxunun metnini temizledim.
                comboBoxTur.Text = null;        // Kitap eklendikten sonra comboBoxTur comboboxunun metnini temizledim.
                txtSayfa.Text = "";             // Kitap eklendikten sonra txtSayfa textboxunun metnini temizledim.
                txtYazar.Text = "";             // Kitap eklendikten sonra txtYazar textboxunun metnini temizledim.

            }

            else                 //Eğer txtAd, comboBoxTur, txtSayfa, txtYazar textbox ları boş ise
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz");      //Ekrana 'Lütfen gerekli alanları doldurunuz' mesajını yazdırdım.
            }
        }

        private void KitapIslemForm_Load(object sender, EventArgs e)   //KitapIslemForm u açılır açılmaz yapılması gereken işlemleri yazdım.
        {
            kitapListe.DataSource = KitapBL.kitapListe(); // Form açıldıktan sonra kayıtlı kitapları kitapListe DataGridView ine listeletmek için BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.
            lblBilgi.ForeColor = Color.Yellow;            // Form açıldıktan sonra kitapListe DataGridViewinde kitap bilgi listesi açık olduğu için lblBilgi labelinin rengini sarı yaptım.
            // Form açıldığında kitap gilgilerini güncellemek için kullanılan textboxların ve comboboxun textlerini temizledim.
            txt_gAd.Text = "";         // Form açıldığında guncelleme kısmındaki txt_gAd textboxı temizledim.
            comboBox_gTur.Text = null;  // Form açıldığında guncelleme kısmındaki comboBox_gTur combobox ını temizledim.
            txt_gSayfa.Text = "";      // Form açıldığında guncelleme kısmındaki txt_gSayfa textboxı temizledim.
            txt_gYazar.Text = "";      // Form açıldığında guncelleme kısmındaki txt_gYazar textboxı temizledim.
            id = 0;                   // Form açıldığında global id nin değerini 0 yaptım.
        }
        int id;  //Global integer tipinde id adında değişken tanımladım.

        private void kitapListe_SelectionChanged(object sender, EventArgs e)   // kitapListe DataGridViewinde satır seçildiğinde
        {
            //Tablo üzerinde tıklanan satırın verilerini guncelleme alanındaki textboxlara yazdırdık
            id = int.Parse(kitapListe.CurrentRow.Cells[0].Value.ToString());        //kitapListe DataGridViewinde seçilen satırın 0. hücresini integer veri tipine çevirip global id değişkenine atadım.
            txt_gAd.Text = kitapListe.CurrentRow.Cells[1].Value.ToString();         //kitapListe DataGridViewinde seçilen satırın 1. hücresini txt_gAd textboxının textine atadım.
            comboBox_gTur.Text = kitapListe.CurrentRow.Cells[2].Value.ToString();   //kitapListe DataGridViewinde seçilen satırın 2. hücresini comboBox_gTur comboboxının textine atadım.
            txt_gSayfa.Text = kitapListe.CurrentRow.Cells[3].Value.ToString();      //kitapListe DataGridViewinde seçilen satırın 3. hücresini txt_gSayfa textboxunun textine atadım.
            txt_gYazar.Text = kitapListe.CurrentRow.Cells[4].Value.ToString();      //kitapListe DataGridViewinde seçilen satırın 4. hücresini txt_gYazar textboxunun textine atadım.

        }

        private void btnGuncelle_Click(object sender, EventArgs e)      //btnGuncelle butonuna tıklandığında gerçekleşecek işlemleri yazdım.
        {
           
            if (txt_gAd.Text != "" && comboBox_gTur.Text != "" && txt_gSayfa.Text != "" && txt_gYazar.Text != "")           //Eğer txt_gAd, comboBox_gTur, txt_gSayfa, txt_gYazar textbox ları boş değil ise
            {
                KitapVeri kitap = new KitapVeri()           //Entity katmanındaki KitapVeri class ından kitap nesnesini oluşturdum.
                {
                    KitapAd = txt_gAd.Text,              //kitap nesnesinin kitapAd değişkenine txt_gAd TextBox ının metnini Set metodu ile atadım.
                    KitapTuru = comboBox_gTur.Text,      //kitap nesnesinin kitapTuru değişkenine comboBox_gTur combobox ının metnini Set metodu ile atadım.
                    KitapSayfa = txt_gSayfa.Text,        //kitap nesnesinin kitapSayfa değişkenine txt_gSayfa TextBox ının metnini Set metodu ile atadım.
                    KitapYazar = txt_gYazar.Text,        //kitap nesnesinin kitapYazar değişkenine txt_gYazar TextBox ının metnini Set metodu ile atadım.
                    KitapId = id                         //kitap nesnesinin kitapId değişkenine global id değişkeninin değerini atadım. Global id değişkenine kitapListe DataGridViewinde seçim yaptıktan sonra seçilen satırın id si atanmıştı.
                };

                //BL katmanının KitapBl class ının kitapSorgu_BL() fonksiyonuna kitap nesnesini parametre olarak gönderip bu kitabın veritabanında var olup olmadığını kontrol ettirdim.
                
                if (KitapBL.kitapSorgu_BL(kitap) == true)       //eğer kitapSorgu_BL() fonksşiyonundan dönen değer true ise yani kitap nesnesinin KitapId değeri ile tabloda eşleşen kayıt var ise
                {
                    KitapBL.kitapGuncelle(kitap);         //BL katmanının KitapBl class ının kitapGuncelle() fonksiyonuna kitap nesnesini parametre olarak gönderip kitabın bilgilerini güncelledim.
                    MessageBox.Show("Guncellendi");       //Ekrana 'Guncellendi' mesajını yazdırdım.
                    kitapListe.DataSource = KitapBL.kitapListe();   // Kitabı güncelledikten sonra listenin son halini kitapListe DataGridView ine listeletmek için BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.
                    // Güncelleme bittiğinde güncellemek için kullanılan textboxların ve comboboxun textlerini temizledim.
                    txt_gAd.Text = "";           // Güncelleme bittiğinde guncelleme kısmındaki txt_gAd textboxı temizledim.
                    comboBox_gTur.Text = null;   //Güncelleme bittiğinde guncelleme kısmındaki comboBox_gTur combobox ını temizledim.
                    txt_gSayfa.Text = "";        // Güncelleme bittiğinde guncelleme kısmındaki txt_gAd txt_gSayfa temizledim.
                    txt_gYazar.Text = "";        // Güncelleme bittiğinde guncelleme kısmındaki txt_gAd txt_gYazar temizledim.
                    id = 0;                      // Güncelleme bittiğinde global id nin değerini 0 yaptım.
                }

                else         //eğer kitapSorgu_BL() fonksşiyonundan dönen değer false ise yani kitap nesnesinin KitapId değeri ile tabloda eşleşen kayıt yok ise
                    MessageBox.Show("Lütfen listeden seçim yaptıktan sonra değerleri doldurunuz !");      //Ekrana 'Lütfen listeden seçim yaptıktan sonra değerleri doldurunuz !' mesajını yazdırdım.
            }

            else       //Eğer txt_gAd, comboBox_gTur, txt_gSayfa, txt_gYazar textbox ları boş ise
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz");           //Ekrana 'Lütfen gerekli alanları doldurunuz' mesajını yazdırdım.
            }
        }

        private void txt_gSayfa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))   //Sayfa sayısı girilen textboxa harf girilmesini engelledim.
            {
                e.Handled = true;
            }
        }

        private void txt_IdSil_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))    //Silinecek kitabın idsinin girildiği textboxa harf girilmesini engelledim.
            {
                e.Handled = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)  //btnSil butonuna tıkladığında gerçekleşecek işlemleri yazdım.
        {

            if (txt_IdSil.Text != "")     // txt_IdSil texti boş değil ise
            {

                KitapVeri kitap = new KitapVeri()       //Entity katmanındaki KitapVeri class ından kitap nesnesini oluşturdum.
                {
                    KitapId = int.Parse(txt_IdSil.Text)   //kitap nesnesinin KitapId değişkenine txt_IdSil textboxının textini Set metodu ileatadım.
                };

                //BL katmanının KitapBl class ının kitapSorgu_BL() fonksiyonuna kitap nesnesini parametre olarak gönderip bu kitabın veritabanında var olup olmadığını kontrol ettirdim.
               
                if (KitapBL.kitapSorgu_BL(kitap) == true)  //eğer kitapSorgu_BL() fonksşiyonundan dönen değer true ise yani kitap nesnesinin KitapId değeri ile tabloda eşleşen kayıt var ise
                {
                    KitapBL.kitapSil(kitap);      //BL katmanının KitapBl class ının kitapSil() fonksiyonuna kitap nesnesini parametre olarak gönderip KitapId si eşleşen kaydı sildirdim.
                   
                    MessageBox.Show("Silindi");   //Ekrana 'Silindi' mesajını yazdırdım.

                    kitapListe.DataSource = KitapBL.kitapListe();   // Kitabı sildikten sonra listenin son halini kitapListe DataGridView ine listeletmek için BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.

                    txt_IdSil.Text = "";        // Silme işlemi bittiğinde silemk için kullanılan textboxın textini temizledim.
                }

                else  //eğer kitapSorgu_BL() fonksşiyonundan dönen değer true değil ise yani kitap nesnesinin KitapId değeri ile tabloda eşleşen kayıt yok ise
                    MessageBox.Show("Geçersiz Id !");   //Ekrana 'Geçersiz Id !!' mesajını yazdırdım.

            }
            else     // txt_IdSil texti boş ise
                MessageBox.Show("Gerekli alanları doldurunuz!");    //Ekrana 'Gerekli alanları doldurunuz!' mesajını yazdırdım.
        }

        private void pictureBoxKitapBilgi_Click(object sender, EventArgs e)   //pictureBoxIadeBilgi picturebox ına tıklandığında gerçekleşecek işlemleri yazdım.
        {

            lblListe.Text = "KİTAP BİLGİ LİSTESİ";   // lblListe labelinin metnini 'KİTAP BİLGİ LİSTESİ' yaptım.
            lblBilgi.ForeColor = Color.Yellow;       //pictureBoxIadeBilgi picturebox ına tıklandığında sonra kitapListe DataGridViewinde kitap bilgi listesi açık olduğu için lblBilgi labelinin 
            //rengini sarı yaptım.
            lblIade.ForeColor = Color.White;         // lblIade labelnin rengini beyaz yaptım.
            lblBilgilendirme.Text = "Not: İade bilgisini öğrenmek istediğiniz kitabın listeden üzerine tıklayıp iade bilgisi butonuna basınız.";   //lblBilgilendirme labeline 'Not: İade bilgisini 
            //öğrenmek istediğiniz kitabın listeden üzerine tıklayıp iade bilgisi butonuna basınız.' yazdırdım.
            kitapListe.DataSource = KitapBL.kitapListe(); // pictureBoxIadeBilgi picturebox ına tıklandıktan sonra kitap bilgi listesini kitapListe DataGridView ine listeletmek için 
            //BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.

        }

        private void pictureBoxIadeBilgi_Click(object sender, EventArgs e)    //pictureBoxIadeBilgi picturebox ına tıklandığında gerçekleşecek işlemleri yazdım.
        {

            lblListe.Text = "İADE BİLGİ LİSTESİ";     // lblListe labelinin metnini 'İADE BİLGİ LİSTESİ' yaptım.
            lblIade.ForeColor = Color.Yellow;         //pictureBoxIadeBilgi picturebox ına tıklandığında sonra kitapListe DataGridViewinde iade bilgi listesi açık olduğu için lblIade labelinin 
            //rengini sarı yaptım.
            lblBilgi.ForeColor = Color.White;       // lblBilgi labelnin rengini beyaz yaptım.
            KitapOgrenciVeri kitap = new KitapOgrenciVeri()    //Entity katmanındaki KitapOgrenciVeri class ından kitap nesnesini oluşturdum.
            {
                KitapId = id                                   //Global id değerini kitap nesnesinin KitapId değişkenine Set metodu ile atadım.
            };
            lblBilgilendirme.Text = "Not: Kitap bilgi listesine geri dönmek için kitap bilgisi butonuna basınız.";  //lblBilgilendirme labeline ' Not: Kitap bilgi listesine geri dönmek için kitap 
            //bilgisi butonuna basınız.' yazdırdım.
            kitapListe.DataSource = KitapIadeBL.kitapOgrenciListe(kitap);  // pictureBoxIadeBilgi picturebox ına tıklandıktan sonra kitapOgrenciListe() fonksiyonundan dönen değeri DataGridView ine 
                                                                           //listeletmek için BL katmanının KitapIadeBL class ının kitapOgrenciListe() fonksiyonunu çağırdım.
            // iade bilgisi listeleme işlemi bittikten sonra kullanılan textboxların ve comboboxun textlerini temizledim.
            txt_gAd.Text = ""; 
            comboBox_gTur.Text = null;
            txt_gSayfa.Text = "";
            txt_gYazar.Text = "";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
