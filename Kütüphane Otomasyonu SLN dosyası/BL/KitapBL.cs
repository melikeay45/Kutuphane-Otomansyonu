using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;       // DAL katmanını kullanmak için ekledim.
using Entity;    // Entity katmanını kullanmak için ekledim.

namespace BL
{
    public class KitapBL   //Diğer classlardan erişebilmek için KitapBL classını public yaptım.
    {
        
        public static bool kitapSorgu_BL(KitapVeri kitap)     // Id si girilen kitabın veritabanında var olup olmadığını DAL katmanındaki KitapDAL classının kitapSorgu() fonksiyonu ile kontrol eden KitapVeri class ının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0)    //kitap parametresinin KitapId değeri sıfırdan farklı ise
            {
                return KitapDAL.kitapSorgu(kitap);      //KitapDAL class ının kitapSorgu() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapSorgu_BL() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else    //kitap parametresinin KitapId değeri sıfırdan farklı değil ise
                return false;   // kitapSorgu_BL fonksiyonunun çağrıldığı yere false değerini döndürdüm.
        }


        public static int kitapEkle(KitapVeri kitap)     // DAL katmanındaki KitapDAL classının kitapEkle() fonksiyonunu kullanarak Veritabanına yeni kitap ekleyen KitapVeri class ının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            //Kitap ekleme işleminden önce boş olup olmadığı kontrol etti
            if (kitap.KitapAd != "" && kitap.KitapTuru != "" && kitap.KitapSayfa != "" && kitap.KitapYazar != "")    //kitap parametresinin KitapAd, KitapTuru, KitapSayfa, KitapYazar değeri dolu ise
            {

                return KitapDAL.kitapEkle(kitap);        //KitapDAL class ının kitapEkle() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapEkle() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                  //kitap parametresinin KitapAd, KitapTuru, KitapSayfa, KitapYazar değerleri dolu değil ise
                return -1;                    // kitapEkle() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }

        public static List<KitapVeri> kitapListe()       //Veritabanındaki kitapları DAL katmanındaki KitapDAL classının kitapListe() fonksiyonunu kullanarak listeleyen parametre almayan ve KitapVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return KitapDAL.kitapListe();      //KitapDAL class ının kitapListe() fonksiyonunu çağırdım ve fonksiyondan dönen değeri kitapListe() fonksiyonunun çağrıldığı yere döndürdüm.
        }


        public static int kitapSil(KitapVeri kitap)     //Parametreden gelen Id ye ait kitabı DAL katmanının KitapDAL classının kitapSil() fonksiyonunu kullanılarak silen KitapVeri classının nesnesini parametre alan ve integer türünde değer döndüren fonksiyon yazdım.
        { 
            if (kitap.KitapId != 0)      //kitap parametresinin KitapId değeri sıfırdan farklı ise
            {

                return KitapDAL.kitapSil(kitap);       //KitapDAL class ının kitapSil() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapSil() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else              //kitap parametresinin KitapId değeri sıfırdan farklı değil ise
                return -1;    // kitapSil() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }


        public static int kitapGuncelle(KitapVeri kitap)  //Parametreden gelen Id ye ait kitabın bilgilerini DAL katmanının KitapDAL classının kitapGuncelle() fonksiyonunu kullanarak güncelleryen KitapVeri classının nesnesini parametre alan ve integer türünde değer döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0 && kitap.KitapAd != "" && kitap.KitapTuru != "" && kitap.KitapSayfa != "" && kitap.KitapYazar != "")   //kitap parametresinin KitapId değeri sıfır değil ise ve KitapAd, KitapTuru, KitapSayfa, KitapYazar değeri dolu ise
            {

                return KitapDAL.kitapGuncelle(kitap);    //KitapDAL class ının kitapGuncelle() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapGuncelle() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else           //kitap parametresinin KitapId değeri sıfır ise ve KitapAd, KitapTuru, KitapSayfa, KitapYazar değerleri boş ise
                return -1;                 // kitapGuncelle() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }

        public static KitapVeri kitapIdBilgi(KitapVeri kitap)   //Parametreden gelen Id ye ait kitabın bilgilerini DAL katmanının KitapDAL classının kitapIdBilgi() fonksiyonunu kullanarak çeken KitapVeri classının nesnesini parametre alan ve KitapVeri classının nesnesini döndüren fonksiyon yazdım.
        {
            if (kitap.KitapId != 0)                    //kitap parametresinin KitapId değeri sıfırdan farklı ise
            {
                return KitapDAL.kitapIdBilgi(kitap);   // KitapDAL class ının kitapIdBilgi() fonksiyonuna kitap paremetresini gönderdim ve fonksiyondan dönen değeri kitapIdBilgi() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                  //  kitap parametresinin KitapId değeri sıfırdan farklı değil ise
                return null;      //  kitapIdBilgi() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }
    }
}
