using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class AlinanKitapVeri            //Diğer classlardan erişebilmek için AlinanKitapVeri classını public yaptım.
    {
        int ogrenciId;                      //Integer tipinde OgrenciId adında değişken tanımladım.
        string kitapAd, kitapTeslim;        //string tipinde kitapAd ve kitapTeslim adında 2 değişken tanımladım.
        DateTime kitapAlinma;               //DateTime tipinde kitapAlinma adında değişken tanımladım.
        bool kitapKontrol;                  //bool tipinde kitapKontrol adında değişken tanımladım.

        public int OgrenciId { get => ogrenciId; set => ogrenciId = value; }                  //OgrenciId değişkeninin değerini döndürecek get metodu ve OgrenciId değişkenine değer atıycak set metodunu yazdım.
        public string KitapAd { get => kitapAd; set => kitapAd = value; }                     //KitapAd değişkeninin değerini döndürecek get metodu ve KitapAd değişkenine değer atıycak set metodunu yazdım.
        public DateTime KitapAlinma { get => kitapAlinma; set => kitapAlinma = value; }       //KitapAlinma değişkeninin değerini döndürecek get metodu ve KitapAlinma değişkenine değer atıycak set metodunu yazdım.
        public string KitapTeslim { get => kitapTeslim; set => kitapTeslim = value; }         //KitapTeslim değişkeninin değerini döndürecek get metodu ve KitapTeslim değişkenine değer atıycak set metodunu yazdım.
        public bool KitapKontrol { get => kitapKontrol; set => kitapKontrol = value; }        //KitapKontrol değişkeninin değerini döndürecek get metodu ve KitapKontrol değişkenine değer atıycak set metodunu yazdım.

    }
}
