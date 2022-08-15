using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;           // Entity katmanını kullanmak için ekledim.
using BL;               // BL katmanını kullanmak için ekledim.

namespace FinalProjeAsli
{
    public partial class GorevliGirisForm : Form
    {
        public GorevliGirisForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)   //Sol üst köşedeki geri butonuna tıklandığında GörevliGirisFormunu kapattırıp bir önceki sayfa olan BaslangıcFormunu açtırdım.
        {
            BaslangicForm baslangic = new BaslangicForm();  //BaslangıcForm undan baslangic nesnesini oluşturdum.
            this.Hide();                                    //Butona tıklandıktan sonra GörevliGiris formunu kapattırdım.
            baslangic.Show();                               //baslangic nesnesinden yeni form açtırdım.

        }

        private void btnGorevliGiris_Click(object sender, EventArgs e)  //btnGorevliGiris butonuna tıklandığında
        {
            if (txtGorevliTc.Text != "" && txtGorevliSifre.Text != "") // txtGorevliTc ve txtGorevliSifre TextBox larının içi boş değil ise
            {
                GorevliVeri gorevli = new GorevliVeri()                //Entity katmanının GörevliVeri classından gorevli nesnesini oluşturdum.
                {
                    gorevTc = txtGorevliTc.Text,                       //gorevli nesnesinin gorevTc değişkenine txtGorevliTc TextBox ının metnini Set metodu ile atadım.
                    gorevSifre = txtGorevliSifre.Text                  //gorevli nesnesinin gorevSifre değişkenine txtGorevliSifre TextBox ının metnini Set metodu ile atadım.
                };
                //BL katmanının GorevliBl class ının gorevliKontrol_BL() fonksiyonuna görevli nesnesini gönderer tc ve şifrenin doğru olup olmadığını kontrol ettirdim.
                
                if (GorevliBL.gorevliKontrol_BL(gorevli) == true)      //Eğer gorevliKontrol_BL() fonksiyonundan dönen değer true ise yani veritabanında görevli nesnesinin tcsi ile eşleşen görevli varsa
                {
                    MessageBox.Show("Giriş başarılı");                 //Ekrana 'Giris başarılı' mesajını yazdırdım.
                    GorevliGecisForm gorevliGecis = new GorevliGecisForm();  //GorevliGecisForm undan nesne oluşturdum.
                    this.Hide();                                             // GorevliGiris formunu kapattırdım.
                    gorevliGecis.Show();                                     // gorevliGecis nesnesinden yeni form açtırdım.
                }

                else                                                         //Eğer gorevliKontrol_BL() fonksiyonundan dönen değer true değil ise 
                {
                    MessageBox.Show("Hatalı giriş");                         //Ekrana 'Hatalı giriş' mesajını yazdırdım.
                }

            }

            else      // txtGorevliTc ve txtGorevliSifre TextBox larının içi boş ise
            {
                MessageBox.Show("Gerekli alanları doldurunuz !");       //Ekrana 'Gerekli alanları doldurunuz !' mesajını yazdırdım.
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)  //CheckBox ın seçili olup olmamasına göre şifrenin görünür veya gizli olması
        {
            if (checkBox1.CheckState == CheckState.Checked)       // CheckBox seçili ise 
            {
                txtGorevliSifre.UseSystemPasswordChar = true;     //Şifreyi gösterdim
                checkBox1.Text = "Gizle";                         //CheckBox ın metnine 'Gizle' yazdırdım.
            }
            else if (checkBox1.CheckState == CheckState.Unchecked) //CheckBox seçili değil ise 
            {
                txtGorevliSifre.UseSystemPasswordChar = false;    //Şifreyi Gizledim
                checkBox1.Text = "Göster";                        //CheckBox ın metnine 'Gözter' yazdırdım.
            }
        }

        private void txtGorevliTc_KeyPress(object sender, KeyPressEventArgs e)     //Tc girilen textboxa harf girilmesini engelledim.
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))  
            {
                e.Handled = true;
            }
        }

        private void GorevliGirisForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)   //pictureBox3 butonuna tıklandığında yapılacak işlemleri yazdım.
        {
            System.Windows.Forms.Application.Exit();                 // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.
        }
    }
}