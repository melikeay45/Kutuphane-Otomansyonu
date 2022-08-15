using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class OgrenciVeri                                                                            //Diğer classlardan erişebilmek için OgrenciVeri classını public yaptım.
    {
        int ogrenciId;                                                                                  //Integer tipinde ogrenciId adında değişken tanımladım.
        string ogrenciAd, ogrenciSoyad, ogrenciNo, ogrenciSifre, ogrenciCinsiyet;                       //String tipinde ogrenciAd, ogrenciSoyad, ogrenciNo, ogrenciSifre ve ogrenciCinsiyet adında 5 tane değişken tanımladım.
        float ogrenciCeza;                                                                              //float tipinde ogrenciCeza adında değişken tanımladım.

        public int OgrenciId { get => ogrenciId; set => ogrenciId = value; }                            //ogrenciId değişkeninin değerini döndürecek get metodu ve ogrenciId değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciAd { get => ogrenciAd; set => ogrenciAd = value; }                         //ogrenciAd değişkeninin değerini döndürecek get metodu ve ogrenciAd değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciSoyad { get => ogrenciSoyad; set => ogrenciSoyad = value; }                //ogrenciSoyad değişkeninin değerini döndürecek get metodu ve ogrenciSoyad değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }                         //ogrenciNo değişkeninin değerini döndürecek get metodu ve ogrenciNo değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciSifre { get => ogrenciSifre; set => ogrenciSifre = value; }                //ogrenciSifre değişkeninin değerini döndürecek get metodu ve ogrenciSifre değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciCinsiyet { get => ogrenciCinsiyet; set => ogrenciCinsiyet = value; }       //ogrenciCinsiyet değişkeninin değerini döndürecek get metodu ve ogrenciCinsiyet değişkenine değer atıycak set metodunu yazdım.
        public float OgrenciCeza { get => ogrenciCeza; set => ogrenciCeza = value; }                    //ogrenciCeza değişkeninin değerini döndürecek get metodu ve ogrenciCeza değişkenine değer atıycak set metodunu yazdım.


    }
}
