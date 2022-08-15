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
using ZedGraph;     //Grafik ekleyebilmek için ZedGraph kütüphanesini ekledim.

namespace FinalProjeAsli
{
    public partial class GrafikForm : Form
    {
        public GrafikForm()
        {
            InitializeComponent();
        }
        private void Grafik()  // Grafik adında bir fonksiyon oluşturdum
        {
            KitapIadeVeri kitap = new KitapIadeVeri()     //Entity katmanındaki KitapIadeVeri classından kitap nesnesini oluşturdum.
            {
                OgrenciId = int.Parse(lblOgrenciId.Text)         //kitap nesnesinin ogrenciId değişkenine lblOgrenciId labelindeki texti atadım.
            };

            GraphPane myPane = grafikKitap.GraphPane;       // GraphPane classından myPane nesnesini oluşturdum
            myPane.Title.Text = "Öğrenci Kitap Grafiği";    // Grafik Başlığı yazdım
            myPane.YAxis.Title.Text = "Kitap Sayısı";       // Y ekseninin ne olduğu yazdırdım
            myPane.XAxis.Title.Text = "";                   //X ekseninin başlığına boş değer atadım
            double[] y1 = { KitapIadeBL.grafikAlinabilir(kitap) };  // BL katmanının KitapIadeBL classının grafikAlinabilir() fonksiyonunu kitap parametresi ile çağırdım ve döndürdüğü değeri yani alınabilecek kitap sayısını y1 sütununa aktardım.
            double[] y2 = { KitapIadeBL.grafikVerilmis(kitap) };    // BL katmanının KitapIadeBL classının grafikVerilmis() fonksiyonunu kitap parametresi ile çağırdım ve döndürdüğü değeri verilmiş kitap sayısını y2 sütununa aktardım.
            double[] y3 = { KitapIadeBL.grafikHepsi() };            // BL katmanının KitapIadeBL classının grafikHepsi() fonksiyonunun döndürdüğü değeri yani bütün kitapların sayısını y3 sütununa aktardım.

            BarItem myBar = myPane.AddBar("Alınabilir Kitap Sayısı", null, y1, Color.Green); // y1 sütununun adı ve yeşil renk atamasını yaptım
            myBar.Bar.Fill = new Fill(Color.Green, Color.White, Color.Green);        

            myBar = myPane.AddBar("İade Edilmemiş Kitap Sayısı", null, y2, Color.Red);       // y2 sütununun adı ve kırmızı renk atamasını yaptım
            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);

            myBar = myPane.AddBar("Tüm Kitap Sayısı", null, y3, Color.Orange);               // y3 sütununun adı ve turuncu renk atamasını yaptım
            myBar.Bar.Fill = new Fill(Color.Orange, Color.White, Color.Orange);

            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.Type = AxisType.Text;
            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            grafikKitap.AxisChange();  //grafikKitap grafiğinde yaptığım değişiklikleri grafikKitap grafiğine bildirmek için fonksiyonu çağırdım.

        }
        private void grafikKitap_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)    //pictureBox3 e tıklandığında gerçekleşecek işlemleri yazdım.
        {
            System.Windows.Forms.Application.Exit();                  // pictureBox3 e tıklandığında uygulamadan çıkış yaptırdım.
        }

        private void button2_Click(object sender, EventArgs e)       //Sol üst köşedeki geri butonuna tıklandığında GrafikForm unu kapattırıp bir önceki sayfa olan OgrenciForm unu açtırdım.
        {
            OgrenciForm ogrenci = new OgrenciForm();                 //OgrenciForm undan ogrenci nesnesini oluşturdum.
            ogrenci.lblIdOgrenciForm.Text = lblOgrenciId.Text;       //ogrenci formunun lblIdOgrenciForm labelinin textine lblOgrenciId labelinin texttini atadım.
            this.Hide();                                             //Butona tıklandıktan sonra OgrenciGirisForm formununu kapattırdım.
            ogrenci.Show();                                          //ogrenci nesnesinden yeni form açtırdım.

        }

        private void Form4_Load(object sender, EventArgs e)   // Form4(GrafikForm) labeli açıldığında yapılacak işlemleri yazdım.
        {
            lblOgrenciId.Visible = false; //Form ekranında lblOgrenciId adındaki label görünmemesi için gizledim.
            Grafik();                     //Grafik fonksiyonunu çağırdım.

        }
    }
}
