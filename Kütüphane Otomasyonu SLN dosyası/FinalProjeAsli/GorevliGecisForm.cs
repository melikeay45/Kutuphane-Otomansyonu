using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjeAsli
{
    public partial class GorevliGecisForm : Form
    {
        public GorevliGecisForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)       //Sol üst köşedeki geri butonuna tıklandığında GorevliGecisForm unu kapattırıp bir önceki sayfa olan GorevliGirisForm unu açtırdım.
        {
            GorevliGirisForm gorevliGiris = new GorevliGirisForm();  //GorevliGirisForm undan gorevliGiris nesnesini oluşturdum.
            this.Hide();                                             //Butona tıklandıktan sonra GorevliGecisForm formununu kapattırdım.
            gorevliGiris.Show();                                     //gorevliGiris nesnesinden yeni form açtırdım.
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();                 // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.

        }

        private void button1_Click(object sender, EventArgs e)   //button1 butonuna tıklandığında öğrenci işlemleri formu açılır.
        {
            OgrenciIslemForm ogrenci = new OgrenciIslemForm();   // OgrenciIslemForm undan ogrenci nesnesini oluşturdum
            this.Hide();                                         //Butona tıklandıktan sonra GorevliGecisForm formununu kapattırdım.
            ogrenci.Show();                                      //ogrenci nesnesinden yeni form açtırdım.

        }

        private void btnGorevliGiris_Click(object sender, EventArgs e)   //btnGorevliGiris butonuna tıklandığında öğrenci işlemleri formu açılır.
        {
            KitapIslemForm kitap = new KitapIslemForm();        // KitapIslemForm undan kitap nesnesini oluşturdum
            this.Hide();                                        //Butona tıklandıktan sonra GorevliGecisForm formununu kapattırdım.
            kitap.Show();                                       //kitap nesnesinden yeni form açtırdım.

        }
    }
}
