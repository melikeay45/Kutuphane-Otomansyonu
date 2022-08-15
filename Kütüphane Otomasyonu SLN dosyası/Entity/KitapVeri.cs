using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class KitapVeri                                                             //Diğer classlardan erişebilmek için KitapVeri classını public yaptım.
    {
        int kitapId;                                                                   //Integer tipinde kitapId adında değişken tanımladım.
        string kitapAd, kitapTuru, kitapSayfa, kitapYazar;                             //String tipinde kitapAd, kitapTuru, kitapSayfa ve kitapYazar adında 4 tane değişken tanımladım.
        public int KitapId { get => kitapId; set => kitapId = value; }                 //kitapId değişkeninin değerini döndürecek get metodu ve kitapId değişkenine değer atıycak set metodunu yazdım.
        public string KitapAd { get => kitapAd; set => kitapAd = value; }              //kitapAd değişkeninin değerini döndürecek get metodu ve kitapAd değişkenine değer atıycak set metodunu yazdım.
        public string KitapTuru { get => kitapTuru; set => kitapTuru = value; }        //kitapTuru değişkeninin değerini döndürecek get metodu ve kitapTuru değişkenine değer atıycak set metodunu yazdım.
        public string KitapSayfa { get => kitapSayfa; set => kitapSayfa = value; }     //kitapSayfa değişkeninin değerini döndürecek get metodu ve kitapSayfa değişkenine değer atıycak set metodunu yazdım.
        public string KitapYazar { get => kitapYazar; set => kitapYazar = value; }     //kitapYazar değişkeninin değerini döndürecek get metodu ve kitapYazar değişkenine değer atıycak set metodunu yazdım.
    }
}
