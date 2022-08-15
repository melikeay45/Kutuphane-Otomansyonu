using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;                    // BL katmanını kullanmak için ekledim.
using Entity;                // Entity katmanını kullanmak için ekledim.

namespace FinalProjeAsli
{
    public partial class OgrenciForm : Form
    {
        public OgrenciForm()
        {
            InitializeComponent();
        }

        private void OgrenciForm_Load(object sender, EventArgs e)           //OgrenciForm u açılır açılmaz yapılması gereken işlemleri yazdım.
        {

            OgrBilgiListesi();                           // OgrenciForm unda yazdığım OgrBilgiListesi() fonksiyonunu çağırdım.

            AlinanKitapVeri alinanKitapVeri = new AlinanKitapVeri()      //Entity katmanındaki AlinanKitapVeri class ından alinanKitapVeri nesnesini oluşturdum.
            {
                OgrenciId = int.Parse(lblIdOgrenciForm.Text)             //lblIdOgrenciForm TextBox ının metnini integere çevirip alinanKitapVeri nesnesinin ogrenciId değişkenine Set metodu ile atadım.
            };
            kitapAlimTeslimListe.DataSource = KitapIadeBL.ogrenciIdListe(alinanKitapVeri);   // BL katmanının KitapIadeBL classının ogrenciIdListe() fonksiyonunun döndürdüğü değeri kitapAlimTeslimListe datagridview inde listeledim.
                                                                                             //id si girilen öğrencinin aldığı kitapları listeler.

            kitapAlimTeslimListe.Columns[0].Visible = false;                                 //kitapAlimTeslimListe datagridview inde alan gizledim.
            kitapAlimTeslimListe.Columns[1].HeaderText = "Kitap Adı";                        //ogrenciListe datagridview inin 1. sütununun başlığını Kitap Adı yaptım.
            kitapAlimTeslimListe.Columns[2].HeaderText = "Alınma Tarihi";                    //ogrenciListe datagridview inin 2. sütununun başlığını Alınma Tarihi yaptım.
            kitapAlimTeslimListe.Columns[3].HeaderText = "Teslim Tarihi";                    //ogrenciListe datagridview inin 3. sütununun başlığını Teslim Tarihi yaptım.
            kitapAlimTeslimListe.Columns[4].HeaderText = "Teslim Edilmiş mi ?";              //ogrenciListe datagridview inin 4. sütununun başlığını Teslim Edilmiş mi ? yaptım.

            KitapIadeVeri iade = new KitapIadeVeri()                          //Entity katmanındaki KitapIadeVeri class ından iade nesnesini oluşturdum.
            {
                OgrenciId = int.Parse(lblIdOgrenciForm.Text)                  //lblIdOgrenciForm TextBox ının metnini intigere çevirip iade nesnesinin ogrenciId değişkenine Set metodu ile atadım.
            };
            comboBoxAlinan.DataSource = KitapIadeBL.kitapAlinanLİste(iade);        // BL katmanının KitapIadeBL classının kitapAlinanLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani alınabilecek kitapları comboBoxAlinan combobaxına aktardım
            comboBoxTeslim.DataSource = KitapIadeBL.kitapTeslimLİste(iade);        // BL katmanının KitapIadeBL classının kitapTeslimLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani teslim edilebilecek kitapları comboBoxTeslim combobaxına aktardım
            listeRenklendirme();              // OgrenciFor munda yazdığım listeRenklendirme() fonksiyonunu çağırdım.

        }
        public void OgrBilgiListesi()          //id sini aktardığım ogrencinin bilgilerini laellere aktaran fonksiyon yazdım.
        {
            OgrenciVeri ogrenci = new OgrenciVeri()            //Entity katmanındaki OgrenciVeri class ından ogrenci nesnesini oluşturdum.
            {
                OgrenciId = int.Parse(lblIdOgrenciForm.Text)           //lblIdOgrenciForm TextBox ının metnini integere çevirip ogrenci nesnesinin ogrenciId değişkenine Set metodu ile atadım.
            };

            ogrenci = OgrenciBL.ogrenciIdBilgi(ogrenci);     // BL katmanının OgrenciBL classının ogrenciIdBilgi() fonksiyonunun döndürdüğü değeri OgrenciVeri class ından oluşturduğum ogrenci nesnesine atadım.
            lblOgrenci.Text = "Hoşgeldin  " + ogrenci.OgrenciAd;       //lblOgrenci labelinin textine "Hoşgeldin  " ve ogrenci nesnesinin ogrenciAd değişkeninin değerini yazdırdım.
            lblAd.Text = ogrenci.OgrenciAd;                            //lblAd labelinin textine ogrenci nesnesinin ogrenciAd değişkeninin değerini yazdırdım.
            lblSoyad.Text = ogrenci.OgrenciSoyad;                      //lblSoyad labelinin textine ogrenci nesnesinin ogrenciSoyad değişkeninin değerini yazddırdım.
            lblNo.Text = ogrenci.OgrenciNo;                            //lblNo labelinin textine ogrenci nesnesinin ogrenciNo değişkeninin değerini yazdırdım.
            lblSifre.Text = ogrenci.OgrenciSifre;                      //lblSifre labelinin textine ogrenci nesnesinin ogrenciNo değişkeninin değerini yazdırdım.
            lblCinsiyet.Text = ogrenci.OgrenciCinsiyet;                //lblCinsiyet labelinin textine ogrenci nesnesinin ogrenciCinsiyet değişkeninin değerini yazdırdım.
            lblCeza.Text = ogrenci.OgrenciCeza.ToString();             //lblCeza labelinin textine ogrenci nesnesinin ogrenciCeza değişkeninin değerini yazdırdım.
        }
        public void listeRenklendirme()          // OgrenciForm unda yazdığım OgrBilgiListesi() fonksiyonunu çağırdım.
        {
            for (int i = 0; i < kitapAlimTeslimListe.Rows.Count; i++)  //kitapAlimTeslimListe datagridview inin satır sayısı kadar dönecek for döngüsü yazdım.
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();        //DataGridViewCellStyle class ından renk nesnesini oluşturdum.

                if (Convert.ToBoolean(kitapAlimTeslimListe.Rows[i].Cells[4].Value) == true)        //kitapAlimTeslimListe datagridview inin 4. sütunun yani kitap teslim etme durumunu kontrol etti. Eğer true ise yani kitap teslim edilmiş ise
                {
                    renk.BackColor = Color.Green;    //satırın arka rengine yeşil rengini atadım.
                    renk.ForeColor = Color.White;    //satırdaki yazı rengine beyaz rengini atadım.
                }

                else            // eğer kitap teslim edilmemişse
                {
                    //Teslim edilmeyen kitapların teslim tarihine göre satır renklendirmesini yaptım
                    TimeSpan sonuc = DateTime.Now - Convert.ToDateTime(kitapAlimTeslimListe.Rows[i].Cells[2].Value);    //timespan classından sonuc nesnesi oluşturdum. Bugünün tarihinden kitabın alındığı tarihi çıkardım ve sonuc değişkenine atadım.
                 
                    
                    if (sonuc.TotalDays > 15)   // Kitap alınma tarihinden 15 gün geçmiş ise 
                    {
                        renk.BackColor = Color.Red;    //satırın arka rengine kırmızı rengini atadım.
                    }

                    
                    if (sonuc.TotalDays >= 13 && sonuc.TotalDays <= 15)     // Kitap alınma tarihinden 13 gün geçmiş ise ve 15 gün olmamış ise 
                    {
                        renk.BackColor = Color.Yellow;       //satırın arka rengine sarı rengini atadım.
                    }
                }
                kitapAlimTeslimListe.Rows[i].DefaultCellStyle = renk;   //satırın renklendirme işlemini gerçekleştirdim.

            }
        }

