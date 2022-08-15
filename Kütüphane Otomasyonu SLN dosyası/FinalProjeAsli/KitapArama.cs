using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;        // BL katmanını kullanacağımız için ekledik.
using Entity;   // Entity katmanını kullanacağımız için ekledik.

namespace FinalProjeAsli
{
    public partial class KitapArama : Form
    {
        public KitapArama()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OgrenciForm ogrenci = new OgrenciForm();             //OgrenciForm undan ogrenci nesnesini oluşturdum.
            ogrenci.lblIdOgrenciForm.Text = lblOgrenciId.Text;   //OgrenciId yi açılacak ogrenci formunun lblOgrenciId label ine aktardım.
            this.Hide();                                         //Butona tıklandıktan sonra KitapArama formununu kapattırdım.
            ogrenci.Show();                                      //gorevli nesnesinden yeni form açtırdım.

        }

        private void KitapArama_Load(object sender, EventArgs e)
        {
            lblOgrenciId.Visible = false;                   //ogrenci formundan aldığım öğrencinin id dinin yazılı olduğu labeli gizledim.
            idKitapListe.DataSource = KitapBL.kitapListe(); // Form açıldıktan sonra kayıtlı kitapları idkitapListe DataGridView ine listeletmek için BL katmanının KitapBL class ının kitapListe() fonksiyonunu çağırdım.
            //idkitapListe DataGridView inde bazı alanları gizledim.
            idKitapListe.Columns[2].Visible = false;        
            idKitapListe.Columns[3].Visible = false;
            idKitapListe.Columns[4].Visible = false;

        }

        private void pictureBox3_Click(object sender, EventArgs e)         
        {
            System.Windows.Forms.Application.Exit();              // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.

        }

        private void btnGetir_Click(object sender, EventArgs e)        //btnGetir butonuna tıklandığında id si girilen kitabı kimlerin hangi tarihlerde aldığını gösterdim.
        {

            if (kitapId.Text != "")                                       //kitapId textbox ının içi boş değil ise
            {
                KitapVeri kitap = new KitapVeri()                         //Entity katmanındaki KitapVeri class ından kitap nesnesini oluşturdum.
                {
                    KitapId = int.Parse(kitapId.Text)                     //kitap nesnesinin kitapId değişkenine kitapId TextBox ının metnini Set metodu ile atadım.
                };

                kitap = KitapBL.kitapIdBilgi(kitap);                      //BL katmanının KitapBL class ının kitapIdBilgi() fonksiyonunu çağırdım ve dönen değeri kitap nesnesine atadım.
                kitapAd.Text = kitap.KitapAd;                             //kitapAd labeline kitap nesnesinin kitapAd değişkeninin değeri atandı.
                kitapTuru.Text = kitap.KitapTuru;                         //kitapTuru labeline kitap nesnesinin kitapTuru değişkeninin değeri atandı.
                kitapSayfa.Text = kitap.KitapSayfa;                       //kitapSayfa labeline kitap nesnesinin kitapSayfa değişkeninin değeri atandı.
                kitapYazar.Text = kitap.KitapYazar;                       //kitapYazar labeline kitap nesnesinin kitapYazar değişkeninin değeri atandı.

                KitapOgrenciVeri kitapogrenci = new KitapOgrenciVeri()     //Entity katmanındaki KitapOgrenciVeri class ından kitapogrenci nesnesini oluşturdum.
                {
                    KitapId = int.Parse(kitapId.Text)                      //kitapogrenci nesnesinin kitapId değişkenine kitapId TextBox ının metnini Set metodu ile atadım.
                };

                if (KitapBL.kitapSorgu_BL(kitap) != false)                 //eğer kitapSorgu_BL() fonksiyonundan dönen değer true ise yani kitapogrenci nesnesinin kitapId değeri ile tabloda eşleşen kayıt var ise
                {
                    kitapAlimTeslimListe.DataSource = KitapIadeBL.kitapOgrenciListe(kitapogrenci);   // kitapAlimTeslimListe datagridview ine BL katmanından KitapIadeBL sınıfının kitapOgrenciListe() fonksiyonundan dönen değeri atadım.
                    //datagridview inin sütun başlıklarını düzenledim.
                    kitapAlimTeslimListe.Columns[1].HeaderText = "Ad";
                    kitapAlimTeslimListe.Columns[2].HeaderText = "Soyad";
                    kitapAlimTeslimListe.Columns[6].HeaderText = "Teslim Edilmiş mi?";
                }

                else            //eğer kitapSorgu_BL() fonksiyonundan dönen değer false ise yani kitapogrenci nesnesinin kitapId değeri ile tabloda eşleşen kayıt yok ise
                    MessageBox.Show("Girilen id'ye ait kitap mevcut değil !");        //Ekrana 'Girilen id'ye ait kitap mevcut değil !' mesajını yazdırdım.
            }

            else                                                       //kitapId textbox ının içi boş ise
                MessageBox.Show("Lütfen kitap id giriniz");            //Ekrana 'Lütfen kitap id giriniz' mesajını yazdırdım.
        }

        private void kitapId_KeyPress(object sender, KeyPressEventArgs e)        //kitapId textboxuna harf girişini engelledim.
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
