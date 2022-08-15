using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;      // DAL katmanını kullanmak için ekledim.
using Entity;   // Entity katmanını kullanmak için ekledim.

namespace BL
{
    public class OgrenciBL            //Diğer classlardan erişebilmek için OgrenciBL classını public yaptım.
    {
        public static bool ogrenciKontrol_BL(OgrenciVeri ogrenci)   // Parametreden gelen OgrenciNo ve şifreye ait öğrenci veritabanında kayıtlımı kontrolünü DAL katmanının OgrenciDAL class ının ogrenciKontrol() fonksiyonu ile yapan 
                                                                    // OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciNo != "" && ogrenci.OgrenciSifre != "")          //ogrenci parametresinin OgrenciNo alanı ve OgrenciSifre alanı dolu ise
            {
                return OgrenciDAL.ogrenciKontrol(ogrenci);                      //OgrenciDAL class ının ogrenciKontrol() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciKontrol_BL() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                                //ogrenci parametresinin OgrenciNo alanı ve OgrenciSifre alanı dolu değil ise
                return true;                                                    //ogrenciKontrol_BL() fonksiyonunun çağrıldığı yere true değerini döndürdüm.
        }

        public static bool ogrenciOkulNoKOntrol(OgrenciVeri ogrenci)       //Yeni kayıt eklerken girilen ogrenci nosunun daha önce kayıtlı olup olmadığı kontrolunu DAL katmanının OgrenciDAL class ının OgrenciOkulNoKontrol() fonksiyonu ile yapan 
                                                                           // OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciNo != "")                                   //ogrenci parametresinin OgrenciNo değişkeni boş değil ise
            {
                return OgrenciDAL.OgrenciOkulNoKontrol(ogrenci);           //OgrenciDAL class ının OgrenciOkulNoKontrol() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciOkulNoKOntrol() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                           //ogrenci parametresinin OgrenciNo değişkeni boş ise
                return false;                                              //ogrenciOkulNoKOntrol() fonksiyonunun çağrıldığı yere false değerini döndürdüm.
        }