        private void button2_Click(object sender, EventArgs e)     //Sol üst köşedeki geri butonuna tıklandığında OgrenciForm unu kapattırıp bir önceki sayfa olan OgrenciGirisForm unu açtırdım.
        {
            OgrenciGirisForm ogrenci = new OgrenciGirisForm();     //OgrenciGirisForm undan ogrenci nesnesini oluşturdum.
            this.Hide();                                           //Butona tıklandıktan sonra OgrenciGirisForm formununu kapattırdım.  
            ogrenci.Show();                                        //ogrenci nesnesinden yeni form açtırdım.

        }

        private void pictureBox3_Click(object sender, EventArgs e)   //pictureBox3 e tıklandığında gerçekleşecek işlemleri yazdım.
        {
            System.Windows.Forms.Application.Exit();                // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.

        }

        private void btnAl_Click(object sender, EventArgs e)    //btnAl butonuna tıklandığında kitap ödünç verilir kitapAlimTeslimListesine ekledim.
        {
            if (comboBoxAlinan.Text != "")             //comboBoxAlinan combobox un texti boş değil ise
            {
                TimeSpan gecenSure = DateTime.Now - dateTimePickerAlim.Value.Date;  //TimeSpan classından gecensure nesnesi oluşturdum.Bu günün terihinden dateTimePickerAlim da seçilen tarihi çıkardım.
                if (gecenSure.TotalDays >= 0)  // eğer bu günün tarihinden daha ileri bir tarih değilse
                {

                    KitapOgrenciVeri kitapId = new KitapOgrenciVeri()            //Entity katmanındaki KitapOgrenciVeri class ından kitapId nesnesini oluşturdum.
                    {
                        KitapAd = comboBoxAlinan.Text                             //kitapId nesnesinin kitapAd değişkenine comboBoxAlinan comboboxunun texti atandım
                    };


                    KitapIadeVeri kitap = new KitapIadeVeri()               //Entity katmanındaki KitapIadeVeri class ından kitap nesnesini oluşturdum.
                    {
                        KitapId = KitapIadeBL.kitapId(kitapId),          // BL katmanının KitapIadeBL classının kitapId() fonksiyonunun döndürdüğü değeri KitapIadeVeri class ından oluşturduğum kitap nesnesinin kitapId değişkenine atadım.
                        OgrenciId = int.Parse(lblIdOgrenciForm.Text),    //Kitap nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin textini atadım.
                        KitapAlinma = dateTimePickerAlim.Value.Date      //Kitap nesnesinin kitapAlinma değişkenine dateTimePickerAlim değerini atadım.
                    };

                    KitapIadeBL.kitapAlimIslemi(kitap);    //BL katmanının KitapIadeBL classının   kitapAlimIslemi() fonksiyonuna kitap nesnesini gönderip kitabın veritabanında ödünç alma işlemini gerçekleştirdim.


                    AlinanKitapVeri alinanKitapVeri = new AlinanKitapVeri()     //Entity katmanındaki AlinanKitapVeri class ından alinanKitapVeri nesnesini oluşturdum.
                    {
                        OgrenciId = int.Parse(lblIdOgrenciForm.Text)         //alinanKitapVeri nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin değerini atadım.
                    };
                    kitapAlimTeslimListe.DataSource = KitapIadeBL.ogrenciIdListe(alinanKitapVeri);  // Kitabı ödünç verdikten sonra listenin son halini kitapAlimTeslimListe DataGridView ine listeletmek için BL katmanının KitapIadeBL class ının ogrenciIdListe() fonksiyonunu çağırdım.
                    listeRenklendirme();    //listeRenklendirme() fonksiyonunu ile satıraları renklendirdim.

                    //güncel kitaplar oluşturuldu
                    KitapIadeVeri iade = new KitapIadeVeri()       //Entity katmanındaki KitapIadeVeri class ından iade nesnesini oluşturdum.
                    {
                        OgrenciId = int.Parse(lblIdOgrenciForm.Text)      //lblIdOgrenciForm TextBox ının metnini integere çevirip iade nesnesinin ogrenciId değişkenine Set metodu ile atadım.
                    };
                    comboBoxAlinan.DataSource = KitapIadeBL.kitapAlinanLİste(iade);       // BL katmanının KitapIadeBL classının kitapAlinanLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani alınabilecek kitapları comboBoxAlinan combobaxına aktardım
                    comboBoxTeslim.DataSource = KitapIadeBL.kitapTeslimLİste(iade);       // BL katmanının KitapIadeBL classının kitapTeslimLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani teslim edilebilecek kitapları comboBoxTeslim combobaxına aktardım

                    MessageBox.Show("Kitap alındı.");         //Ekrana 'Kitap alındı.' mesajını yazdırdım.
                }
                else            // eğer bu günün tarihinden daha ileri bir tarih ise
                {
                    MessageBox.Show("Alım tarihi bugünden ileri bir tarih olamaz !");    //Ekrana 'Alım tarihi bugünden ileri bir tarih olamaz !' mesajını yazdırdım.
                }
            }
            else         //comboBoxAlinan combobox un texti boş ise
            {
                MessageBox.Show("Alınabilir kitap mevcut değil.");          //Ekrana 'Alınabilir kitap mevcut değil.' mesajını yazdırdım.
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)    //pictureBox1 e tıklandığında gerçekleşecek işlemleri yazdım.
        {
            KitapArama ogrenci = new KitapArama();                         //KitapArama formundan ogrenci nesnesini oluşturdum.
            ogrenci.lblOgrenciId.Text = lblIdOgrenciForm.Text;             //lblIdOgrenciForm labelinin textini açılacak ogrenci formunun lblOgrenciId label ine aktardım.
            this.Hide();                           //Butona tıklandıktan sonra OgrenciForm unu formununu kapattırdım.
            ogrenci.Show();                       //ogrenci nesnesinden yeni form açtırdım.

        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (txtOdeme.Text != "")         // txtOdeme textboxunun texti dolu ise
            {
                KitapIadeVeri ogrenciId = new KitapIadeVeri()    //Entity katmanındaki KitapIadeVeri class ından ogrenciId nesnesini oluşturdum.
                {
                    OgrenciId = int.Parse(lblIdOgrenciForm.Text)  //ogrenciId nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin textini atadım.
                };
                KitapIadeBL.ogrenciCeza(ogrenciId);      // BL katmanının KitapIadeBL classının ogrenciCeza() fonksiyonuna ogrenciId nesnesini parametre gönderdim ve ceza bilgisini çektim.
                if (ogrenciId.OgrenciCeza != 0)     //ogrenciCeza sıfıra eşit değilse
                {
                    float ceza = ogrenciId.OgrenciCeza - float.Parse(txtOdeme.Text);    // float tipinde ceza değişkeni tanımladım. ogrenciId nesnesinin ogrenciceza değişkeninin değerinden txtOdeme textboxunun değerini çıkardım ceza değişkenine atadım.
                    if (ceza >= 0)     //ceza sıfırdan büyük ve eşit ise
                    {
                        ogrenciId.OgrenciCeza = ceza;   //ogrenciId nesnesinin ogrenciCeza değişkenine ceza değişkeninin değerini aktardım.
                        KitapIadeBL.ogrenciCezaIslemi(ogrenciId);   //BL katmanının KitapIadeBL classının ogrenciCezaIslemi() fonksiyonuna ogrenciId nesnesini gönderdim ve veritabanında ceza değerini güncelledim.
                        OgrBilgiListesi();   //OgrBilgiListesi() fonksiyonu ile öğrenci bilgilerinin güncel halini ekrana yazdırdım.
                        MessageBox.Show(txtOdeme.Text + " Tl ödendi.");  //Ekrana txtOdeme textini ve 'Tl ödendi.' mesajını yazdırdım.
                        txtOdeme.Text = "";  //txtOdeme textboxunun içini temizledim.
                    }
                    else     //ceza sıfırdan büyük ve eşit değil ise
                    {
                        MessageBox.Show("Ödenecek tutar cezadan büyük olamaz!");       //Ekrana 'Ödenecek tutar cezadan büyük olamaz!' mesajını yazdırdım.
                    }
                }

                else             //ogrenciCeza sıfıra eşitse
                {
                    MessageBox.Show("Borcunuz Bulunmamaktadır.");      //Ekrana 'Ödenecek tutar cezadan büyük olamaz!' mesajını yazdırdım.
                    txtOdeme.Text = "";                      //txtOdeme textboxunun içini temizledim.
                }
            }
            else             // txtOdeme textboxunun texti boş ise
            {
                MessageBox.Show("Lütfen ödenecek tutarı giriniz!");     //Ekrana 'Lütfen ödenecek tutarı giriniz!' mesajını yazdırdım.
            }

        }

        private void txtOdeme_KeyPress(object sender, KeyPressEventArgs e)    //txtOdeme textboxuna harf girişi yapmayı engelledim.
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTeslim_Click(object sender, EventArgs e)   //btnTeslim butonuna tıklandığında teslim işlemini gerçekleştirdim.
        {
            if (comboBoxTeslim.Text != "")     // comboBoxTeslim comboboxunun texti dolu ise
            {

                KitapOgrenciVeri kitapId = new KitapOgrenciVeri()        //Entity katmanındaki KitapOgrenciVeri class ından kitapId nesnesini oluşturdum.
                {
                    KitapAd = comboBoxTeslim.Text         //kitapId nesnesinin kitapId değişkenine comboBoxTeslim combobox ının textini atadım
                };


                KitapIadeVeri kitap = new KitapIadeVeri()          //Entity katmanındaki KitapIadeVeri class ından kitap nesnesini oluşturdum.
                {
                    KitapId = KitapIadeBL.kitapId(kitapId),            //BL katmanının KitapIadeBL class ının kitapId() fonksiyonuna kitapId nesnesini parametre gönderdim ve dönen değeri kitap nesnesinin kitapId değişkenine atadım.
                    OgrenciId = int.Parse(lblIdOgrenciForm.Text),      //kitap nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin textini atadım.
                    KitapTeslim = dateTimePickerTeslim.Value.Date,     //kitap nesnesinin kitapTeslim değişkenine dateTimePickerTeslim min değerini atadım.
                    KitapKontrol = true                                //kitap nesnesinin kitapKontrol değişkenine true değerini atadım.
                };
                KitapIadeBL.kitapTarih(kitap);      //BL katmanının KitapIadeBL class ının kitapTarih() fonksiyonuna kitap nesnesini parametre gönderdim ve kitabın alınma tarihini çektim.
                TimeSpan sonuc = kitap.KitapTeslim - kitap.KitapAlinma;   //TimeSpan classından sonuc nesnesini oluşturdum ve kitap nesnesinin KitapTeslim değişkeninden kitap nesnesinin KitapAlinma nesnesini çıkardım.
                if (sonuc.TotalDays >= 0)        // zaman farkı negatif değil ise
                {
                    KitapIadeBL.kitapTeslimIslemi(kitap);     //BL katmanının KitapIadeBL class ının kitapTeslimIslemi() fonksiyonuna kitap nesnesini parametre gönderdim ve kitabın veritabanında teslim edilmesini gerçekleştirdim.


                    AlinanKitapVeri alinanKitapVeri = new AlinanKitapVeri()   //Entity katmanındaki AlinanKitapVeri class ından alinanKitapVeri nesnesini oluşturdum.
                    {
                        OgrenciId = int.Parse(lblIdOgrenciForm.Text)          //alinanKitapVeri nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin textini atadım
                    };
                    kitapAlimTeslimListe.DataSource = KitapIadeBL.ogrenciIdListe(alinanKitapVeri);   // Kitab teslim edildikten sonra listenin son halini kitapAlimTeslimListe DataGridView ine listeletmek için BL katmanının KitapIadeBL class ının ogrenciIdListe() fonksiyonunu alinanKitapVeri nesnesini parametre göndererek çağırdım.
                    listeRenklendirme();  //listeRenklendirme() fonksiyonu ile satırları renklendirdim.

                    
                    KitapIadeVeri iade = new KitapIadeVeri()    //Entity katmanındaki KitapIadeVeri class ından iade nesnesini oluşturdum.
                    {
                        OgrenciId = int.Parse(lblIdOgrenciForm.Text)        //alinanKitapVeri nesnesinin ogrenciId değişkenine lblIdOgrenciForm labelinin textini atadım
                    };
                    comboBoxAlinan.DataSource = KitapIadeBL.kitapAlinanLİste(iade);    // BL katmanının KitapIadeBL classının kitapAlinanLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani alınabilecek kitapları comboBoxAlinan combobaxına aktardım
                    comboBoxTeslim.DataSource = KitapIadeBL.kitapTeslimLİste(iade);    // BL katmanının KitapIadeBL classının kitapTeslimLİste() fonksiyonunu iade nesnesi ile çağırdım ve döndürdüğü değeri yani teslim edilebilecek kitapları comboBoxTeslim combobaxına aktardım

                    if (sonuc.TotalDays > 15)  //sonuc büyüktür 15 ise yani teslim süresi 15 günü geçmiş ise
                    {
                        float ceza = float.Parse(sonuc.TotalDays.ToString()) - 15;  //float tipinde ceza nesnesini oluşturdum ve teslim ettiği süreden teslim etmesi gerekn süreyi çıkarıp hergün için 1 tl ceza yazdım.
                        KitapIadeBL.ogrenciCeza(iade);    //BL katmanının KitapIadeBL class ının ogrenciCeza() fonksiyonuna iade nesnesini parametre gönderdim ve ceza bilgisini çektim.
                        iade.OgrenciCeza += ceza;   // iade nesnesinin ogrenciCeza değişkenine ceza değerini ekledim. 
                        KitapIadeBL.ogrenciCezaIslemi(iade); //BL katmanının KitapIadeBL class ının ogrenciCezaIslemi() fonksiyonuna iade nesnesini parametre gönderdim ve ceza bilgisini veritabanında güncelledim..
                        OgrBilgiListesi();   //OgrBilgiListesi() fonksiyonu ile öğrenci bilgilerinin güncel halini ekrana yazdırdım.
                    }

                    MessageBox.Show("Teslim edildi");        //Ekrana 'Teslim edildi' mesajını yazdırdım.

                }

                else          // zaman farkı negatif  ise
                {
                    MessageBox.Show("Teslim tarihi alım tarihinden önce olamaz!");       //Ekrana 'Teslim tarihi alım tarihinden önce olamaz!' mesajını yazdırdım.
                }

            }

            else         // comboBoxTeslim comboboxunun texti boş ise
            {
                MessageBox.Show("Teslim edilecek kitabın yok !");             //Ekrana 'Teslim edilecek kitabın yok !' mesajını yazdırdım.
            }

        }

        private void comboBoxAlinan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GrafikForm ogrenci = new GrafikForm();  //  Grafik formundan nesne üretildi
            ogrenci.lblOgrenciId.Text = lblIdOgrenciForm.Text; //id ataması yapıldı
            this.Hide();                           // Bulunduğumuz form ekranı kapatıldı
            ogrenci.Show();                       // Ogrenci nesnesini kullanarak grafik formu açıldı
        }
    }
}
