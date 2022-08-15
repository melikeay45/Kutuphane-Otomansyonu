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
    public partial class BaslangicForm : Form
    {
        public BaslangicForm()
        {
            InitializeComponent();
        }

        private void BaslangicForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOgrenciLogin_Click(object sender, EventArgs e)   //btnOgrenciLogin butona tıklandığında öğrenci giriş yapar.
        {
            OgrenciGirisForm ogrGiris = new OgrenciGirisForm();   // OgrenciGirisForm undan ogrGiris nesnesi oluşturdum
            this.Hide();                                          // Butona tıklandıktan sonra BaslangicForm ekranını kapattırdım.
            ogrGiris.Show();                                      // Öğrencinin giriş yapacağı form ekranını açtırdım.

        }

        private void btnGorevliGiris_Click(object sender, EventArgs e)   //btnGorevliGiris butona tıklandığında öğrenci giriş yapar.
        {
            GorevliGirisForm grvGiris = new GorevliGirisForm();   // GorevliGirisForm undan grvGiris nesnesi oluşturdum.
            this.Hide();                                          // Butona tıklandıktan sonra BaslangicForm ekranını kapattırdım.
            grvGiris.Show();                                      // Görevlinin giriş yapacağı form ekranını açtırdım.

        }

        private void pictureBox3_Click(object sender, EventArgs e)   //Formun sağ üst köşesindeki kırmızı çarpı resmine tıklandığında uygulama kapatılır.
        {
            System.Windows.Forms.Application.Exit();               // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.

        }
    }
}