        public static int ogrenciIdSorgu(OgrenciVeri ogrenci)       //Girilen OgrenciNo ve OgrenciSifre ye ait OgrenciId değerini DAL katmanının OgrenciDAL class ının ogrenciIdSorgu() fonksiyonu ile yapan 
                                                                    // OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciNo != "" && ogrenci.OgrenciSifre != "")    //ogrenci parametresinin OgrenciNo alanı ve OgrenciSifre alanı dolu ise
            {
                return OgrenciDAL.ogrenciIdSorgu(ogrenci);                 //OgrenciDAL class ının ogrenciIdSorgu() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciIdSorgu() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                           //ogrenci parametresinin OgrenciNo alanı ve OgrenciSifre alanı dolu değil ise
                return -1;                                                // ogrenciIdSorgu() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }

        public static OgrenciVeri ogrenciIdBilgi(OgrenciVeri ogrenci)       // Parametreden gen OgrenciId değişkeni ile eşleşen ogrencinin bilgilerini DAL katmanının OgrenciDAL class ının ogrenciIdBilgi() fonksiyonu ile çeken 
                                                                            // OgrenciVeri classının nesnesini parametre alan ve OgrenciVeri classının nesnesini döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciId != 0)                                     //ogrenci parametresinin OgrenciId değişkeni 0 a eşit değil ise
            {
                return OgrenciDAL.ogrenciIdBilgi(ogrenci);                  //OgrenciDAL class ının ogrenciIdBilgi() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciIdBilgi() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                            //ogrenci parametresinin OgrenciId değişkeni 0 a eşit ise
                return null;                                                //ogrenciIdBilgi() fonksiyonunun çağrıldığı yere null değerini döndürdüm.
        }

        public static bool ogrenciSorgu_BL(OgrenciVeri ogrenci)       //Id si girilen öğrencinin kayıtlı olup olmadığının sorgusunu DAL katmanının OgrenciDAL class ının ogrenciSorgu() fonksiyonu ile yapan 
                                                                      // OgrenciVeri classının nesnesini parametre alan ve bool tipinde değer döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciId != 0)                               //ogrenci parametresinin OgrenciId değişkeni 0 a eşit değil ise
            {
                return OgrenciDAL.ogrenciSorgu(ogrenci);              //OgrenciDAL class ının ogrenciSorgu() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciSorgu_BL() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                      //ogrenci parametresinin OgrenciId değişkeni 0 a eşit ise
                return false;                                         //ogrenciSorgu_BL() fonksiyonunun çağrıldığı yere false değerini döndürdüm.
        }



        public static int ogrenciEkle(OgrenciVeri ogrenci)       // DAL katmanının OgrenciDAL class ının ogrenciEkle() fonksiyonu ile yeni öğrenci kaydeden OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            // ogrenci parametresinin OgrenciAd, OgrenciSoyad, OgrenciNo, OgrenciSifre, OgrenciCinsiyet değişkenleri boş değil ise 
            if (ogrenci.OgrenciAd != "" && ogrenci.OgrenciSoyad != "" && ogrenci.OgrenciNo != "" && ogrenci.OgrenciSifre != "" && ogrenci.OgrenciCinsiyet != "")   
            {

                return OgrenciDAL.ogrenciEkle(ogrenci);           // OgrenciDAL class ının ogrenciEkle() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciEkle() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                  // ogrenci parametresinin OgrenciAd, OgrenciSoyad, OgrenciNo, OgrenciSifre, OgrenciCinsiyet değişkenleri boş ise 
                return -1;                                        // ogrenciEkle() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }


        
        public static int ogrenciSil(OgrenciVeri ogrenci)       //Kaydı silinmek istenen öğrenci kaydını DAL katmanının OgrenciDAL class ının ogrenciSil() fonksiyonu ile silen OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            if (ogrenci.OgrenciId != 0)                         //ogrenci parametresinin OgrenciId değişkeni 0 a eşit değil ise
            {

                return OgrenciDAL.ogrenciSil(ogrenci);          //OgrenciDAL class ının ogrenciSil() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciSil() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                //ogrenci parametresinin OgrenciId değişkeni 0 a eşit ise
                return -1;                                      // ogrenciSil() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }

        public static int ogrenciGuncelle(OgrenciVeri ogrenci)       //Bilgileri güncellenmek istenen öğrencinin bilgilerini DAL katmanının OgrenciDAL class ının ogrenciGuncelle() fonksiyonu ile güncelleyen 
                                                                     // OgrenciVeri classının nesnesini parametre alan ve integer tipinde değer döndüren fonksiyon yazdım.
        {
            // ogrenci parametresinin OgrenciAd, OgrenciSoyad, OgrenciNo, OgrenciSifre, OgrenciCinsiyet değişkenleri boş değil ise ve OgrenciId değişkeni 0 değil ise
            if (ogrenci.OgrenciAd != "" && ogrenci.OgrenciSoyad != "" && ogrenci.OgrenciNo != "" && ogrenci.OgrenciSifre != "" && ogrenci.OgrenciCinsiyet != "" && ogrenci.OgrenciId != 0)
            {

                return OgrenciDAL.ogrenciGuncelle(ogrenci);           //OgrenciDAL class ının ogrenciGuncelle() fonksiyonuna ogrenci paremetresini gönderdim ve fonksiyondan dönen değeri ogrenciGuncelle() fonksiyonunun çağrıldığı yere döndürdüm.
            }

            else                                                      // ogrenci parametresinin OgrenciAd, OgrenciSoyad, OgrenciNo, OgrenciSifre, OgrenciCinsiyet değişkenleri boş ise ve OgrenciId değişkeni 0 ise
                return -1;                                            //ogrenciGuncelle() fonksiyonunun çağrıldığı yere -1 değerini döndürdüm.
        }


        public static List<OgrenciVeri> liste()       //Bütün öğrencilerin bilgilerini DAL katmanının OgrenciDAL class ının liste() fonksiyonu çeken parametre almayan ve OgrenciVeri class ı türünde verileri tutan listeyi döndüren fonksiyon yazdım.
        {

            return OgrenciDAL.liste();                 //OgrenciDAL class ının liste() fonksiyonunu çağırdım ve fonksiyondan dönen değeri liste() fonksiyonunun çağrıldığı yere döndürdüm.
        }






    }
}
