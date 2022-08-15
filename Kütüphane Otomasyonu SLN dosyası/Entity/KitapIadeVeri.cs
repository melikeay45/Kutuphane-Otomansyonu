using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class KitapIadeVeri                                                                  //Diğer classlardan erişebilmek için KitapIadeVeri classını public yaptım.
    {
        int kitapKayitId, ogrenciId, kitapId;                                                   //Integer tipinde kitapKayitId, ogrenciId ve kitapId adında 3 tane değişken tanımladım.
        DateTime kitapTeslim;                                                                   //DateTime tipinde kitapTeslim adında değişken tanımladım.
        DateTime kitapAlinma;                                                                   //DateTime tipinde kitapAlinma adında değişken tanımladım.
        bool kitapKontrol;                                                                      //bool tipinde kitapKontrol adında değişken tanımladım.
        float ogrenciCeza;                                                                      //float tipinde ogrenciCeza adında değişken tanımladım.


        public int KitapKayitId { get => kitapKayitId; set => kitapKayitId = value; }           //kitapKayitId değişkeninin değerini döndürecek get metodu ve kitapKayitId değişkenine değer atıycak set metodunu yazdım.
        public int KitapId { get => kitapId; set => kitapId = value; }                          //kitapId değişkeninin değerini döndürecek get metodu ve kitapId değişkenine değer atıycak set metodunu yazdım.
        public int OgrenciId { get => ogrenciId; set => ogrenciId = value; }                    //ogrenciId değişkeninin değerini döndürecek get metodu ve ogrenciId değişkenine değer atıycak set metodunu yazdım.
        public DateTime KitapAlinma { get => kitapAlinma; set => kitapAlinma = value; }         //kitapAlinma değişkeninin değerini döndürecek get metodu ve kitapAlinma değişkenine değer atıycak set metodunu yazdım.
        public DateTime KitapTeslim { get => kitapTeslim; set => kitapTeslim = value; }         //kitapTeslim değişkeninin değerini döndürecek get metodu ve kitapTeslim değişkenine değer atıycak set metodunu yazdım.
        public bool KitapKontrol { get => kitapKontrol; set => kitapKontrol = value; }          //kitapKontrol değişkeninin değerini döndürecek get metodu ve kitapKontrol değişkenine değer atıycak set metodunu yazdım.
        public float OgrenciCeza { get => ogrenciCeza; set => ogrenciCeza = value; }            //ogrenciCeza değişkeninin değerini döndürecek get metodu ve ogrenciCeza değişkenine değer atıycak set metodunu yazdım.
    }
}
