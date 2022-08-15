using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class KitapOgrenciVeri                                                         //Diğer classlardan erişebilmek için KitapOgrenciVeri classını public yaptım.
    {
        int kitapId;                                                                      //Integer tipinde kitapId adında değişken tanımladım.
        string ogrenciAd, ogrenciSoyad, kitapAd, kitapTeslim;                             //String tipinde ogrenciAd, ogrenciSoyad, kitapAd ve kitapTeslim adında 4 tane değişken tanımladım.
        DateTime kitapAlinma;                                                             //DateTime tipinde kitapAlinma adında değişken tanımladım.
        bool kitapKontrol;                                                                //bool tipinde kitapKontrol adında değişken tanımladım.


        public int KitapId { get => kitapId; set => kitapId = value; }                     //kitapId değişkeninin değerini döndürecek get metodu ve kitapId değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciAd { get => ogrenciAd; set => ogrenciAd = value; }            //ogrenciAd değişkeninin değerini döndürecek get metodu ve ogrenciAd değişkenine değer atıycak set metodunu yazdım.
        public string OgrenciSoyad { get => ogrenciSoyad; set => ogrenciSoyad = value; }   //ogrenciSoyad değişkeninin değerini döndürecek get metodu ve ogrenciSoyad değişkenine değer atıycak set metodunu yazdım.
        public string KitapAd { get => kitapAd; set => kitapAd = value; }                  //kitapAd değişkeninin değerini döndürecek get metodu ve kitapAd değişkenine değer atıycak set metodunu yazdım.
        public DateTime KitapAlinma { get => kitapAlinma; set => kitapAlinma = value; }    //kitapAlinma değişkeninin değerini döndürecek get metodu ve kitapAlinma değişkenine değer atıycak set metodunu yazdım.
        public string KitapTeslim { get => kitapTeslim; set => kitapTeslim = value; }      //kitapTeslim değişkeninin değerini döndürecek get metodu ve kitapTeslim değişkenine değer atıycak set metodunu yazdım.
        public bool KitapKontrol { get => kitapKontrol; set => kitapKontrol = value; }     //kitapKontrol değişkeninin değerini döndürecek get metodu ve kitapKontrol değişkenine değer atıycak set metodunu yazdım.

    }
}
