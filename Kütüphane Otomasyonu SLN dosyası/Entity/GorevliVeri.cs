using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class GorevliVeri                                                                   //Diğer classlardan erişebilmek için GorevliVeri classını public yaptım.
    {
        int gorevliId;                                                                         //Integer tipinde gorevliId adında değişken tanımladım.
        string gorevliAd, gorevliSoyad, gorevliTc, gorevliSifre;                               //string tipinde gorevliAd, gorevliSoyad, gorevliTc ve gorevliSifre adında 4 değişken tanımladım.

        public int gorevId { get => gorevliId; set => gorevliId = value; }                     //gorevliId değişkeninin değerini döndürecek get metodu ve gorevliId değişkenine değer atıycak set metodunu yazdım.
        public string gorevAd { get => gorevliAd; set => gorevliAd = value; }                  //gorevliAd değişkeninin değerini döndürecek get metodu ve gorevliAd değişkenine değer atıycak set metodunu yazdım.
        public string gorevSoyad { get => gorevliSoyad; set => gorevliSoyad = value; }         //gorevliSoyad değişkeninin değerini döndürecek get metodu ve gorevliSoyad değişkenine değer atıycak set metodunu yazdım.
        public string gorevTc { get => gorevliTc; set => gorevliTc = value; }                  //gorevliTc değişkeninin değerini döndürecek get metodu ve gorevliTc değişkenine değer atıycak set metodunu yazdım.
        public string gorevSifre { get => gorevliSifre; set => gorevliSifre = value; }         //gorevliSifre değişkeninin değerini döndürecek get metodu ve gorevliSifre değişkenine değer atıycak set metodunu yazdım.
    }
}
