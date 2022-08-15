using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;            // Entity katmanını kullanmak için ekledim.
using BL;                // BL katmanını kullanmak için ekledim.

namespace FinalProjeAsli
{
    public partial class OgrenciGirisForm : Form
    {
        public OgrenciGirisForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)   //Sol üst köşedeki geri butonuna tıklandığında OgrenciGirisForm kapattırıp bir önceki sayfa olan BaslangicFormunu açtırdım.
        {
            BaslangicForm baslangic = new BaslangicForm();  //BaslangıcForm undan baslangic nesnesini oluşturdum.
            this.Hide();                                    //Butona tıklandıktan sonra OgrenciGirisForm formunu kapattırdım.
            baslangic.Show();                               //baslangic nesnesinden yeni form açtırdım.

        }

        private void button1_Click(object sender, EventArgs e)    //button1 butonuna tıklandığında yapılacak işlemleri yazdım.
        {
            if (txtOgrNo.Text != "" && txtOgrSifre.Text != "")    //txtOgrNo, txtOgrSifre textlerinin içi dolu ise
            {
                OgrenciVeri ogrenci = new OgrenciVeri()           //Entity katmanının OgrenciVeri classından ogrenci nesnesi oluşturdum.
                {
                    OgrenciNo = txtOgrNo.Text,                    //ogrenci nesnesinin ogrenciNo değişkenine txtOgrNo TextBox ının metnini Set metodu ile atadım.
                    OgrenciSifre = txtOgrSifre.Text               //ogrenci nesnesinin ogrenciSifre değişkenine txtOgrSifre TextBox ının metnini Set metodu ile atadım.

                };

                if (OgrenciBL.ogrenciKontrol_BL(ogrenci) == true)   //Eğer ogrenciKontrol_BL() fonksiyonundan dönen değer true ise yani veritabanında ogrenci nesnesinin okul numarası ile eşleşen öğrenci varsa
                {
                    lblIdOgrenciGiris.Text = OgrenciBL.ogrenciIdSorgu(ogrenci).ToString();  //BL katmanının OgrenciBL classının ogrenciIdSorgu() fonksiyonuna ogrenci nesnesini parametre göndererek çağırdım ve dönen id değerini lblIdOgrenciGiris labelinin text ine atadım.
                    MessageBox.Show("Giriş Başarlı");           //Ekrana 'Giris başarılı' mesajını yazdırdım.
                    OgrenciForm ogr = new OgrenciForm();        //OgrenciForm undan ogr nesnesini oluşturdum.
                    ogr.lblIdOgrenciForm.Text = lblIdOgrenciGiris.Text;   //ogr formunun lblIdOgrenciForm labeline lblIdOgrenciGiris labelinin textini atadım.
                    this.Hide();                                          // OgrenciGiris formunu kapattırdım.
                    ogr.Show();                       // ogr nesnesinden yeni form açtırdım.


                }
                else      //Eğer ogrenciKontrol_BL() fonksiyonundan dönen değer false ise yani veritabanında ogrenci nesnesinin okul numarası ile eşleşen öğrenci yoksa
                    MessageBox.Show("Hatalı giriş !");       //Ekrana 'Hatalı giriş !' mesajını yazdırdım.

            }

            else            //txtOgrNo, txtOgrSifre textlerinin içi dolu değil ise
            {
                MessageBox.Show("Gerekli alanları doldurunuz!");        //Ekrana 'Gerekli alanları doldurunuz!' mesajını yazdırdım.
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)       //pictureBox3 butonuna tıklandığında yapılacak işlemleri yazdım.
        {
            System.Windows.Forms.Application.Exit();            // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.

        }

        private void txtOgrNo_KeyPress(object sender, KeyPressEventArgs e)   //Öğrenci numarası girilen textboxa harf girilmesini engelledim.
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OgrenciGirisForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)            //CheckBox ın seçili olup olmamasına göre şifrenin görünür veya gizli olması
        {
            if (checkBox1.CheckState == CheckState.Checked)        // CheckBox seçili ise 
            {
                txtOgrSifre.UseSystemPasswordChar = true;          //Şifreyi gösterdim
                checkBox1.Text = "Gizle";                          //CheckBox ın metnine 'Gizle' yazdırdım.
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)    //CheckBox seçili değil ise 
            {
                txtOgrSifre.UseSystemPasswordChar = false;  //Şifreyi Gizledim
                checkBox1.Text = "Göster";                  //CheckBox ın metnine 'Gözter' yazdırdım.
            }
        }
    }
}
